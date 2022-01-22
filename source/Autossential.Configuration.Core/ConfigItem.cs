using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Autossential.Configuration.Core
{
    [DebuggerDisplay("{Key}: {Value}")]
    public class ConfigItem : IEqualityComparer<ConfigItem>, IEquatable<ConfigItem>
    {
        public ConfigItem(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }
        public object Value { get; set; }
        internal bool HasKey(string key) => string.Compare(Key, key, true) == 0;
        internal ConfigSection Section { get; set; }

        private string _uniqueKey;

        public string UniqueKey()
        {
            return _uniqueKey;
        }

        internal void SetUniqueKey(string value)
        {
            _uniqueKey = value;
        }

        public bool Equals(ConfigItem x, ConfigItem y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;

            return x.Key == y.Key;
        }

        public int GetHashCode(ConfigItem obj)
        {
            return Key?.GetHashCode() ?? 0 ^ Value?.GetHashCode() ?? 0;
        }

        public bool Equals(ConfigItem other)
        {
            return Equals(this, other);
        }
    }
}