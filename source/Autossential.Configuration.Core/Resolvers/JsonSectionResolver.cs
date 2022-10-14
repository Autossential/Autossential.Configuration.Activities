﻿using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Diagnostics;

namespace Autossential.Configuration.Core.Resolvers
{
    public class JsonSectionResolver : DictionarySectionResolver
    {
        private readonly string _jsonContent;

        public JsonSectionResolver(string jsonContent)
        {
            _jsonContent = jsonContent;
        }

        public override void Resolve(ConfigSection config)
        {
            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonDictionaryConverter());

            var settings = JsonSerializer.Deserialize<Dictionary<string, object>>(_jsonContent, options);
            ResolveInternal(config, settings);
        }

        private class JsonDictionaryConverter : JsonConverter<Dictionary<string, object>>
        {
            public override bool CanConvert(Type typeToConvert)
            {
                return typeToConvert == typeof(Dictionary<string, object>);
            }
            public override Dictionary<string, object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                    throw new JsonException("The Json content must be a single object, not an array.");

                var result = new Dictionary<string, object>();
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        return result;

                    if (reader.TokenType != JsonTokenType.PropertyName)
                        throw new JsonException("JsonTokenType is not PropertyName.");

                    var name = reader.GetString();
                    if (string.IsNullOrWhiteSpace(name)) // just ignores
                        continue;

                    reader.Read();
                    result.Add(name, GetValue(ref reader, options));
                }
                return result;
            }

            public override void Write(Utf8JsonWriter writer, Dictionary<string, object> value, JsonSerializerOptions options)
            {
                // not used.
            }

            private static object GetValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        var dic = new Dictionary<string, object>();
                        while (reader.Read() && reader.TokenType != JsonTokenType.EndObject)
                        {
                            var name = reader.GetString();
                            reader.Read();
                            dic.Add(name, GetValue(ref reader, options));
                        }
                        return dic;
                    case JsonTokenType.StartArray:
                        var list = new List<object>();
                        while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                            list.Add(GetValue(ref reader, options));
                        return list;
                    case JsonTokenType.String:
                        if (reader.TryGetDateTime(out var date))
                            return date;
                        return reader.GetString();
                    case JsonTokenType.Number:
                        return reader.TryGetInt64(out var result) ? result : reader.GetDecimal();
                    case JsonTokenType.True: return true;
                    case JsonTokenType.False: return false;
                    case JsonTokenType.Null: return null;
                    default:
                        Trace.TraceError($"JsonTokenType {reader.TokenType} is not supported");
                        return null;
                }
            }
        }
    }
}