using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.Text.RegularExpressions;

namespace Autossential.Configuration.Core
{
    public static class ConfigItemExtensions
    {
        private static T ValueAsType<T>(ConfigItem item, Func<object, T> converter, T defaultValue)
        {
            if (item.Value is T expectedValue)
                return expectedValue;

            if (item.Value == null)
                return defaultValue;

            try
            {
                return converter(item.Value);
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


        public static List<T> ValueAsList<T>(this ConfigItem item, List<T> defaultValue = default)
        {
            return ValueAsType(item, value =>
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

        public static T[] ValueAsArray<T>(this ConfigItem item, T[] defaultValue = default)
        {
            return ValueAsType(item, value =>
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

        public static string ValueAsString(this ConfigItem item, string defaultValue = default)
            => ValueAsType(item, v => v.ToString(), defaultValue);

        public static int ValueAsInt(this ConfigItem item, int defaultValue = default)
            => ValueAsInt(item, CultureInfo.InvariantCulture, defaultValue);

        public static int ValueAsInt(this ConfigItem item, IFormatProvider provider, int defaultValue = default)
            => ValueAsType(item, v => Convert.ToInt32(v, provider), defaultValue);

        public static double ValueAsDouble(this ConfigItem item, double defaultValue = default)
            => ValueAsDouble(item, CultureInfo.InvariantCulture, defaultValue);

        public static double ValueAsDouble(this ConfigItem item, IFormatProvider provider, double defaultValue = default)
            => ValueAsType(item, v => Convert.ToDouble(v, provider), defaultValue);

        public static decimal ValueAsDecimal(this ConfigItem item, decimal defaultValue = default)
            => ValueAsDecimal(item, CultureInfo.InvariantCulture, defaultValue);

        public static decimal ValueAsDecimal(this ConfigItem item, IFormatProvider provider, decimal defaultValue = default)
            => ValueAsType(item, v => Convert.ToDecimal(v, provider), defaultValue);

        public static float ValueAsFloat(this ConfigItem item, float defaultValue = default)
            => ValueAsFloat(item, CultureInfo.InvariantCulture, defaultValue);

        public static float ValueAsFloat(this ConfigItem item, IFormatProvider provider, float defaultValue = default)
            => ValueAsType(item, v => Convert.ToSingle(v, provider), defaultValue);

        public static long ValueAsLong(this ConfigItem item, long defaultValue = default)
            => ValueAsLong(item, CultureInfo.InvariantCulture, defaultValue);

        public static long ValueAsLong(this ConfigItem item, IFormatProvider provider, long defaultValue = default)
            => ValueAsType(item, v => Convert.ToInt64(v, provider), defaultValue);

        public static DateTime ValueAsDateTime(this ConfigItem item, DateTime defaultValue = default)
            => ValueAsDateTime(item, CultureInfo.InvariantCulture, defaultValue);

        public static DateTime ValueAsDateTime(this ConfigItem item, IFormatProvider provider, DateTime defaultValue = default)
            => ValueAsType(item, v => Convert.ToDateTime(v, provider), defaultValue);

        public static bool ValueAsBoolean(this ConfigItem item, bool defaultValue = default)
            => ValueAsType(item, v => Convert.ToBoolean(v), defaultValue);

        public static ConfigSection ValueAsConfigSection(this ConfigItem item, ConfigSection defaultValue = default)
            => ValueAsType(item, v => (ConfigSection)v, defaultValue);

        public static Regex ValueAsRegex(this ConfigItem item, Regex defaultValue = default)
            => ValueAsRegex(item, RegexOptions.None, defaultValue);

        public static Regex ValueAsRegex(this ConfigItem item, RegexOptions options, Regex defaultValue = default)
        {
            if (item.Value == null)
                return defaultValue;

            string pattern = null;
            if (item.Value is Regex regex)
            {
                if (regex.Options == options)
                    return regex;

                pattern = regex.ToString();
            }

            try
            {
                if (pattern != null || item.Value is string)
                {
                    pattern = pattern ?? item.Value.ToString();
                    return options == RegexOptions.None
                        ? new Regex(pattern)
                        : new Regex(pattern, options);
                }
            }
            catch { }

            return defaultValue;
        }

        public static SecureString ValueAsSecureString(this ConfigItem item, SecureString defaultValue = default)
        {
            return ValueAsType(item, value =>
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