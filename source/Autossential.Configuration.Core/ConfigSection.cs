using Autossential.Configuration.Core.Resolvers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Autossential.Configuration.Core
{
    public class ConfigSection : IReadOnlyCollection<ConfigItem>
    {
        internal List<ConfigItem> Items { get; } = new List<ConfigItem>();

        public int Count => Items.Count;

        public string Name => UniqueName?.Split(DELIMITER).LastOrDefault();

        public string UniqueName { get; private set; }

        private static string CreateUniqueName(string currentSectionUniqueName, string key) =>
            (currentSectionUniqueName + DELIMITER + key).TrimStart(DELIMITER);

        private readonly Dictionary<string, ConfigItem> _cache = new Dictionary<string, ConfigItem>(StringComparer.OrdinalIgnoreCase);

        private ConfigSection _parent;

        public ConfigSection Parent() => _parent;

        public ConfigSection Root()
        {
            var root = this;
            var parent = Parent();

            while (parent != null)
            {
                root = parent;
                parent = parent.Parent();
            }

            return root;
        }

        public ConfigItem GetItem(string keyPath)
        {
            if (keyPath.IndexOf(DELIMITER) == -1)
                return Find(keyPath);

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

        private ConfigItem Find(string key) => Items.Find(p => p.HasKey(key));

        private ConfigItem AddOrUpdate(string key, object value)
        {
            if (value == null)
            {
                Items.Remove(Find(key));
                return null;
            }

            var item = Find(key);
            if (item == null)
            {
                item = new ConfigItem(key, value);
                Items.Add(item);
            }
            else
            {
                item.Value = value;
            }
            return item;
        }

        private ConfigItem SetItem(string keyPath, object value)
        {
            if (keyPath.IndexOf(DELIMITER) == -1)
            {
                if (value is ConfigSection config)
                {
                    config.UniqueName = CreateUniqueName(UniqueName, keyPath);
                    config._parent = this;
                }

                return AddOrUpdate(keyPath, value);
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

        public object this[int index]
        {
            get
            {
                if (index < Items.Count)
                    return Items[index].Value;

                return null;
            }
        }

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

        public IEnumerator<ConfigItem> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}