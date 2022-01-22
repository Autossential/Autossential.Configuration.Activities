using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Autossential.Configuration.Core
{
    public static class ConfigItemExtensions
    {
        internal static T ValueAsType<T>(ConfigItem item, T defaultValue)
        {
            if (item?.Value == null) return defaultValue;
            if (item.Value is T value) return value;
            try
            {
                return (T)Convert.ChangeType(item.Value, typeof(T));
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return defaultValue;
            }
        }

        private static Converter<object, T> ConvertItem<T>()
        {
            return new Converter<object, T>(ChangeType<T>);
        }

        private static T ChangeType<T>(object input)
        {
            if (input is T inputT) return inputT;
            return (T)Convert.ChangeType(input, typeof(T));
        }

        private static T FromCollection<T>(object value, Func<IEnumerable<object>, T> converter, T defaultValue)
        {
            if (value is IEnumerable<object> valueEnumerable)
                return converter(valueEnumerable);

            return defaultValue;
        }

        public static string ValueAsString(this ConfigItem item, string defaultValue = default)
        {
            if (item?.Value == null) return defaultValue;
            if (item.Value is string value) return value;
            return item.Value.ToString();
        }

        public static int ValueAsInt(this ConfigItem item, int defaultValue = default) => ValueAsType(item, defaultValue);
        public static double ValueAsDouble(this ConfigItem item, double defaultValue = default) => ValueAsType(item, defaultValue);
        public static decimal ValueAsDecimal(this ConfigItem item, decimal defaultValue = default) => ValueAsType(item, defaultValue);
        public static float ValueAsFloat(this ConfigItem item, float defaultValue = default) => ValueAsType(item, defaultValue);
        public static long ValueAsLong(this ConfigItem item, long defaultValue = default) => ValueAsType(item, defaultValue);
        public static DateTime ValueAsDateTime(this ConfigItem item, DateTime defaultValue = default) => ValueAsType(item, defaultValue);
        public static bool ValueAsBoolean(this ConfigItem item, bool defaultValue = default) => ValueAsType(item, defaultValue);
        public static T[] ValueAsArray<T>(this ConfigItem item, T[] defaultValue = default)
        {
            if (item?.Value == null) return defaultValue;
            if (item.Value is T[] value) return value;
            if (item.Value is object[] objArray)
            {
                try
                {
                    return Array.ConvertAll(objArray, ConvertItem<T>());
                }
                catch { }
            }
            return FromCollection(item.Value, items => Array.ConvertAll(items.ToArray(), ConvertItem<T>()), defaultValue);
        }
        public static object[] ValueAsArray(this ConfigItem item, object[] defaultValue = default) => ValueAsArray<object>(item, defaultValue);
        public static List<T> ValueAsList<T>(this ConfigItem item, List<T> defaultValue = null)
        {
            if (item?.Value == null) return defaultValue;
            if (item.Value is List<T> value) return value;
            if (item.Value is List<object> objList)
            {
                try
                {
                    return objList.ConvertAll(ChangeType<T>);
                }
                catch { }
            }
            return FromCollection(item.Value, items => items.ToList().ConvertAll(ChangeType<T>), defaultValue);
        }

        public static List<object> ValueAsList(this ConfigItem item, List<object> defaultValue = default) => ValueAsList<object>(item, defaultValue);
    }
}