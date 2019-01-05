using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Strings
{
    /// <summary>
    /// Extension method equivalents to static methods from <see cref="string"/>.
    /// </summary>
    public static class Strings
    {
        /// <summary>
        /// Concatenates a string to two other strings.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result of calling <see cref="string.Concat(string, string, string)"/>.
        /// </para>
        /// </remarks>
        /// <param name="str0">The first string value to concatenate.</param>
        /// <param name="str1">The second string value to concatenate.</param>
        /// <param name="str2">The third string value to concatenate.</param>
        /// <returns>
        /// The concatenation of <paramref name="str0"/>, <paramref name="str1"/>, and <paramref name="str2"/>.
        /// </returns>
        public static string Concat(this string str0, string str1, string str2) =>
            string.Concat(str0, str1, str2);

        /// <summary>
        /// Concatenates a string to the string representations of the elements of a sequence.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If <paramref name="str"/> is <see langword="null"/> or empty, this method returns the
        /// result of calling <see cref="string.Concat{T}(IEnumerable{T})"/>. Otherwise, <see
        /// cref="string.Concat{T}(IEnumerable{T})"/> is called on the result of converting <paramref
        /// name="values"/> to an <see cref="object"/> sequence and prepending <paramref name="str"/>
        /// to the sequence.
        /// </para>
        /// </remarks>
        /// <typeparam name="T">The type of the elements of <paramref name="values"/>.</typeparam>
        /// <param name="str">The first value to concatenate.</param>
        /// <param name="values">The other values to concatenate.</param>
        /// <returns>
        /// The concatenation of <paramref name="str"/> and the values in <paramref name="values"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
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

        /// <summary>
        /// Concatenates a string to the elements of a string array.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If <paramref name="str"/> is <see langword="null"/> or empty, this method returns the
        /// result of calling <see cref="string.Concat(string[])"/>. Otherwise, <see
        /// cref="string.Concat(IEnumerable{string})"/> is called on the result of prepending
        /// <paramref name="str"/> to <paramref name="values"/>.
        /// </para>
        /// </remarks>
        /// <param name="str">The first string value to concatenate.</param>
        /// <param name="values">The other string values to concatenate.</param>
        /// <returns>
        /// The concatenation of <paramref name="str"/> and the strings in <paramref name="values"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string Concat(this string str, params string[] values)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Concat(values);
            }

            if (values == null) throw new ArgumentNullException(nameof(values));

            return string.Concat(values.Prepend(str));
        }

        /// <summary>
        /// Concatenates a string to three other strings.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result of calling <see cref="string.Concat(string, string,
        /// string, string)"/>.
        /// </para>
        /// </remarks>
        /// <param name="str0">The first string value to concatenate.</param>
        /// <param name="str1">The second string value to concatenate.</param>
        /// <param name="str2">The third string value to concatenate.</param>
        /// <param name="str3">The fourth string value to concatenate.</param>
        /// <returns>
        /// The concatenation of <paramref name="str0"/>, <paramref name="str1"/>, <paramref
        /// name="str2"/>, and <paramref name="str3"/>.
        /// </returns>
        public static string Concat(this string str0, string str1, string str2, string str3) =>
            string.Concat(str0, str1, str2, str3);

        /// <summary>
        /// Concatenates a string to another string.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Concat(string, string)"/>.</para>
        /// </remarks>
        /// <param name="str0">The first string value to concatenate.</param>
        /// <param name="str1">The second string value to concatenate.</param>
        /// <returns>The concatenation of <paramref name="str0"/> and <paramref name="str1"/>.</returns>
        public static string Concat(this string str0, string str1) =>
            string.Concat(str0, str1);

        /// <summary>
        /// Concatenates a string to the string representations of three other objects.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method concatenates str to the result of calling <see cref="string.Concat(object,
        /// object, object)"/>.
        /// </para>
        /// </remarks>
        /// <param name="str">The first value to concatenate.</param>
        /// <param name="arg0">The second value to concatenate.</param>
        /// <param name="arg1">The third value to concatenate.</param>
        /// <param name="arg2">The fourth value to concatenate.</param>
        /// <returns>
        /// The concatenation of <paramref name="str"/>, <paramref name="arg0"/>, <paramref
        /// name="arg1"/>, and <paramref name="arg2"/>.
        /// </returns>
        public static string Concat(this string str, object arg0, object arg1, object arg2) =>
            string.Concat(str, string.Concat(arg0, arg1, arg2));

        /// <summary>
        /// Concatenates a string to the string representations of two other objects.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result of calling <see cref="string.Concat(object, object, object)"/>.
        /// </para>
        /// </remarks>
        /// <param name="str">The first value to concatenate.</param>
        /// <param name="arg0">The second value to concatenate.</param>
        /// <param name="arg1">The third value to concatenate.</param>
        /// <returns>
        /// The concatenation of <paramref name="str"/>, <paramref name="arg0"/>, and <paramref name="arg1"/>.
        /// </returns>
        public static string Concat(this string str, object arg0, object arg1) =>
            string.Concat(str, arg0, arg1);

        /// <summary>
        /// Concatenates a string to the string representations of another object.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Concat(object, object)"/>.</para>
        /// </remarks>
        /// <param name="str">The first value to concatenate.</param>
        /// <param name="arg0">The second value to concatenate.</param>
        /// <returns>The concatenation of <paramref name="str"/> and <paramref name="arg0"/>.</returns>
        public static string Concat(this string str, object arg0) =>
            string.Concat(str, arg0);

        /// <summary>
        /// Concatenates a string to the elements of a string sequence.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If <paramref name="str"/> is <see langword="null"/> or empty, this method returns the
        /// result of calling <see cref="string.Concat(IEnumerable{string})"/>. Otherwise, <see
        /// cref="string.Concat(IEnumerable{string})"/> is called on the result of prepending
        /// <paramref name="str"/> to <paramref name="values"/>.
        /// </para>
        /// </remarks>
        /// <param name="str">The first value to concatenate.</param>
        /// <param name="values">The other values to concatenate.</param>
        /// <returns>
        /// The concatenation of <paramref name="str"/> and the strings in <paramref name="values"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string Concat(this string str, IEnumerable<string> values)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Concat(values);
            }

            if (values == null) throw new ArgumentNullException(nameof(values));

            return string.Concat(values.Prepend(str));
        }

        /// <summary>
        /// Concatenates a string to the string representations of the elements of an object array.
        /// </summary>
        /// <remarks>
        /// <para>
        /// If <paramref name="str"/> is <see langword="null"/> or empty, this method returns the
        /// result of calling <see cref="string.Concat(object[])"/>. Otherwise, <see
        /// cref="string.Concat{T}(IEnumerable{T})"/> is called on the result of prepending <paramref
        /// name="str"/> to <paramref name="args"/>.
        /// </para>
        /// </remarks>
        /// <param name="str">The first value to concatenate.</param>
        /// <param name="args">The other values to concatenate.</param>
        /// <returns>
        /// The concatenation of <paramref name="str"/> and the values in <paramref name="args"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="args"/> is <see langword="null"/>.</exception>
        public static string Concat(this string str, params object[] args)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Concat(args);
            }

            if (args == null) throw new ArgumentNullException(nameof(args));

            return string.Concat(args.Prepend(str));
        }

        /// <summary>
        /// Returns whether the specified string is <see langword="null"/> or empty (zero-length).
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.IsNullOrEmpty(string)"/>.</para>
        /// </remarks>
        /// <param name="value">A string to test.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> is <see langword="null"/> or a
        /// zero-length string; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsNullOrEmpty(this string value) =>
            string.IsNullOrEmpty(value);

        /// <summary>
        /// Returns whether the specified string is null, empty (zero-length), or contains only
        /// whitespace characters.
        /// </summary>
        /// <remarks>
        /// <para>
        /// A character is a whitespace character if the result of calling <see
        /// cref="char.IsWhiteSpace(char)"/> on the character is <see langword="true"/>.
        /// </para>
        /// <para>This method returns the result of <see cref="string.IsNullOrWhiteSpace(string)"/>.</para>
        /// </remarks>
        /// <param name="value">A string to test.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="value"/> is <see langword="null"/>, a
        /// zero-length string, or a string containing only whitespace characters; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool IsNullOrWhiteSpace(this string value) =>
            string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Concatenates the elements of a string sequence using the specified string as a separator.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Join(string, IEnumerable{string})"/>.</para>
        /// </remarks>
        /// <param name="separator">
        /// A string to use as a separator. (If <see langword="null"/>, an empty string is used.)
        /// </param>
        /// <param name="values">The strings to concatenate.</param>
        /// <returns>
        /// The concatenation of the values in <paramref name="values"/>, delimited by <paramref
        /// name="separator"/>, if <paramref name="values"/> contains any elements; otherwise, an
        /// empty string.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string Join(this string separator, IEnumerable<string> values) =>
            string.Join(separator, values);

        /// <summary>
        /// Concatenates the string representations of the elements of a sequence using the specified
        /// string as a separator.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Join{T}(string, IEnumerable{T})"/>.</para>
        /// </remarks>
        /// <typeparam name="T">The type of elements of <paramref name="values"/>.</typeparam>
        /// <param name="separator">
        /// A string to use as a separator. (If <see langword="null"/>, an empty string is used.)
        /// </param>
        /// <param name="values">The values to concatenate.</param>
        /// <returns>
        /// The concatenation of the string representations of the values in <paramref
        /// name="values"/>, delimited by <paramref name="separator"/>, if <paramref name="values"/>
        /// contains any elements; otherwise, an empty string.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string Join<T>(this string separator, IEnumerable<T> values) =>
            string.Join(separator, values);

        /// <summary>
        /// Concatenates the string representations of the elements of an array using the specified
        /// string as a separator.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Join(string, object[])"/>.</para>
        /// </remarks>
        /// <param name="separator">
        /// A string to use as a separator. (If <see langword="null"/>, an empty string is used.)
        /// </param>
        /// <param name="values">The values to concatenate.</param>
        /// <returns>
        /// The concatenation of the string representations of the values in <paramref
        /// name="values"/>, delimited by <paramref name="separator"/>, if <paramref name="values"/>
        /// contains any elements; otherwise, an empty string.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string Join(this string separator, params object[] values) =>
            string.Join(separator, values);

        /// <summary>
        /// Concatenates the specified elements of a string array using the specified string as a separator.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result of calling <see cref="string.Join(string, string[], int, int)"/>.
        /// </para>
        /// </remarks>
        /// <param name="separator">
        /// A string to use as a separator. (If <see langword="null"/>, an empty string is used.)
        /// </param>
        /// <param name="values">An array containing strings to concatenate.</param>
        /// <param name="startIndex">The first index of <paramref name="values"/> to use.</param>
        /// <param name="count">The number of elements of <paramref name="values"/> to use.</param>
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
        public static string Join(this string separator, string[] values, int startIndex, int count) =>
            string.Join(separator, values, startIndex, count);

        /// <summary>
        /// Concatenates the elements of a string array using the specified string as a separator.
        /// </summary>
        /// <remarks>
        /// <para>This method returns the result of calling <see cref="string.Join(string, string[])"/>.</para>
        /// </remarks>
        /// <param name="separator">
        /// A string to use as a separator. (If <see langword="null"/>, an empty string is used.)
        /// </param>
        /// <param name="values">The strings to concatenate.</param>
        /// <returns>
        /// The concatenation of the values in <paramref name="values"/>, delimited by <paramref
        /// name="separator"/>, if <paramref name="values"/> contains any elements; otherwise, an
        /// empty string.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="values"/> is <see langword="null"/>.</exception>
        public static string Join(this string separator, params string[] values) =>
            string.Join(separator, values);
    }
}