using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <inheritdoc cref="Enumerable.Sum{TSource}(IEnumerable{TSource}, Func{TSource, int?})"/>
        public static int? Sum<TSource>(this IOpt<TSource> source, Func<TSource, int?> selector) => Sum(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Sum{TSource}(IEnumerable{TSource}, Func{TSource, int})"/>
        public static int Sum<TSource>(this IOpt<TSource> source, Func<TSource, int> selector) => Sum(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Sum{TSource}(IEnumerable{TSource}, Func{TSource, long})"/>
        public static long Sum<TSource>(this IOpt<TSource> source, Func<TSource, long> selector) => Sum(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Sum{TSource}(IEnumerable{TSource}, Func{TSource, decimal?})"/>
        public static decimal? Sum<TSource>(this IOpt<TSource> source, Func<TSource, decimal?> selector) => Sum(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Sum{TSource}(IEnumerable{TSource}, Func{TSource, float})"/>
        public static float Sum<TSource>(this IOpt<TSource> source, Func<TSource, float> selector) => Sum(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Sum{TSource}(IEnumerable{TSource}, Func{TSource, float?})"/>
        public static float? Sum<TSource>(this IOpt<TSource> source, Func<TSource, float?> selector) => Sum(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Sum{TSource}(IEnumerable{TSource}, Func{TSource, double})"/>
        public static double Sum<TSource>(this IOpt<TSource> source, Func<TSource, double> selector) => Sum(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Sum{TSource}(IEnumerable{TSource}, Func{TSource, long?})"/>
        public static long? Sum<TSource>(this IOpt<TSource> source, Func<TSource, long?> selector) => Sum(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Sum{TSource}(IEnumerable{TSource}, Func{TSource, decimal})"/>
        public static decimal Sum<TSource>(this IOpt<TSource> source, Func<TSource, decimal> selector) => Sum(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Sum{TSource}(IEnumerable{TSource}, Func{TSource, double?})"/>
        public static double? Sum<TSource>(this IOpt<TSource> source, Func<TSource, double?> selector) => Sum(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{float?})"/>
        public static float? Sum(this IOpt<float?> source) => source.ToFixed().WhereNotNullRaw().SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{long?})"/>
        public static long? Sum(this IOpt<long?> source) => source.ToFixed().WhereNotNullRaw().SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{int?})"/>
        public static int? Sum(this IOpt<int?> source) => source.ToFixed().WhereNotNullRaw().SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{double?})"/>
        public static double? Sum(this IOpt<double?> source) => source.ToFixed().WhereNotNullRaw().SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{decimal?})"/>
        public static decimal? Sum(this IOpt<decimal?> source) => source.ToFixed().WhereNotNullRaw().SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{float})"/>
        public static float Sum(this IOpt<float> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{long})"/>
        public static long Sum(this IOpt<long> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{int})"/>
        public static int Sum(this IOpt<int> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{double})"/>
        public static double Sum(this IOpt<double> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{decimal})"/>
        public static decimal Sum(this IOpt<decimal> source) => source.SingleOrDefault();
    }
}