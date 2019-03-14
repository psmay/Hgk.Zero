using System;
using System.Collections.Generic;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Sorts the elements of an option in ascending order.
        /// </summary>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, is trivially already
        /// ordered, this method returns <paramref name="source"/> unmodified (after <see
        /// langword="null"/>-checking any required parameters).
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to compare elements.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <returns><paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> OrderBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector) => source.OrderByNoop(keySelector);

        /// <summary>
        /// Sorts the elements of an option in ascending order.
        /// </summary>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, is trivially already
        /// ordered, this method returns <paramref name="source"/> unmodified (after <see
        /// langword="null"/>-checking any required parameters).
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to compare elements.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <param name="comparer">A comparer used to order keys. (This parameter is ignored.)</param>
        /// <returns><paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> OrderBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) => source.OrderByNoop(keySelector);

        /// <summary>
        /// Sorts the elements of an option in descending order.
        /// </summary>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, is trivially already
        /// ordered, this method returns <paramref name="source"/> unmodified (after <see
        /// langword="null"/>-checking any required parameters).
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to compare elements.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <returns><paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> OrderByDescending<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector) => source.OrderByNoop(keySelector);

        /// <summary>
        /// Sorts the elements of an option in descending order.
        /// </summary>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, is trivially already
        /// ordered, this method returns <paramref name="source"/> unmodified (after <see
        /// langword="null"/>-checking any required parameters).
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to compare elements.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <param name="comparer">A comparer used to order keys. (This parameter is ignored.)</param>
        /// <returns><paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> OrderByDescending<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) => source.OrderByNoop(keySelector);

        /// <summary>
        /// Subsequently sorts the elements of an already ordered option in ascending order.
        /// </summary>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, is trivially already
        /// ordered, this method returns <paramref name="source"/> unmodified (after <see
        /// langword="null"/>-checking any required parameters).
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to compare elements.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <returns><paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> ThenBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector) => source.OrderByNoop(keySelector);

        /// <summary>
        /// Subsequently sorts the elements of an already ordered option in ascending order.
        /// </summary>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, is trivially already
        /// ordered, this method returns <paramref name="source"/> unmodified (after <see
        /// langword="null"/>-checking any required parameters).
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to compare elements.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <param name="comparer">A comparer used to order keys. (This parameter is ignored.)</param>
        /// <returns><paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> ThenBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) => source.OrderByNoop(keySelector);

        /// <summary>
        /// Subsequently sorts the elements of an already ordered option in descending order.
        /// </summary>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, is trivially already
        /// ordered, this method returns <paramref name="source"/> unmodified (after <see
        /// langword="null"/>-checking any required parameters).
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to compare elements.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <returns><paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> ThenByDescending<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector) => source.OrderByNoop(keySelector);

        /// <summary>
        /// Subsequently sorts the elements of an already ordered option in descending order.
        /// </summary>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, is trivially already
        /// ordered, this method returns <paramref name="source"/> unmodified (after <see
        /// langword="null"/>-checking any required parameters).
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to compare elements.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <param name="comparer">A comparer used to order keys. (This parameter is ignored.)</param>
        /// <returns><paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> ThenByDescending<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) => source.OrderByNoop(keySelector);

        private static IOpt<TSource> OrderByNoop<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            return source;
        }
    }
}