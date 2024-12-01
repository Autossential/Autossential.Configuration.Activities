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

        public Type ValueType => Value?.GetType();

        public bool Equals(ConfigItem x, ConfigItem y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;

            return x.Key == y.Key;
        }

        internal bool HasKey(string key) => Key.Equals(key, StringComparison.OrdinalIgnoreCase);

        public bool Equals(ConfigItem other)
        {
            return Equals(other);
        }

        public int GetHashCode(ConfigItem obj)
        {
            return Key?.GetHashCode() ?? 0 ^ Value?.GetHashCode() ?? 0;
        }

        /// <summary>
        /// Mutates the value based on the method used to capture it. This increases the speed of consecutive captures in looping scenarios.
        /// </summary>
        internal T Mutate<T>(T value)
        {
            Value = value;
            return value;
        }
    }
}