using Hgk.Zero.Options.Try;
using System;
using System.Collections.Generic;

namespace Hgk.Zero.Options.Query
{
    /// <summary>
    /// Facility for retrieving a value from a set as an option.
    /// </summary>
    public static class SetToOpt
    {
        /// <summary>
        /// Searches the set for a given value and returns an option containing the equal value it finds.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in source.</typeparam>
        /// <param name="source">A source set.</param>
        /// <param name="equalValue">The value to search for.</param>
        /// <returns>
        /// An option containing the value from the set that the search found, or an empty option
        /// when the search yielded no match.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static Opt<TSource> GetValueOpt<TSource>(this HashSet<TSource> source, TSource equalValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return TryToOpt<TSource>.Call(source.TryGetValue, equalValue);
        }

        /// <summary>
        /// Searches the set for a given value and returns an option containing the equal value it finds.
        /// </summary>
        /// <typeparam name="TSource">The type of elements in source.</typeparam>
        /// <param name="source">A source set.</param>
        /// <param name="equalValue">The value to search for.</param>
        /// <returns>
        /// An option containing the value from the set that the search found, or an empty option
        /// when the search yielded no match.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>

        public static Opt<TSource> GetValueOpt<TSource>(this SortedSet<TSource> source, TSource equalValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return TryToOpt<TSource>.Call(source.TryGetValue, equalValue);
        }
    }
}