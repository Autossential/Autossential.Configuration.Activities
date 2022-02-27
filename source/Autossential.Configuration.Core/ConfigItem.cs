using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Autossential.Configuration.Core
{
    [DebuggerDisplay("{Key}: {Value}")]
    public class ConfigItem : IEqualityComparer<ConfigItem>, IEquatable<ConfigItem>
    {
        internal ConfigItem(string key, object value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; }

        public object Value { get; set; }

        internal bool HasKey(string key) => Key.Equals(key, StringComparison.OrdinalIgnoreCase);

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