using System.Collections.Generic;

namespace Hgk.Zero.Strings.Query
{
    public static class EnumerableToString
    {
        public static string ConcatToString<T>(this IEnumerable<T> values) =>
            string.Concat(values);

        public static string ConcatToString(this string[] values) =>
            string.Concat(values);

        public static string ConcatToString(this IEnumerable<string> values) =>
            string.Concat(values);

        public static string ConcatToString(this object[] values) =>
            string.Concat(values);

        public static string JoinToString(this IEnumerable<string> values, string separator) =>
            string.Join(separator, values);

        public static string JoinToString(this object[] values, string separator) =>
            string.Join(separator, values);

        public static string JoinToString(this string[] values, string separator) =>
            string.Join(separator, values);

        public static string JoinToString(this string[] values, int startIndex, int count, string separator) =>
            string.Join(separator, values, startIndex, count);

        public static string JoinToString<T>(this IEnumerable<T> values, string separator) =>
            string.Join(separator, values);
    }
}