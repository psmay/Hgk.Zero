using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// Extension method equivalents to static methods from <see cref="String"/>.
    /// </summary>
    public static class Strings
    {
        public static int Compare(this String strA, int indexA, String strB, int indexB, int length, bool ignoreCase) =>
            String.Compare(strA, indexA, strB, indexB, length, ignoreCase);

        public static int Compare(this String strA, int indexA, String strB, int indexB, int length) =>
            String.Compare(strA, indexA, strB, indexB, length);

        public static int Compare(this String strA, String strB, CultureInfo culture, CompareOptions options) =>
            String.Compare(strA, strB, culture, options);

        public static int Compare(this String strA, String strB, bool ignoreCase, CultureInfo culture) =>
            String.Compare(strA, strB, ignoreCase, culture);

        public static int Compare(this String strA, String strB, bool ignoreCase) =>
            String.Compare(strA, strB, ignoreCase);

        public static int Compare(this String strA, String strB, StringComparison comparisonType) =>
            String.Compare(strA, strB, comparisonType);

        public static int Compare(this String strA, int indexA, String strB, int indexB, int length, StringComparison comparisonType) =>
            String.Compare(strA, indexA, strB, indexB, length, comparisonType);

        public static int Compare(this String strA, int indexA, String strB, int indexB, int length, CultureInfo culture, CompareOptions options) =>
            String.Compare(strA, indexA, strB, indexB, length, culture, options);

        public static int Compare(this String strA, int indexA, String strB, int indexB, int length, bool ignoreCase, CultureInfo culture) =>
            String.Compare(strA, indexA, strB, indexB, length, ignoreCase, culture);

        public static int Compare(this String strA, String strB) =>
            String.Compare(strA, strB);

        public static int CompareOrdinal(this String strA, int indexA, String strB, int indexB, int length) =>
            String.CompareOrdinal(strA, indexA, strB, indexB, length);

        public static int CompareOrdinal(this String strA, String strB) =>
            String.CompareOrdinal(strA, strB);

        public static String Concat(this String str0, String str1, String str2) =>
            String.Concat(str0, str1, str2);

        public static String Concat<T>(this String str, IEnumerable<T> values) => String.Concat(str, String.Concat(values));

        public static String Concat(this String str, params String[] values) => String.Concat(str, String.Concat(values));

        public static String Concat(this String str0, String str1, String str2, String str3) =>
            String.Concat(str0, str1, str2, str3);

        public static String Concat(this String str0, String str1) =>
            String.Concat(str0, str1);

        public static String Concat(this String str, object arg0, object arg1, object arg2) => String.Concat(str, String.Concat(arg0, arg1, arg2));

        public static String Concat(this String str, object arg0, object arg1) => String.Concat(str, arg0, arg1);

        public static String Concat(this String str, object arg0) => String.Concat(str, arg0);

        public static String Concat(this String str, IEnumerable<String> values) => String.Concat(str, String.Concat(values));

        public static String Concat(this String str, params object[] args) => String.Concat(str, String.Concat(args));

        public static String Format(this String format, params object[] args) =>
            String.Format(format, args);

        public static String Format(this String format, object arg0, object arg1, object arg2) =>
            String.Format(format, arg0, arg1, arg2);

        public static String Format(this String format, object arg0, object arg1) =>
            String.Format(format, arg0, arg1);

        public static String Format(this String format, object arg0) =>
            String.Format(format, arg0);

        public static String FormatWithProvider(this String format, IFormatProvider provider, params object[] args) => String.Format(provider, format, args);

        public static String FormatWithProvider(this String format, IFormatProvider provider, object arg0, object arg1, object arg2) => String.Format(provider, format, arg0, arg1, arg2);

        public static String FormatWithProvider(this String format, IFormatProvider provider, object arg0, object arg1) => String.Format(provider, format, arg0, arg1);

        public static String FormatWithProvider(this String format, IFormatProvider provider, object arg0) => String.Format(provider, format, arg0);

        public static String Intern(this String str) =>
            String.Intern(str);

        public static String IsInterned(this String str) =>
            String.IsInterned(str);

        public static bool IsNullOrEmpty(this String value) =>
            String.IsNullOrEmpty(value);

        public static bool IsNullOrWhiteSpace(this String value) =>
            String.IsNullOrWhiteSpace(value);

        public static String Join(this String separator, IEnumerable<String> values) =>
            String.Join(separator, values);

        public static String Join(this String separator, params object[] values) =>
            String.Join(separator, values);

        public static String Join(this String separator, params String[] value) =>
            String.Join(separator, value);

        public static String Join(this String separator, String[] value, int startIndex, int count) =>
            String.Join(separator, value, startIndex, count);

        public static String Join<T>(this String separator, IEnumerable<T> values) =>
            String.Join<T>(separator, values);

    }
}
