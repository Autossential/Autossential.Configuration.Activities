using Autossential.Configuration.Core.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autossential.Configuration.Core
{
    public class ConfigSection
    {
        public readonly ConfigItemCollection Items = new ConfigItemCollection();

        public int Count => Items.Count;

        public string Name => UniqueName?.Split(DELIMITER).LastOrDefault();

        public string UniqueName { get; private set; }

        private static string CreateUniqueName(string currentSectionUniqueName, string key) =>
            (currentSectionUniqueName + DELIMITER + key).TrimStart(DELIMITER);

        private readonly Dictionary<string, ConfigItem> _cache = new Dictionary<string, ConfigItem>(StringComparer.OrdinalIgnoreCase);

        public ConfigItem GetItem(string keyPath)
        {
            if (keyPath.IndexOf(DELIMITER) == -1)
                return Items.Find(keyPath);

            var section = this;
            var keys = keyPath.Split(DELIMITER);
            for (int i = 0; i < keys.Length - 1; i++)
            {
                var key = keys[i];
                if (section.GetItem(key)?.Value is ConfigSection config)
                {
                    section = config;
                    continue;
                }
                return null;
            }

            return section.GetItem(keys[keys.Length - 1]);
        }

        private ConfigItem SetItem(string keyPath, object value)
        {
            if (keyPath.IndexOf(DELIMITER) == -1)
            {
                if (value is ConfigSection config)
                    config.UniqueName = CreateUniqueName(UniqueName, keyPath);

                return Items.AddOrUpdate(keyPath, value);
            }

            var section = this;
            var keys = keyPath.Split(DELIMITER);

            for (int i = 0; i < keys.Length - 1; i++)
            {
                var key = keys[i];
                if (section.GetItem(key)?.Value is ConfigSection config)
                {
                    section = config;
                    continue;
                }

                config = new ConfigSection();
                section.SetItem(key, config);
                section = config;
            }

            return section.SetItem(keys[keys.Length - 1], value);
        }

        public object this[string keyPath]
        {
            get
            {
                if (_cache.ContainsKey(keyPath))
                    return _cache[keyPath].Value;

                return GetItem(keyPath)?.Value;
            }
            set
            {
                var item = SetItem(keyPath, value);
                if (item == null)
                    _cache.Remove(keyPath);
                else
                    _cache[keyPath] = item;
            }
        }

        internal const char DELIMITER = '/';
        public object this[int index] => Items[index];
        public bool HasKey(string keyPath) => this[keyPath] != null;

        public ConfigSection()
        {

        }

        public ConfigSection(ISectionResolver resolver)
        {
            resolver.Resolve(this);
        }

        public ConfigSection Section(string keyPath)
        {
            if (this[keyPath] is ConfigSection section)
                return section;

            return null;
        }

        public ConfigSection Section(int index)
        {
            if (this[index] is ConfigSection section)
                return section;

            return null;
        }

        public bool HasSection(string keyPath) => Section(keyPath) != null;

        public void Merge(ConfigSection other, bool @override)
        {
            foreach (var item in other.Items)
            {
                if (item.Value is ConfigSection otherSection && HasSection(item.Key))
                {
                    Section(item.Key).Merge(otherSection, @override);
                    continue;
                }

                if (@override || !HasKey(item.Key))
                    this[item.Key] = item.Value;
            }
        }
    }
}