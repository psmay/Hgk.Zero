using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Returns whether all elements of an option satisfy a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// <see langword="true"/>, if <paramref name="source"/> is empty or contains an element that
        /// satisfies <paramref name="predicate"/>; otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static bool All<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return opt.HasValue ? predicate(opt.ValueOrDefault) : true;
        }

        /// <summary>
        /// Returns whether an option contains any elements.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <returns><see langword="true"/> if <paramref name="source"/> contains an element; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static bool Any<TSource>(this IOpt<TSource> source) => source.ToFixed().HasValue;

        /// <summary>
        /// Returns whether any element of an option satisfies a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// <see langword="true"/>, if <paramref name="source"/> contains an element that satisfies
        /// <paramref name="predicate"/>; otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static bool Any<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return opt.HasValue ? predicate(opt.ValueOrDefault) : false;
        }

        /// <summary>
        /// Returns the number of elements in an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <returns>1 if <paramref name="source"/> contains an element; otherwise, 0.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static int Count<TSource>(this IOpt<TSource> source) => source.Any() ? 1 : 0;

        /// <summary>
        /// Returns the number of elements of an option that satisfy a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// 1, if <paramref name="source"/> contains an element that satisfies <paramref
        /// name="predicate"/>; otherwise, 0.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static int Count<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Any(predicate) ? 1 : 0;

        /// <summary>
        /// Returns the number of elements in an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <returns>1 if <paramref name="source"/> contains an element; otherwise, 0.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static long LongCount<TSource>(this IOpt<TSource> source) => source.Count();

        /// <summary>
        /// Returns the number of elements of an option that satisfy a predicate.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// 1, if <paramref name="source"/> contains an element that satisfies <paramref
        /// name="predicate"/>; otherwise, 0.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static long LongCount<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Count(predicate);
    }
}