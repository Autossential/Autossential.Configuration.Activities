using System;
using System.Collections.Generic;
using System.Security;
using System.Text.RegularExpressions;

namespace Autossential.Configuration.Core
{
    public static class ConfigSectionExtensions
    {
        public static string AsString(this ConfigSection section, string keyPath, string defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsString(defaultValue);

        public static int AsInt(this ConfigSection section, string keyPath, int defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsInt(defaultValue);

        public static int AsInt(this ConfigSection section, string keyPath, IFormatProvider provider, int defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsInt(provider, defaultValue);

        public static long AsLong(this ConfigSection section, string keyPath, long defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsLong(defaultValue);

        public static long AsLong(this ConfigSection section, string keyPath, IFormatProvider provider, long defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsLong(provider, defaultValue);

        public static double AsDouble(this ConfigSection section, string keyPath, double defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsDouble(defaultValue);

        public static double AsDouble(this ConfigSection section, string keyPath, IFormatProvider provider, double defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsDouble(provider, defaultValue);

        public static float AsFloat(this ConfigSection section, string keyPath, float defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsFloat(defaultValue);

        public static float AsFloat(this ConfigSection section, string keyPath, IFormatProvider provider, float defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsFloat(provider, defaultValue);

        public static decimal AsDecimal(this ConfigSection section, string keyPath, decimal defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsDecimal(defaultValue);

        public static decimal AsDecimal(this ConfigSection section, string keyPath, IFormatProvider provider, decimal defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsDecimal(provider, defaultValue);

        public static DateTime AsDateTime(this ConfigSection section, string keyPath, DateTime defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsDateTime(defaultValue);

        public static DateTime AsDateTime(this ConfigSection section, string keyPath, IFormatProvider provider, DateTime defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsDateTime(provider, defaultValue);

        public static bool AsBoolean(this ConfigSection section, string keyPath, bool defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsBoolean(defaultValue);

        public static T[] AsArray<T>(this ConfigSection section, string keyPath, T[] defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsArray(defaultValue);

        public static List<T> AsList<T>(this ConfigSection section, string keyPath, List<T> defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsList(defaultValue);

        public static Regex AsRegex(this ConfigSection section, string keyPath, Regex defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsRegex(defaultValue);

        public static Regex AsRegex(this ConfigSection section, string keyPath, RegexOptions options, Regex defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsRegex(options, defaultValue);

        public static SecureString AsSecureString(this ConfigSection section, string keyPath, SecureString defaultValue = default)
            => section.AsConfigItem(keyPath).ValueAsSecureString(defaultValue);
    }
}