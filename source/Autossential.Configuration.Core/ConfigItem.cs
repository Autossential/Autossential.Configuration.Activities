using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

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
            return Equals(other);
        }

        private T ValueAsType<T>(Func<object, T> converter, T defaultValue)
        {
            if (Value is T expectedValue)
                return expectedValue;

            if (Value == null)
                return defaultValue;

            try
            {
                return converter(Value);
            }
            catch
            {
                return defaultValue;
            }
        }

        private static IEnumerable<T> EnumerableAsType<T>(IEnumerable enumerable)
        {
            foreach (var item in enumerable)
            {
                if (item is T expectedValue)
                    yield return expectedValue;

                else if (item is IConvertible)
                    yield return (T)Convert.ChangeType(item, typeof(T));
            }
        }

        public List<T> ValueAsList<T>(List<T> defaultValue = default)
        {
            return ValueAsType(value =>
            {
                if (value is IEnumerable enumerable)
                {
                    try
                    {
                        return EnumerableAsType<T>(enumerable).ToList();
                    }
                    catch { }
                }

                return defaultValue;
            }, defaultValue);
        }

        public T[] ValueAsArray<T>(T[] defaultValue = default)
        {
            return ValueAsType(value =>
            {
                if (value is IEnumerable enumerable)
                {
                    try
                    {
                        return EnumerableAsType<T>(enumerable).ToArray();
                    }
                    catch { }
                }

                return defaultValue;
            }, defaultValue);
        }

        public string ValueAsString(string defaultValue = default)
            => ValueAsType(v => v.ToString(), defaultValue);

        public int ValueAsInt(int defaultValue = default)
            => ValueAsInt(CultureInfo.InvariantCulture, defaultValue);

        public int ValueAsInt(IFormatProvider provider, int defaultValue = default)
            => ValueAsType(v => Convert.ToInt32(v, provider), defaultValue);

        public double ValueAsDouble(double defaultValue = default)
            => ValueAsDouble(CultureInfo.InvariantCulture, defaultValue);

        public double ValueAsDouble(IFormatProvider provider, double defaultValue = default)
            => ValueAsType(v => Convert.ToDouble(v, provider), defaultValue);

        public decimal ValueAsDecimal(decimal defaultValue = default)
            => ValueAsDecimal(CultureInfo.InvariantCulture, defaultValue);

        public decimal ValueAsDecimal(IFormatProvider provider, decimal defaultValue = default)
            => ValueAsType(v => Convert.ToDecimal(v, provider), defaultValue);

        public float ValueAsFloat(float defaultValue = default)
            => ValueAsFloat(CultureInfo.InvariantCulture, defaultValue);

        public float ValueAsFloat(IFormatProvider provider, float defaultValue = default)
            => ValueAsType(v => Convert.ToSingle(v, provider), defaultValue);

        public long ValueAsLong(long defaultValue = default)
            => ValueAsLong(CultureInfo.InvariantCulture, defaultValue);

        public long ValueAsLong(IFormatProvider provider, long defaultValue = default)
            => ValueAsType(v => Convert.ToInt64(v, provider), defaultValue);

        public DateTime ValueAsDateTime(DateTime defaultValue = default)
            => ValueAsDateTime(CultureInfo.InvariantCulture, defaultValue);

        public DateTime ValueAsDateTime(IFormatProvider provider, DateTime defaultValue = default)
            => ValueAsType(v => Convert.ToDateTime(v, provider), defaultValue);

        public bool ValueAsBoolean(bool defaultValue = default)
            => ValueAsType(v => Convert.ToBoolean(v), defaultValue);

        public ConfigSection ValueAsConfigSection(ConfigSection defaultValue = default)
            => ValueAsType(v => (ConfigSection)v, defaultValue);

        public Regex ValueAsRegex(Regex defaultValue = default)
            => ValueAsRegex(RegexOptions.None, defaultValue);

        public Regex ValueAsRegex(RegexOptions options, Regex defaultValue = default)
        {
            var value = ValueAsType(v =>
            {
                if (v is string pattern)
                {
                    return options == RegexOptions.None
                        ? new Regex(pattern)
                        : new Regex(pattern, options);
                }

                return defaultValue;

            }, defaultValue);

            if (value is Regex expr)
            {
                if (expr.Options == options)
                    return expr;

                return new Regex(expr.ToString(), options);
            }

            return value;
        }

        public SecureString ValueAsSecureString(SecureString defaultValue = default)
        {
            return ValueAsType(value =>
            {
                if (value is string plainText)
                {
                    var ss = new SecureString();
                    foreach (var c in plainText)
                        ss.AppendChar(c);
                    return ss;
                }

                return defaultValue;
            }, defaultValue);
        }
    }
}