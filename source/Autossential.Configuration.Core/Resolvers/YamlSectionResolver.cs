using Autossential.Configuration.Core;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace Autossential.Configuration.Core.Resolvers
{
    public class YamlSectionResolver : ISectionResolver
    {
        private readonly Deserializer _deserializer;
        private readonly string _yamlContent;

        public YamlSectionResolver(string yamlContent)
        {
            _deserializer = new Deserializer();
            _yamlContent = yamlContent;
        }

        public void Resolve(ConfigSection config)
        {
            var settings = _deserializer.Deserialize<Dictionary<object, object>>(_yamlContent);
            ResolveInternal(config, settings);
        }

        private void ResolveInternal(ConfigSection config, Dictionary<object, object> settings)
        {
            foreach (var item in settings)
            {
                var key = item.Key.ToString();
                if (item.Value is Dictionary<object, object> subSettings)
                {
                    var subConfig = new ConfigSection();
                    config[key] = subConfig;
                    ResolveInternal(subConfig, subSettings);
                }
                else
                {
                    config[key] = item.Value;
                }
            }
        }
    }
}