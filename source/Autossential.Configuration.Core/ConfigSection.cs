using Autossential.Configuration.Core.Resolvers;
using System.Collections.Generic;
using System.Diagnostics;

namespace Autossential.Configuration.Core
{
    [DebuggerTypeProxy(typeof(ConfigSectionDebugView))]
    public class ConfigSection
    {
        public class ConfigSectionDebugView
        {
            public ConfigSectionDebugView(ConfigSection config)
            {
                Body = new Dictionary<string, object>();
                MapAllKeys(config, "");
            }

            private void MapAllKeys(ConfigSection config, string sufix)
            {
                foreach (var item in config.Items)
                {
                    if (config.HasSection(item.Key))
                    {
                        MapAllKeys(config.Section(item.Key), sufix + item.Key + SectionDelimiter);
                        continue;
                    }
                    Body.Add(sufix + item.Key, item.Value);
                }
            }

            public Dictionary<string, object> Body { get; set; }
        }

        public readonly ConfigItemCollection Items;

        public ConfigSection()
        {
            Items = new ConfigItemCollection(this);
        }

        public ConfigSection(ISectionResolver resolver) : this()
        {
            Name = null;
            resolver.Resolve(this);
        }

        public string Name { get; private set; }

        public bool HasKey(string keyPath) => this[keyPath] != null;

        public ConfigItem AsConfigItem(string keyPath)
        {
            return ResolveKeyPath(keyPath, false, out ConfigSection section, out string key)
                ? section.Items.Find(key)
                : null;
        }

        public object this[string keyPath]
        {
            get
            {
                return ResolveKeyPath(keyPath, false, out ConfigSection section, out string key)
                    ? section.Items[key]
                    : null;
            }
            set
            {
                if (value == null)
                {
                    Delete(keyPath);
                    return;
                }

                ResolveKeyPath(keyPath, true, out ConfigSection section, out string key);
                if (value is ConfigSection config)
                {
                    config.Name = key;
                    config.SetParent(this);
                }

                section.Items[key] = value;
            }
        }

        public object this[int index] => Items[index];

        private ConfigSection _parent;

        public ConfigSection GetParent() => _parent;

        private void SetParent(ConfigSection value)
        {
            _parent = value;
        }

        private void Delete(string keyPath)
        {
            if (ResolveKeyPath(keyPath, false, out ConfigSection section, out string key))
                section.Items.Remove(key);
        }

        private bool ResolveKeyPath(string keyPath, bool ensureSection, out ConfigSection section, out string key)
        {
            var index = keyPath.LastIndexOf(SectionDelimiter);
            if (index == -1)
            {
                section = this;
                key = keyPath;
                return true;
            }

            section = Section(keyPath.Substring(0, index), ensureSection);
            key = keyPath.Substring(index + 1);
            return section != null;
        }

        public ConfigSection Section(int index) => this[index] as ConfigSection;

        private ConfigSection Section(string keyPath, bool createIfNotExist)
        {
            var section = this;
            foreach (var key in keyPath.Split(SectionDelimiter))
            {
                var item = section[key];
                if (item is ConfigSection config)
                {
                    section = config;
                }
                else if (createIfNotExist)
                {
                    var cs = new ConfigSection();
                    section[key] = cs;
                    section = cs;
                }
                else
                {
                    return null;
                }
            }
            return section;
        }

        public ConfigSection Section(string keyPath) => Section(keyPath, false);

        public static char SectionDelimiter = '/';

        public void Merge(ConfigSection other, bool @override)
        {
            foreach (var item in other.Items)
            {
                if (HasSection(item.Key) && item.Value is ConfigSection otherSection)
                {
                    Section(item.Key).Merge(otherSection, @override);
                    continue;
                }

                if (@override || !HasKey(item.Key))
                    this[item.Key] = item.Value;
            }
        }

        public bool HasSection(string keyPath) => Section(keyPath) != null;

        public int Count => Items.Count;
    }
}