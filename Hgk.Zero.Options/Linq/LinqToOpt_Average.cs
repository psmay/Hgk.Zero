using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <inheritdoc cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, long})"/>
        public static double Average<TSource>(this IOpt<TSource> source, Func<TSource, long> selector) => Average(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, decimal?})"/>
        public static decimal? Average<TSource>(this IOpt<TSource> source, Func<TSource, decimal?> selector) => Average(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, double?})"/>
        public static double? Average<TSource>(this IOpt<TSource> source, Func<TSource, double?> selector) => Average(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, float})"/>
        public static float Average<TSource>(this IOpt<TSource> source, Func<TSource, float> selector) => Average(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, long?})"/>
        public static double? Average<TSource>(this IOpt<TSource> source, Func<TSource, long?> selector) => Average(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, float?})"/>
        public static float? Average<TSource>(this IOpt<TSource> source, Func<TSource, float?> selector) => Average(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, int})"/>
        public static double Average<TSource>(this IOpt<TSource> source, Func<TSource, int> selector) => Average(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, int?})"/>
        public static double? Average<TSource>(this IOpt<TSource> source, Func<TSource, int?> selector) => Average(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, double})"/>
        public static double Average<TSource>(this IOpt<TSource> source, Func<TSource, double> selector) => Average(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Average{TSource}(IEnumerable{TSource}, Func{TSource, decimal})"/>
        public static decimal Average<TSource>(this IOpt<TSource> source, Func<TSource, decimal> selector) => Average(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Average(IEnumerable{decimal})"/>
        public static decimal Average(this IOpt<decimal> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Average(IEnumerable{float})"/>
        public static float Average(this IOpt<float> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Average(IEnumerable{int})"/>
        public static double Average(this IOpt<int> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Average(IEnumerable{long})"/>
        public static double Average(this IOpt<long> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Average(IEnumerable{decimal?})"/>
        public static decimal? Average(this IOpt<decimal?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Average(IEnumerable{double})"/>
        public static double Average(this IOpt<double> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Average(IEnumerable{int?})"/>
        public static double? Average(this IOpt<int?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Average(IEnumerable{long?})"/>
        public static double? Average(this IOpt<long?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Average(IEnumerable{float?})"/>
        public static float? Average(this IOpt<float?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Average(IEnumerable{double?})"/>
        public static double? Average(this IOpt<double?> source) => source.SingleOrDefault();
    }
}