using System;
using System.Collections.Generic;
using System.Linq;

namespace Autossential.Configuration.Core
{

    public static class ConfigSectionExtensions
    {
        public static string AsString(this ConfigSection section, string keyPath, string defaultValue) => ConfigItemExtensions.ValueAsString(section.GetItem(keyPath), defaultValue);
        public static int AsInt(this ConfigSection section, string keyPath, int defaultValue) => ConfigItemExtensions.ValueAsInt(section.GetItem(keyPath), defaultValue);
        public static double AsDouble(this ConfigSection section, string keyPath, double defaultValue) => ConfigItemExtensions.ValueAsDouble(section.GetItem(keyPath), defaultValue);
        public static decimal AsDecimal(this ConfigSection section, string keyPath, decimal defaultValue) => ConfigItemExtensions.ValueAsDecimal(section.GetItem(keyPath), defaultValue);
        public static float AsFloat(this ConfigSection section, string keyPath, float defaultValue) => ConfigItemExtensions.ValueAsFloat(section.GetItem(keyPath), defaultValue);
        public static long AsLong(this ConfigSection section, string keyPath, long defaultValue) => ConfigItemExtensions.ValueAsLong(section.GetItem(keyPath), defaultValue);
        public static DateTime AsDateTime(this ConfigSection section, string keyPath, DateTime defaultValue) => ConfigItemExtensions.ValueAsDateTime(section.GetItem(keyPath), defaultValue);
        public static bool AsBoolean(this ConfigSection section, string keyPath, bool defaultValue) => ConfigItemExtensions.ValueAsBoolean(section.GetItem(keyPath), defaultValue);
        public static T[] AsArray<T>(this ConfigSection section, string keyPath, T[] defaultValue) => ConfigItemExtensions.ValueAsArray(section.GetItem(keyPath), defaultValue);
        public static object[] AsArray(this ConfigSection section, string keyPath, object[] defaultValue) => ConfigItemExtensions.ValueAsArray(section.GetItem(keyPath), defaultValue);
        public static List<T> AsList<T>(this ConfigSection section, string keyPath, List<T> defaultValue) => ConfigItemExtensions.ValueAsList(section.GetItem(keyPath), defaultValue);
        public static List<object> AsList(this ConfigSection section, string keyPath, List<object> defaultValue) => ConfigItemExtensions.ValueAsList(section.GetItem(keyPath), defaultValue);
        public static IEnumerable<ConfigItem> Traverse(this ConfigSection section)
        {
            foreach (var item in section.Items)
            {
                yield return item;
                if (item.Value is ConfigSection config)
                {
                    foreach (var subItem in config.Traverse())
                        yield return subItem;
                }
            }
        }
        public static IEnumerable<KeyValuePair<string, object>> Inspect(this ConfigSection section)
        {
            foreach (var item in section.Items)
            {
                if (item.Value is ConfigSection config)
                {
                    foreach (var subItem in config.Inspect())
                        yield return subItem;
                }
                else
                {
                    yield return new KeyValuePair<string, object>((section.UniqueName + ConfigSection.DELIMITER + item.Key).TrimStart(ConfigSection.DELIMITER), item.Value);
                }                
            }
        }
        public static IEnumerable<ConfigItem> SkipValueSections(this IEnumerable<ConfigItem> items)
        {
            foreach (var item in items.Where(p => !(p.Value is ConfigSection)))
                yield return item;
        }

        public static IEnumerable<ConfigItem> OnlyValueSections(this IEnumerable<ConfigItem> items)
        {
            foreach (var item in items.Where(p => p.Value is ConfigSection))
                yield return item;
        }

        public static string AsString(this ConfigSection section, string keyPath) => AsString(section, keyPath, default);
        public static int AsInt(this ConfigSection section, string keyPath) => AsInt(section, keyPath, default);
        public static double AsDouble(this ConfigSection section, string keyPath) => AsDouble(section, keyPath, default);
        public static decimal AsDecimal(this ConfigSection section, string keyPath) => AsDecimal(section, keyPath, default);
        public static float AsFloat(this ConfigSection section, string keyPath) => AsFloat(section, keyPath, default);
        public static long AsLong(this ConfigSection section, string keyPath) => AsLong(section, keyPath, default);
        public static DateTime AsDateTime(this ConfigSection section, string keyPath) => AsDateTime(section, keyPath, default);
        public static bool AsBoolean(this ConfigSection section, string keyPath) => AsBoolean(section, keyPath, default);
        public static T[] AsArray<T>(this ConfigSection section, string keyPath) => AsArray<T>(section, keyPath, default);
        public static object[] AsArray(this ConfigSection section, string keyPath) => AsArray(section, keyPath, default);
        public static List<T> AsList<T>(this ConfigSection section, string keyPath) => AsList<T>(section, keyPath, default);
        public static List<object> AsList(this ConfigSection section, string keyPath) => AsList(section, keyPath, default);
    }
}