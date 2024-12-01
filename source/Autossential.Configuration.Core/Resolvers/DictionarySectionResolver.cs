using System.Collections;
using System.Collections.Generic;

namespace Autossential.Configuration.Core.Resolvers
{
    public class DictionarySectionResolver : ISectionResolver
    {
        private readonly Dictionary<string, object> _settings;

        protected DictionarySectionResolver()
        { }

        public DictionarySectionResolver(Dictionary<string, object> settings)
        {
            _settings = settings;
        }

        public virtual void Resolve(ConfigSection config)
        {
            ResolveInternal(config, _settings);
        }

        protected void ResolveInternal(ConfigSection config, Dictionary<string, object> settings)
        {
            foreach (var item in settings)
            {
                var key = item.Key;
                if (item.Value != null && typeof(IDictionary).IsAssignableFrom(item.Value.GetType()))
                {
                    var subConfig = new ConfigSection();
                    config[key] = subConfig;

                    var subSettings = Normalize(item.Value as IDictionary);
                    ResolveInternal(subConfig, subSettings);
                }
                else
                {
                    config[key] = item.Value;
                }
            }
        }

        private Dictionary<string, object> Normalize(IDictionary dictionary)
        {
            var result = new Dictionary<string, object>();
            foreach (object key in dictionary.Keys)
                result.Add(key.ToString(), dictionary[key]);
            return result;
        }
    }
}