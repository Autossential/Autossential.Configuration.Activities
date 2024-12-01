using System;
using System.Collections.Generic;
using System.Security;
using System.Text.RegularExpressions;

namespace Autossential.Configuration.Core
{
    public static class ConfigSectionExtensions
    {
        public static T[] AsArray<T>(this ConfigSection section, string keyPath, T[] defaultValue) => section.AsConfigItem(keyPath).ValueAsArray(defaultValue);
        public static T[] AsArray<T>(this ConfigSection section, string keyPath) => section.AsArray<T>(keyPath, new T[0]);

        public static bool AsBoolean(this ConfigSection section, string keyPath, bool defaultValue) => section.AsConfigItem(keyPath).ValueAsBoolean(defaultValue);
        public static bool AsBoolean(this ConfigSection section, string keyPath) => section.AsBoolean(keyPath, default);

        public static DateTime AsDateTime(this ConfigSection section, string keyPath, DateTime defaultValue) => section.AsConfigItem(keyPath).ValueAsDateTime(defaultValue);
        public static DateTime AsDateTime(this ConfigSection section, string keyPath) => section.AsDateTime(keyPath, default(DateTime));
        public static DateTime AsDateTime(this ConfigSection section, string keyPath, IFormatProvider provider, DateTime defaultValue) => section.AsConfigItem(keyPath).ValueAsDateTime(provider, defaultValue);
        public static DateTime AsDateTime(this ConfigSection section, string keyPath, IFormatProvider provider) => section.AsDateTime(keyPath, provider, default);

        public static decimal AsDecimal(this ConfigSection section, string keyPath, decimal defaultValue) => section.AsConfigItem(keyPath).ValueAsDecimal(defaultValue);
        public static decimal AsDecimal(this ConfigSection section, string keyPath) => section.AsDecimal(keyPath, default(decimal));
        public static decimal AsDecimal(this ConfigSection section, string keyPath, IFormatProvider provider, decimal defaultValue) => section.AsConfigItem(keyPath).ValueAsDecimal(provider, defaultValue);
        public static decimal AsDecimal(this ConfigSection section, string keyPath, IFormatProvider provider) => section.AsDecimal(keyPath, provider, default);

        public static double AsDouble(this ConfigSection section, string keyPath, double defaultValue) => section.AsConfigItem(keyPath).ValueAsDouble(defaultValue);
        public static double AsDouble(this ConfigSection section, string keyPath) => section.AsDouble(keyPath, default(double));
        public static double AsDouble(this ConfigSection section, string keyPath, IFormatProvider provider, double defaultValue) => section.AsConfigItem(keyPath).ValueAsDouble(provider, defaultValue);
        public static double AsDouble(this ConfigSection section, string keyPath, IFormatProvider provider) => section.AsDouble(keyPath, provider, default);

        public static float AsFloat(this ConfigSection section, string keyPath, float defaultValue) => section.AsConfigItem(keyPath).ValueAsFloat(defaultValue);
        public static float AsFloat(this ConfigSection section, string keyPath) => section.AsFloat(keyPath, default(float));
        public static float AsFloat(this ConfigSection section, string keyPath, IFormatProvider provider, float defaultValue) => section.AsConfigItem(keyPath).ValueAsFloat(provider, defaultValue);
        public static float AsFloat(this ConfigSection section, string keyPath, IFormatProvider provider) => section.AsFloat(keyPath, provider, default);

        public static int AsInt(this ConfigSection section, string keyPath, int defaultValue) => section.AsConfigItem(keyPath).ValueAsInt(defaultValue);
        public static int AsInt(this ConfigSection section, string keyPath) => section.AsInt(keyPath, default(int));
        public static int AsInt(this ConfigSection section, string keyPath, IFormatProvider provider, int defaultValue) => section.AsConfigItem(keyPath).ValueAsInt(provider, defaultValue);
        public static int AsInt(this ConfigSection section, string keyPath, IFormatProvider provider) => section.AsInt(keyPath, provider, default);

        public static List<T> AsList<T>(this ConfigSection section, string keyPath, List<T> defaultValue) => section.AsConfigItem(keyPath).ValueAsList(defaultValue);
        public static List<T> AsList<T>(this ConfigSection section, string keyPath) => section.AsList<T>(keyPath, default);

        public static long AsLong(this ConfigSection section, string keyPath, long defaultValue) => section.AsConfigItem(keyPath).ValueAsLong(defaultValue);
        public static long AsLong(this ConfigSection section, string keyPath) => section.AsLong(keyPath, default(long));
        public static long AsLong(this ConfigSection section, string keyPath, IFormatProvider provider, long defaultValue) => section.AsConfigItem(keyPath).ValueAsLong(provider, defaultValue);
        public static long AsLong(this ConfigSection section, string keyPath, IFormatProvider provider) => section.AsLong(keyPath, provider, default);

        public static Regex AsRegex(this ConfigSection section, string keyPath, Regex defaultValue) => section.AsConfigItem(keyPath).ValueAsRegex(defaultValue);
        public static Regex AsRegex(this ConfigSection section, string keyPath) => section.AsRegex(keyPath, default(Regex));
        public static Regex AsRegex(this ConfigSection section, string keyPath, RegexOptions options, Regex defaultValue) => section.AsConfigItem(keyPath).ValueAsRegex(options, defaultValue);
        public static Regex AsRegex(this ConfigSection section, string keyPath, RegexOptions options) => section.AsRegex(keyPath, options, default);

        public static SecureString AsSecureString(this ConfigSection section, string keyPath, SecureString defaultValue) => section.AsConfigItem(keyPath).ValueAsSecureString(defaultValue);
        public static SecureString AsSecureString(this ConfigSection section, string keyPath) => section.AsSecureString(keyPath, default);

        public static string AsString(this ConfigSection section, string keyPath, string defaultValue) => section.AsConfigItem(keyPath).ValueAsString(defaultValue);
        public static string AsString(this ConfigSection section, string keyPath) => section.AsString(keyPath, default);
    }
}