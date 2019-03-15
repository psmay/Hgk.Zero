using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Computes the sum of the contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, or zero if <paramref
        /// name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static int Sum(this IOpt<int> source) => source.SingleOrDefault();

        /// <summary>
        /// Computes the sum of the non-null contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, or zero if <paramref
        /// name="source"/> is empty or contains <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static int? Sum(this IOpt<int?> source) => source.NonNullSingleOrDefault();

        /// <summary>
        /// Computes the sum of the contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, or zero if <paramref
        /// name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static long Sum(this IOpt<long> source) => source.SingleOrDefault();

        /// <summary>
        /// Computes the sum of the non-null contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, or zero if <paramref
        /// name="source"/> is empty or contains <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static long? Sum(this IOpt<long?> source) => source.NonNullSingleOrDefault();

        /// <summary>
        /// Computes the sum of the contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, or zero if <paramref
        /// name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static float Sum(this IOpt<float> source) => source.SingleOrDefault();

        /// <summary>
        /// Computes the sum of the non-null contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, or zero if <paramref
        /// name="source"/> is empty or contains <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static float? Sum(this IOpt<float?> source) => source.NonNullSingleOrDefault();

        /// <summary>
        /// Computes the sum of the contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, or zero if <paramref
        /// name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static double Sum(this IOpt<double> source) => source.SingleOrDefault();

        /// <summary>
        /// Computes the sum of the non-null contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, or zero if <paramref
        /// name="source"/> is empty or contains <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static double? Sum(this IOpt<double?> source) => source.NonNullSingleOrDefault();

        /// <summary>
        /// Computes the sum of the contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, or zero if <paramref
        /// name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static decimal Sum(this IOpt<decimal> source) => source.SingleOrDefault();

        /// <summary>
        /// Computes the sum of the non-null contents of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The value of the only element of <paramref name="source"/>, or zero if <paramref
        /// name="source"/> is empty or contains <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static decimal? Sum(this IOpt<decimal?> source) => source.NonNullSingleOrDefault();

        /// <summary>
        /// Computes the sum of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, or zero if <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static int Sum<TSource>(this IOpt<TSource> source, Func<TSource, int> selector) => Sum(source.Select(selector));

        /// <summary>
        /// Computes the sum of the non-null elements of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, <paramref name="source"/> contains a value and that result is
        /// not <see langword="null"/>; otherwise, zero.
        /// </returns>
        public static int? Sum<TSource>(this IOpt<TSource> source, Func<TSource, int?> selector) => Sum(source.Select(selector));

        /// <summary>
        /// Computes the sum of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, or zero if <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static long Sum<TSource>(this IOpt<TSource> source, Func<TSource, long> selector) => Sum(source.Select(selector));

        /// <summary>
        /// Computes the sum of the non-null elements of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, <paramref name="source"/> contains a value and that result is
        /// not <see langword="null"/>; otherwise, zero.
        /// </returns>
        public static long? Sum<TSource>(this IOpt<TSource> source, Func<TSource, long?> selector) => Sum(source.Select(selector));

        /// <summary>
        /// Computes the sum of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, or zero if <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static float Sum<TSource>(this IOpt<TSource> source, Func<TSource, float> selector) => Sum(source.Select(selector));

        /// <summary>
        /// Computes the sum of the non-null elements of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, <paramref name="source"/> contains a value and that result is
        /// not <see langword="null"/>; otherwise, zero.
        /// </returns>
        public static float? Sum<TSource>(this IOpt<TSource> source, Func<TSource, float?> selector) => Sum(source.Select(selector));

        /// <summary>
        /// Computes the sum of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, or zero if <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static double Sum<TSource>(this IOpt<TSource> source, Func<TSource, double> selector) => Sum(source.Select(selector));

        /// <summary>
        /// Computes the sum of the non-null elements of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, <paramref name="source"/> contains a value and that result is
        /// not <see langword="null"/>; otherwise, zero.
        /// </returns>
        public static double? Sum<TSource>(this IOpt<TSource> source, Func<TSource, double?> selector) => Sum(source.Select(selector));

        /// <summary>
        /// Computes the sum of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, or zero if <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static decimal Sum<TSource>(this IOpt<TSource> source, Func<TSource, decimal> selector) => Sum(source.Select(selector));

        /// <summary>
        /// Computes the sum of the non-null elements of a projection of the contents of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The value of the result of applying <paramref name="selector"/> to the only element of
        /// <paramref name="source"/>, <paramref name="source"/> contains a value and that result is
        /// not <see langword="null"/>; otherwise, zero.
        /// </returns>
        public static decimal? Sum<TSource>(this IOpt<TSource> source, Func<TSource, decimal?> selector) => Sum(source.Select(selector));

        /// <summary>
        /// A variant of SingleOrDefault() for nullable value types that returns the non-null default
        /// (i.e. zero) if the option is empty or contains a null value.
        /// </summary>
        private static TSource NonNullSingleOrDefault<TSource>(this IOpt<TSource?> source) where TSource : struct => source.SingleOrDefault() ?? default;
    }
}