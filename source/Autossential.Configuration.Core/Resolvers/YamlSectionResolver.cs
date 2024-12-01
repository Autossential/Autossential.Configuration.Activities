using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace Autossential.Configuration.Core.Resolvers
{
    public class YamlSectionResolver : DictionarySectionResolver
    {
        private readonly IDeserializer _deserializer;
        private readonly IParser _yamlContent;

        public YamlSectionResolver(string yamlContent)
        {
            _deserializer = new DeserializerBuilder()
                .WithObjectFactory(new DictionaryObjectFactory())
                .Build();

            _yamlContent = new MergingParser(new Parser(new StringReader(yamlContent)));
        }

        public override void Resolve(ConfigSection config)
        {
            var settings = _deserializer.Deserialize<Dictionary<string, object>>(_yamlContent);
            ResolveInternal(config, settings);
        }
    }

    internal class DictionaryObjectFactory : IObjectFactory
    {
        public object Create(Type type)
        {
            if (type == typeof(Dictionary<object, object>))
            {
                return new Dictionary<string, object>();
            }

            return Activator.CreateInstance(type);
        }

        public object CreatePrimitive(Type type)
        {
            throw new NotImplementedException();
        }

        public void ExecuteOnDeserialized(object value)
        {
            throw new NotImplementedException();
        }

        public void ExecuteOnDeserializing(object value)
        {
            throw new NotImplementedException();
        }

        public void ExecuteOnSerialized(object value)
        {
            throw new NotImplementedException();
        }

        public void ExecuteOnSerializing(object value)
        {
            throw new NotImplementedException();
        }

        public bool GetDictionary(IObjectDescriptor descriptor, out IDictionary dictionary, out Type[] genericArguments)
        {
            throw new NotImplementedException();
        }

        public Type GetValueType(Type type)
        {
            throw new NotImplementedException();
        }
    }
}