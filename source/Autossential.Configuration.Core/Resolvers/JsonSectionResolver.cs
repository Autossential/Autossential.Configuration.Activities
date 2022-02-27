using System.Linq;
using System.Text.Json;

namespace Autossential.Configuration.Core.Resolvers
{
    public class JsonSectionResolver : ISectionResolver
    {
        private readonly string _jsonContent;

        public JsonSectionResolver(string jsonContent)
        {
            _jsonContent = jsonContent;
        }

        public void Resolve(ConfigSection config)
        {
            var settings = JsonSerializer.Deserialize<JsonElement>(_jsonContent);
            ResolveInternal(config, settings);
        }

        private void ResolveInternal(ConfigSection config, JsonElement element)
        {

            foreach (var item in element.EnumerateObject())
            {
                var key = item.Name;
                switch (item.Value.ValueKind)
                {
                    case JsonValueKind.Object:
                        var subConfig = new ConfigSection();
                        config[key] = subConfig;
                        ResolveInternal(subConfig, item.Value);
                        break;

                    default:
                        var value = GetElementValue(item.Value);
                        config[key] = value;
                        break;
                }
            }
        }

        private object GetElementValue(JsonElement element)
        {
            switch (element.ValueKind)
            {
                case JsonValueKind.Array:
                    return element.EnumerateArray().Select(GetElementValue).ToList();

                case JsonValueKind.Number: return element.GetDouble();

                case JsonValueKind.True:
                case JsonValueKind.False: return element.GetBoolean();
                case JsonValueKind.String: return element.GetString();

                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                default: return null;
            }
        }
    }
}