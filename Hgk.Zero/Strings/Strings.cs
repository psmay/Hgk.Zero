using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// Extension method equivalents to static methods from <see cref="string"/>.
    /// </summary>
    public static class Strings
    {
        public static string Concat(this string str0, string str1, string str2) =>
            string.Concat(str0, str1, str2);

        public static string Concat<T>(this string str, IEnumerable<T> values)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Concat(values);
            }

            if (values == null) throw new ArgumentNullException(nameof(values));

            if (values is IEnumerable<object> objectValues)
            {
                return string.Concat(objectValues.Prepend(str));
            }
            else
            {
                return string.Concat(values.Cast<object>().Prepend(str));
            }
        }

        public static string Concat(this string str, params string[] values)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Concat(values);
            }

            if (values == null) throw new ArgumentNullException(nameof(values));

            IEnumerable<string> valuesEnumerable = values;
            return Concat(str, valuesEnumerable);
        }

        public static string Concat(this string str0, string str1, string str2, string str3) =>
            string.Concat(str0, str1, str2, str3);

        public static string Concat(this string str0, string str1) =>
            string.Concat(str0, str1);

        public static string Concat(this string str, object arg0, object arg1, object arg2) =>
            string.Concat(str, string.Concat(arg0, arg1, arg2));

        public static string Concat(this string str, object arg0, object arg1) =>
            string.Concat(str, arg0, arg1);

        public static string Concat(this string str, object arg0) =>
            string.Concat(str, arg0);

        public static string Concat(this string str, IEnumerable<string> values)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Concat(values);
            }

            if (values == null) throw new ArgumentNullException(nameof(values));

            return string.Concat(values.Prepend(str));
        }

        public static string Concat(this string str, params object[] args)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Concat(args);
            }

            if (args == null) throw new ArgumentNullException(nameof(args));

            IEnumerable<object> valuesEnumerable = args;
            return Concat(str, valuesEnumerable);
        }

        public static string Format(this string format, params object[] args) =>
            string.Format(format, args);

        public static string Format(this string format, object arg0, object arg1, object arg2) =>
            string.Format(format, arg0, arg1, arg2);

        public static string Format(this string format, object arg0, object arg1) =>
            string.Format(format, arg0, arg1);

        public static string Format(this string format, object arg0) =>
            string.Format(format, arg0);

        public static string FormatWithProvider(this string format, IFormatProvider provider, params object[] args) =>
            string.Format(provider, format, args);

        public static string FormatWithProvider(this string format, IFormatProvider provider, object arg0, object arg1, object arg2) =>
            string.Format(provider, format, arg0, arg1, arg2);

        public static string FormatWithProvider(this string format, IFormatProvider provider, object arg0, object arg1) =>
            string.Format(provider, format, arg0, arg1);

        public static string FormatWithProvider(this string format, IFormatProvider provider, object arg0) =>
            string.Format(provider, format, arg0);

        public static string Intern(this string str) =>
            string.Intern(str);

        public static string IsInterned(this string str) =>
            string.IsInterned(str);

        public static bool IsNullOrEmpty(this string value) =>
            string.IsNullOrEmpty(value);

        public static bool IsNullOrWhiteSpace(this string value) =>
            string.IsNullOrWhiteSpace(value);

        public static string Join(this string separator, IEnumerable<string> values) =>
            string.Join(separator, values);

        public static string Join(this string separator, params object[] values) =>
            string.Join(separator, values);

        public static string Join(this string separator, params string[] value) =>
            string.Join(separator, value);

        public static string Join(this string separator, string[] value, int startIndex, int count) =>
            string.Join(separator, value, startIndex, count);

        public static string Join<T>(this string separator, IEnumerable<T> values) =>
            string.Join(separator, values);
    }
}