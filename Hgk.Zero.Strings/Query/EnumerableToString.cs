using System;
using System.Collections.Generic;

namespace Hgk.Zero.Strings.Query
{
    /// <summary>
    /// Extension method equivalents to static methods from <see cref="string"/> that apply to enumerables.
    /// </summary>
    public static class EnumerableToString
    {
        /// <summary>
        /// Concatenates the string representations of the elements of a sequence.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Concat{T}(IEnumerable{T})"/>.</para>
        /// </remarks>
        /// <typeparam name="T">The type of the members of <paramref name="values"/>.</typeparam>
        /// <param name="values">The values to concatenate.</param>
        /// <returns>
        /// The concatenation of the string representations of the values in <paramref name="values"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string ConcatToString<T>(this IEnumerable<T> values) =>
            string.Concat(values);

        /// <summary>
        /// Concatenates the elements of a string array.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Concat(string[])"/>.</para>
        /// </remarks>
        /// <param name="values">The string values to concatenate.</param>
        /// <returns>The concatenation of the values in <paramref name="values"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string ConcatToString(this string[] values) =>
            string.Concat(values);

        /// <summary>
        /// Concatenates the elements of a string sequence.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Concat(IEnumerable{string})"/>.</para>
        /// </remarks>
        /// <param name="values">The string values to concatenate.</param>
        /// <returns>The concatenation of the values in <paramref name="values"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string ConcatToString(this IEnumerable<string> values) =>
            string.Concat(values);

        /// <summary>
        /// Concatenates the string representations of the elements of an array.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Concat(object[])"/>.</para>
        /// </remarks>
        /// <param name="values">The values to concatenate.</param>
        /// <returns>
        /// The concatenation of the string representations of the values in <paramref name="values"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string ConcatToString(this object[] values) =>
            string.Concat(values);

        /// <summary>
        /// Concatenates the elements of a string sequence using the specified string as a separator.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Join(string, IEnumerable{string})"/>.</para>
        /// </remarks>
        /// <param name="values">The string values to concatenate.</param>
        /// <param name="separator">
        /// A string to use as a separator. (If <see langword="null"/>, an empty string is used.)
        /// </param>
        /// <returns>
        /// The concatenation of the values in <paramref name="values"/>, delimited by <paramref
        /// name="separator"/>, if <paramref name="values"/> contains any elements; otherwise, an
        /// empty string.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string JoinToString(this IEnumerable<string> values, string separator) =>
            string.Join(separator, values);

        /// <summary>
        /// Concatenates the string representation of the elements of an array using the specified
        /// string as a separator.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Join(string, object[])"/>.</para>
        /// </remarks>
        /// <param name="values">The values to concatenate.</param>
        /// <param name="separator">
        /// A string to use as a separator. (If <see langword="null"/>, an empty string is used.)
        /// </param>
        /// <returns>
        /// The concatenation of the string representations of the values in <paramref
        /// name="values"/>, delimited by <paramref name="separator"/>, if <paramref name="values"/>
        /// contains any elements; otherwise, an empty string.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string JoinToString(this object[] values, string separator) =>
            string.Join(separator, values);

        /// <summary>
        /// Concatenates the elements of a string array using the specified string as a separator.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Join(string, string[])"/>.</para>
        /// </remarks>
        /// <param name="values">The string values to concatenate.</param>
        /// <param name="separator">
        /// A string to use as a separator. (If <see langword="null"/>, an empty string is used.)
        /// </param>
        /// <returns>
        /// The concatenation of the values in <paramref name="values"/>, delimited by <paramref
        /// name="separator"/>, if <paramref name="values"/> contains any elements; otherwise, an
        /// empty string.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string JoinToString(this string[] values, string separator) =>
            string.Join(separator, values);

        /// <summary>
        /// Concatenates the specified elements of a string array using the specified string as a separator.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result of calling <see cref="String.Join(string, string[], int, int)"/>.
        /// </para>
        /// </remarks>
        /// <param name="values">An array containing strings to concatenate.</param>
        /// <param name="startIndex">The first index of <paramref name="values"/> to use.</param>
        /// <param name="count">The number of elements of <paramref name="values"/> to use.</param>
        /// <param name="separator">
        /// A string to use as a separator. (If <see langword="null"/>, an empty string is used.)
        /// </param>
        /// <returns>
        /// The concatenation of the values in the specified range of <paramref name="values"/>,
        /// delimited by <paramref name="separator"/>, if the specified range contains any elements;
        /// otherwise, an empty string.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> or <paramref name="count"/> is less than 0, or <paramref
        /// name="startIndex"/> plus <paramref name="count"/> is greater than the length of values.
        /// </exception>
        public static string JoinToString(this string[] values, int startIndex, int count, string separator) =>
            string.Join(separator, values, startIndex, count);

        /// <summary>
        /// Concatenates the string representation of the elements of a sequence using the specified
        /// string as a separator.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Join{T}(string, IEnumerable{T})"/>.</para>
        /// </remarks>
        /// <typeparam name="T">The type of the members of <paramref name="values"/>.</typeparam>
        /// <param name="values">The values to concatenate.</param>
        /// <param name="separator">
        /// A string to use as a separator. (If <see langword="null"/>, an empty string is used.)
        /// </param>
        /// <returns>
        /// The concatenation of the string representations of the values in <paramref
        /// name="values"/>, delimited by <paramref name="separator"/>, if <paramref name="values"/>
        /// contains any elements; otherwise, an empty string.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string JoinToString<T>(this IEnumerable<T> values, string separator) =>
            string.Join(separator, values);
    }
}