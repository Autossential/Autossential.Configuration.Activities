using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autossential.Configuration.Core
{
    public class ConfigItemCollection : IReadOnlyCollection<ConfigItem>
    {
        public ConfigItemCollection(ConfigSection section)
        {
            _section = section;
        }

        private readonly HashSet<ConfigItem> _items = new HashSet<ConfigItem>();

        private readonly ConfigSection _section;

        public int Count => _items.Count;

        internal ConfigItem Find(string key) => _items.FirstOrDefault(p => p.HasKey(key));

        internal object this[string key]
        {
            get
            {
                return Find(key)?.Value;
            }
            set
            {
                AddOrUpdate(key, value);
            }
        }

        internal object this[int index]
        {
            get
            {
                if (index < Count)
                    return _items.ElementAt(index).Value;

                return null;
            }
        }

        internal void AddOrUpdate(string key, object value)
        {
            var item = Find(key);
            if (item == null)
            {
                var sb = new StringBuilder();
                sb.Insert(0, key);
                var section = _section;
                while (section != null)
                {
                    sb.Insert(0, '/')
                      .Insert(0, section.Name);

                    section = section.GetParent();
                }

                item = new ConfigItem(key, value);
                item.SetUniqueKey(sb.ToString().TrimStart('/'));

                _items.Add(item);
            }
            else
            {
                item.Value = value;
            }
        }

        internal void Remove(string key)
        {
            _items.Remove(Find(key));
        }

        public IEnumerator<ConfigItem> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}