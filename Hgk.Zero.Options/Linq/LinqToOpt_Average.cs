using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Computes the average of the contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The value of the only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static double Average(this IOpt<int> source) => source.Single();

        /// <summary>
        /// Computes the average of the non-null contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, if <paramref name="source"/>
        /// contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static double? Average(this IOpt<int?> source) => source.SingleOrDefault();

        /// <summary>
        /// Computes the average of the contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The value of the only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static double Average(this IOpt<long> source) => source.Single();

        /// <summary>
        /// Computes the average of the non-null contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, if <paramref name="source"/>
        /// contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static double? Average(this IOpt<long?> source) => source.SingleOrDefault();

        /// <summary>
        /// Computes the average of the contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The value of the only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static float Average(this IOpt<float> source) => source.Single();

        /// <summary>
        /// Computes the average of the non-null contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, if <paramref name="source"/>
        /// contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static float? Average(this IOpt<float?> source) => source.SingleOrDefault();

        /// <summary>
        /// Computes the average of the contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The value of the only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static double Average(this IOpt<double> source) => source.Single();

        /// <summary>
        /// Computes the average of the non-null contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, if <paramref name="source"/>
        /// contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static double? Average(this IOpt<double?> source) => source.SingleOrDefault();

        /// <summary>
        /// Computes the average of the contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The value of the only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static decimal Average(this IOpt<decimal> source) => source.Single();

        /// <summary>
        /// Computes the average of the non-null contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, if <paramref name="source"/>
        /// contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static decimal? Average(this IOpt<decimal?> source) => source.SingleOrDefault();

        /// <summary>
        /// Computes the average of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static double Average<TSource>(this IOpt<TSource> source, Func<TSource, int> selector) => Average(source.Select(selector));

        /// <summary>
        /// Computes the average of the non-null elements of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        public static double? Average<TSource>(this IOpt<TSource> source, Func<TSource, int?> selector) => Average(source.Select(selector));

        /// <summary>
        /// Computes the average of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static double Average<TSource>(this IOpt<TSource> source, Func<TSource, long> selector) => Average(source.Select(selector));

        /// <summary>
        /// Computes the average of the non-null elements of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        public static double? Average<TSource>(this IOpt<TSource> source, Func<TSource, long?> selector) => Average(source.Select(selector));

        /// <summary>
        /// Computes the average of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static float Average<TSource>(this IOpt<TSource> source, Func<TSource, float> selector) => Average(source.Select(selector));

        /// <summary>
        /// Computes the average of the non-null elements of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        public static float? Average<TSource>(this IOpt<TSource> source, Func<TSource, float?> selector) => Average(source.Select(selector));

        /// <summary>
        /// Computes the average of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static double Average<TSource>(this IOpt<TSource> source, Func<TSource, double> selector) => Average(source.Select(selector));

        /// <summary>
        /// Computes the average of the non-null elements of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        public static double? Average<TSource>(this IOpt<TSource> source, Func<TSource, double?> selector) => Average(source.Select(selector));

        /// <summary>
        /// Computes the average of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static decimal Average<TSource>(this IOpt<TSource> source, Func<TSource, decimal> selector) => Average(source.Select(selector));

        /// <summary>
        /// Computes the average of the non-null elements of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        public static decimal? Average<TSource>(this IOpt<TSource> source, Func<TSource, decimal?> selector) => Average(source.Select(selector));
    }
}