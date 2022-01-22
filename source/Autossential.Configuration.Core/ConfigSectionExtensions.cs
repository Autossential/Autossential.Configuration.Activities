using System;
using System.Collections.Generic;
using System.Linq;

namespace Autossential.Configuration.Core
{

    public static class ConfigSectionExtensions
    {
        public static string AsString(this ConfigSection section, string keyPath, string defaultValue = default)
            => ConfigItemExtensions.ValueAsString(section.AsConfigItem(keyPath), defaultValue);

        public static int AsInt(this ConfigSection section, string keyPath, int defaultValue = default)
            => ConfigItemExtensions.ValueAsInt(section.AsConfigItem(keyPath), defaultValue);

        public static double AsDouble(this ConfigSection section, string keyPath, double defaultValue = default)
            => ConfigItemExtensions.ValueAsDouble(section.AsConfigItem(keyPath), defaultValue);

        public static decimal AsDecimal(this ConfigSection section, string keyPath, decimal defaultValue = default)
            => ConfigItemExtensions.ValueAsDecimal(section.AsConfigItem(keyPath), defaultValue);

        public static float AsFloat(this ConfigSection section, string keyPath, float defaultValue = default)
            => ConfigItemExtensions.ValueAsFloat(section.AsConfigItem(keyPath), defaultValue);

        public static long AsLong(this ConfigSection section, string keyPath, long defaultValue = default)
            => ConfigItemExtensions.ValueAsLong(section.AsConfigItem(keyPath), defaultValue);

        public static DateTime AsDateTime(this ConfigSection section, string keyPath, DateTime defaultValue = default)
            => ConfigItemExtensions.ValueAsDateTime(section.AsConfigItem(keyPath), defaultValue);

        public static bool AsBoolean(this ConfigSection section, string keyPath, bool defaultValue = default)
              => ConfigItemExtensions.ValueAsBoolean(section.AsConfigItem(keyPath), defaultValue);

        public static T[] AsArray<T>(this ConfigSection section, string keyPath, T[] defaultValue = default)
            => ConfigItemExtensions.ValueAsArray(section.AsConfigItem(keyPath), defaultValue);

        public static object[] AsArray(this ConfigSection section, string keyPath, object[] defaultValue = default)
            => ConfigItemExtensions.ValueAsArray(section.AsConfigItem(keyPath), defaultValue);

        public static List<T> AsList<T>(this ConfigSection section, string keyPath, List<T> defaultValue = null)
            => ConfigItemExtensions.ValueAsList(section.AsConfigItem(keyPath), defaultValue);

        public static List<object> AsList(this ConfigSection section, string keyPath, List<object> defaultValue = default)
            => ConfigItemExtensions.ValueAsList(section.AsConfigItem(keyPath), defaultValue);

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
    }
}