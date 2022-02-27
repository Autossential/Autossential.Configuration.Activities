using System.Collections;
using System.Collections.Generic;

namespace Autossential.Configuration.Core
{
    public class ConfigItemCollection : IReadOnlyCollection<ConfigItem>
    {
        private readonly List<ConfigItem> _items = new List<ConfigItem>();

        public int Count => _items.Count;

        internal ConfigItem Find(string key) => _items.Find(p => p.HasKey(key));

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
                    return _items[index].Value;

                return null;
            }
        }

        internal ConfigItem AddOrUpdate(string key, object value)
        {
            if (value == null)
            {
                Remove(key);
                return null;
            }

            var item = Find(key);
            if (item == null)
            {
                item = new ConfigItem(key, value);
                _items.Add(item);
            }
            else
            {
                item.Value = value;
            }
            return item;
        }

        internal void Remove(string key) => _items.Remove(Find(key));

        public IEnumerator<ConfigItem> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}