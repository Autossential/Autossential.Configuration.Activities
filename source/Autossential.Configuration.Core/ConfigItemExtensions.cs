using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security;
using System.Text.RegularExpressions;

namespace Autossential.Configuration.Core
{
    // CS0854: An expression tree may not contain a call or invocation that uses optional arguments.
    // - Due to this limitation, all extension methods below does not use optional arguments.
    // - It is not beautiful, but simplifies its use in UiPath/WWF workflows.
    public static class ConfigItemExtensions
    {
        public static T[] ValueAsArray<T>(this ConfigItem item, T[] defaultValue)
        {
            return item.ValueAsType(value =>
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
        public static T[] ValueAsArray<T>(this ConfigItem item) => item.ValueAsArray(default(T[]));

        public static bool ValueAsBoolean(this ConfigItem item, bool defaultValue) => item.ValueAsType(v => Convert.ToBoolean(v), defaultValue);
        public static bool ValueAsBoolean(this ConfigItem item) => item.ValueAsBoolean(default);

        public static ConfigSection ValueAsConfigSection(this ConfigItem item, ConfigSection defaultValue) => item.ValueAsType(v => (ConfigSection)v, defaultValue);
        public static ConfigSection ValueAsConfigSection(this ConfigItem item) => item.ValueAsConfigSection(default);

        public static DateTime ValueAsDateTime(this ConfigItem item, IFormatProvider provider, DateTime defaultValue) => item.ValueAsType(v => Convert.ToDateTime(v, provider), defaultValue);
        public static DateTime ValueAsDateTime(this ConfigItem item, IFormatProvider provider) => item.ValueAsDateTime(provider, default);
        public static DateTime ValueAsDateTime(this ConfigItem item, DateTime defaultValue) => item.ValueAsDateTime(CultureInfo.InvariantCulture, defaultValue);
        public static DateTime ValueAsDateTime(this ConfigItem item) => item.ValueAsDateTime(CultureInfo.InvariantCulture, default);

        public static decimal ValueAsDecimal(this ConfigItem item, IFormatProvider provider, decimal defaultValue) => item.ValueAsType(v => Convert.ToDecimal(v, provider), defaultValue);
        public static decimal ValueAsDecimal(this ConfigItem item, IFormatProvider provider) => item.ValueAsDecimal(provider, default);
        public static decimal ValueAsDecimal(this ConfigItem item, decimal defaultValue) => item.ValueAsDecimal(CultureInfo.InvariantCulture, defaultValue);
        public static decimal ValueAsDecimal(this ConfigItem item) => item.ValueAsDecimal(CultureInfo.InvariantCulture, default);

        public static double ValueAsDouble(this ConfigItem item, IFormatProvider provider, double defaultValue) => item.ValueAsType(v => Convert.ToDouble(v, provider), defaultValue);
        public static double ValueAsDouble(this ConfigItem item, IFormatProvider provider) => item.ValueAsDouble(provider, default);
        public static double ValueAsDouble(this ConfigItem item, double defaultValue) => item.ValueAsDouble(CultureInfo.InvariantCulture, defaultValue);
        public static double ValueAsDouble(this ConfigItem item) => item.ValueAsDouble(CultureInfo.InvariantCulture, default);

        public static float ValueAsFloat(this ConfigItem item, IFormatProvider provider, float defaultValue) => item.ValueAsType(v => Convert.ToSingle(v, provider), defaultValue);
        public static float ValueAsFloat(this ConfigItem item, IFormatProvider provider) => item.ValueAsFloat(provider, default);
        public static float ValueAsFloat(this ConfigItem item, float defaultValue) => item.ValueAsFloat(CultureInfo.InvariantCulture, defaultValue);
        public static float ValueAsFloat(this ConfigItem item) => item.ValueAsFloat(CultureInfo.InvariantCulture, default);

        public static int ValueAsInt(this ConfigItem item, IFormatProvider provider, int defaultValue) => item.ValueAsType(v => Convert.ToInt32(v, provider), defaultValue);
        public static int ValueAsInt(this ConfigItem item, IFormatProvider provider) => item.ValueAsInt(provider, default);
        public static int ValueAsInt(this ConfigItem item, int defaultValue) => item.ValueAsInt(CultureInfo.InvariantCulture, defaultValue);
        public static int ValueAsInt(this ConfigItem item) => item.ValueAsInt(CultureInfo.InvariantCulture, default);

        public static List<T> ValueAsList<T>(this ConfigItem item, List<T> defaultValue)
        {
            return item.ValueAsType(value =>
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
        public static List<T> ValueAsList<T>(this ConfigItem item) => item.ValueAsList(default(List<T>));

        public static long ValueAsLong(this ConfigItem item, IFormatProvider provider, long defaultValue) => item.ValueAsType(v => Convert.ToInt64(v, provider), defaultValue);
        public static long ValueAsLong(this ConfigItem item, IFormatProvider provider) => item.ValueAsLong(provider, default);
        public static long ValueAsLong(this ConfigItem item, long defaultValue) => item.ValueAsLong(CultureInfo.InvariantCulture, defaultValue);
        public static long ValueAsLong(this ConfigItem item) => item.ValueAsLong(CultureInfo.InvariantCulture, default);

        public static Regex ValueAsRegex(this ConfigItem item, RegexOptions options) => item.ValueAsRegex(options, default);
        public static Regex ValueAsRegex(this ConfigItem item, Regex defaultValue) => item.ValueAsRegex(RegexOptions.None, defaultValue);
        public static Regex ValueAsRegex(this ConfigItem item) => item.ValueAsRegex(RegexOptions.None, default);
        public static Regex ValueAsRegex(this ConfigItem item, RegexOptions options, Regex defaultValue)
        {
            var value = item.ValueAsType(v =>
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

        public static SecureString ValueAsSecureString(this ConfigItem item) => item.ValueAsSecureString(default);
        public static SecureString ValueAsSecureString(this ConfigItem item, SecureString defaultValue)
        {
            return item.ValueAsType(value =>
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

        public static string ValueAsString(this ConfigItem item, string defaultValue)
        {
            return item.ValueAsType(v =>
            {
                if (v is SecureString sv)
                    return new NetworkCredential("", sv).Password;

                return v.ToString();

            }, defaultValue);
        }

        public static string ValueAsString(this ConfigItem item) => item.ValueAsString(default);

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

        private static T ValueAsType<T>(this ConfigItem item, Func<object, T> converter, T defaultValue)
        {
            if (item.Value is T expectedValue)
                return expectedValue;

            if (item.Value == null)
                return defaultValue;

            try
            {
                return item.Mutate(converter(item.Value));
            }
            catch
            {
                return defaultValue;
            }
        }
    }

}
