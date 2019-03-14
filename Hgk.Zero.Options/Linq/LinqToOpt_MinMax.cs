using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        #region Max

        /// <summary>
        /// Returns the maximum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static int Max(this IOpt<int> source) => Extremum(source);

        /// <summary>
        /// Returns the maximum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static int? Max(this IOpt<int?> source) => Extremum(source);

        /// <summary>
        /// Returns the maximum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static long Max(this IOpt<long> source) => Extremum(source);

        /// <summary>
        /// Returns the maximum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static long? Max(this IOpt<long?> source) => Extremum(source);

        /// <summary>
        /// Returns the maximum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static float Max(this IOpt<float> source) => Extremum(source);

        /// <summary>
        /// Returns the maximum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static float? Max(this IOpt<float?> source) => Extremum(source);

        /// <summary>
        /// Returns the maximum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static double Max(this IOpt<double> source) => Extremum(source);

        /// <summary>
        /// Returns the maximum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static double? Max(this IOpt<double?> source) => Extremum(source);

        /// <summary>
        /// Returns the maximum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static decimal Max(this IOpt<decimal> source) => Extremum(source);

        /// <summary>
        /// Returns the maximum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static decimal? Max(this IOpt<decimal?> source) => Extremum(source);

        /// <summary>
        /// Returns the maximum value in an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>, if <see langword="null"/> is an allowed value
        /// for <typeparamref name="TSource"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="source"/> is empty and <see langword="null"/> is not an allowed value for
        /// <typeparamref name="TSource"/>.
        /// </exception>
        public static TSource Max<TSource>(this IOpt<TSource> source) => Extremum(source);

        /// <summary>
        /// Returns the maximum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static int Max<TSource>(this IOpt<TSource> source, Func<TSource, int> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the maximum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static int? Max<TSource>(this IOpt<TSource> source, Func<TSource, int?> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the maximum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static long Max<TSource>(this IOpt<TSource> source, Func<TSource, long> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the maximum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static long? Max<TSource>(this IOpt<TSource> source, Func<TSource, long?> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the maximum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static float Max<TSource>(this IOpt<TSource> source, Func<TSource, float> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the maximum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static float? Max<TSource>(this IOpt<TSource> source, Func<TSource, float?> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the maximum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static double Max<TSource>(this IOpt<TSource> source, Func<TSource, double> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the maximum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static double? Max<TSource>(this IOpt<TSource> source, Func<TSource, double?> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the maximum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static decimal Max<TSource>(this IOpt<TSource> source, Func<TSource, decimal> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the maximum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static decimal? Max<TSource>(this IOpt<TSource> source, Func<TSource, decimal?> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the maximum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see
        /// langword="null"/>, if <see langword="null"/> is an allowed value for <typeparamref name="TResult"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="source"/> is empty and <see langword="null"/> is not an allowed value for
        /// <typeparamref name="TResult"/>.
        /// </exception>
        public static TResult Max<TSource, TResult>(this IOpt<TSource> source, Func<TSource, TResult> selector) => Extremum(source, selector);

        #endregion Max

        #region Min

        /// <summary>
        /// Returns the minimum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static int Min(this IOpt<int> source) => Extremum(source);

        /// <summary>
        /// Returns the minimum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static int? Min(this IOpt<int?> source) => Extremum(source);

        /// <summary>
        /// Returns the minimum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static long Min(this IOpt<long> source) => Extremum(source);

        /// <summary>
        /// Returns the minimum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static long? Min(this IOpt<long?> source) => Extremum(source);

        /// <summary>
        /// Returns the minimum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static float Min(this IOpt<float> source) => Extremum(source);

        /// <summary>
        /// Returns the minimum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static float? Min(this IOpt<float?> source) => Extremum(source);

        /// <summary>
        /// Returns the minimum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static double Min(this IOpt<double> source) => Extremum(source);

        /// <summary>
        /// Returns the minimum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static double? Min(this IOpt<double?> source) => Extremum(source);

        /// <summary>
        /// Returns the minimum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>The only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static decimal Min(this IOpt<decimal> source) => Extremum(source);

        /// <summary>
        /// Returns the minimum value in an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static decimal? Min(this IOpt<decimal?> source) => Extremum(source);

        /// <summary>
        /// Returns the minimum value in an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, if <paramref name="source"/> contains a
        /// value; otherwise, <see langword="null"/>, if <see langword="null"/> is an allowed value
        /// for <typeparamref name="TSource"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="source"/> is empty and <see langword="null"/> is not an allowed value for
        /// <typeparamref name="TSource"/>.
        /// </exception>
        public static TSource Min<TSource>(this IOpt<TSource> source) => Extremum(source);

        /// <summary>
        /// Returns the minimum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static int Min<TSource>(this IOpt<TSource> source, Func<TSource, int> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the minimum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static int? Min<TSource>(this IOpt<TSource> source, Func<TSource, int?> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the minimum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static long Min<TSource>(this IOpt<TSource> source, Func<TSource, long> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the minimum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static long? Min<TSource>(this IOpt<TSource> source, Func<TSource, long?> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the minimum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static float Min<TSource>(this IOpt<TSource> source, Func<TSource, float> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the minimum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static float? Min<TSource>(this IOpt<TSource> source, Func<TSource, float?> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the minimum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static double Min<TSource>(this IOpt<TSource> source, Func<TSource, double> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the minimum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static double? Min<TSource>(this IOpt<TSource> source, Func<TSource, double?> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the minimum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static decimal Min<TSource>(this IOpt<TSource> source, Func<TSource, decimal> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the minimum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see langword="null"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static decimal? Min<TSource>(this IOpt<TSource> source, Func<TSource, decimal?> selector) => Extremum(source, selector);

        /// <summary>
        /// Returns the minimum value in the projection of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// The result of applying <paramref name="selector"/> to the only element of <paramref
        /// name="source"/>, if <paramref name="source"/> contains a value; otherwise, <see
        /// langword="null"/>, if <see langword="null"/> is an allowed value for <typeparamref name="TResult"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="source"/> is empty and <see langword="null"/> is not an allowed value for
        /// <typeparamref name="TResult"/>.
        /// </exception>
        public static TResult Min<TSource, TResult>(this IOpt<TSource> source, Func<TSource, TResult> selector) => Extremum(source, selector);

        #endregion Min

        #region Extremum

        private static int Extremum(IOpt<int> source) => source.Single();

        private static int? Extremum(IOpt<int?> source) => source.SingleOrDefault();

        private static long Extremum(IOpt<long> source) => source.Single();

        private static long? Extremum(IOpt<long?> source) => source.SingleOrDefault();

        private static float Extremum(IOpt<float> source) => source.Single();

        private static float? Extremum(IOpt<float?> source) => source.SingleOrDefault();

        private static double Extremum(IOpt<double> source) => source.Single();

        private static double? Extremum(IOpt<double?> source) => source.SingleOrDefault();

        private static decimal Extremum(IOpt<decimal> source) => source.Single();

        private static decimal? Extremum(IOpt<decimal?> source) => source.SingleOrDefault();

        // The proper response for Min() or Max() for an arbitrary unknown type.
        // If the source is empty and the type is non-nullable, throw a No-Elements exception.
        // If the source is empty and the type is nullable, return null.
        // Otherwise, return the contained value (even if it is null).
        private static TSource Extremum<TSource>(IOpt<TSource> source) => default(TSource) == null ? source.SingleOrDefault() : source.Single();

        private static int Extremum<TSource>(IOpt<TSource> source, Func<TSource, int> selector) => Extremum(source.Select(selector));

        private static int? Extremum<TSource>(IOpt<TSource> source, Func<TSource, int?> selector) => Extremum(source.Select(selector));

        private static long Extremum<TSource>(IOpt<TSource> source, Func<TSource, long> selector) => Extremum(source.Select(selector));

        private static long? Extremum<TSource>(IOpt<TSource> source, Func<TSource, long?> selector) => Extremum(source.Select(selector));

        private static float Extremum<TSource>(IOpt<TSource> source, Func<TSource, float> selector) => Extremum(source.Select(selector));

        private static float? Extremum<TSource>(IOpt<TSource> source, Func<TSource, float?> selector) => Extremum(source.Select(selector));

        private static double Extremum<TSource>(IOpt<TSource> source, Func<TSource, double> selector) => Extremum(source.Select(selector));

        private static double? Extremum<TSource>(IOpt<TSource> source, Func<TSource, double?> selector) => Extremum(source.Select(selector));

        private static decimal Extremum<TSource>(IOpt<TSource> source, Func<TSource, decimal> selector) => Extremum(source.Select(selector));

        private static decimal? Extremum<TSource>(IOpt<TSource> source, Func<TSource, decimal?> selector) => Extremum(source.Select(selector));

        private static TResult Extremum<TSource, TResult>(IOpt<TSource> source, Func<TSource, TResult> selector) => Extremum(source.Select(selector));

        #endregion Extremum
    }
}