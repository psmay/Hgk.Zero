using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, int})"/>
        public static int Max<TSource>(this IOpt<TSource> source, Func<TSource, int> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, long})"/>
        public static long Max<TSource>(this IOpt<TSource> source, Func<TSource, long> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, decimal?})"/>
        public static decimal? Max<TSource>(this IOpt<TSource> source, Func<TSource, decimal?> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, double?})"/>
        public static double? Max<TSource>(this IOpt<TSource> source, Func<TSource, double?> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, float})"/>
        public static float Max<TSource>(this IOpt<TSource> source, Func<TSource, float> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, long?})"/>
        public static long? Max<TSource>(this IOpt<TSource> source, Func<TSource, long?> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, float?})"/>
        public static float? Max<TSource>(this IOpt<TSource> source, Func<TSource, float?> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, double})"/>
        public static double Max<TSource>(this IOpt<TSource> source, Func<TSource, double> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, int?})"/>
        public static int? Max<TSource>(this IOpt<TSource> source, Func<TSource, int?> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, decimal})"/>
        public static decimal Max<TSource>(this IOpt<TSource> source, Func<TSource, decimal> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Max{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>
        public static TResult Max<TSource, TResult>(this IOpt<TSource> source, Func<TSource, TResult> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{float})"/>
        public static float Max(this IOpt<float> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{decimal})"/>
        public static decimal Max(this IOpt<decimal> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{double})"/>
        public static double Max(this IOpt<double> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{int})"/>
        public static int Max(this IOpt<int> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{long})"/>
        public static long Max(this IOpt<long> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource})"/>
        public static TSource Max<TSource>(this IOpt<TSource> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{double?})"/>
        public static double? Max(this IOpt<double?> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{int?})"/>
        public static int? Max(this IOpt<int?> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{long?})"/>
        public static long? Max(this IOpt<long?> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{float?})"/>
        public static float? Max(this IOpt<float?> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{decimal?})"/>
        public static decimal? Max(this IOpt<decimal?> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, int})"/>
        public static int Min<TSource>(this IOpt<TSource> source, Func<TSource, int> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, long})"/>
        public static long Min<TSource>(this IOpt<TSource> source, Func<TSource, long> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, decimal?})"/>
        public static decimal? Min<TSource>(this IOpt<TSource> source, Func<TSource, decimal?> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, double?})"/>
        public static double? Min<TSource>(this IOpt<TSource> source, Func<TSource, double?> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, float})"/>
        public static float Min<TSource>(this IOpt<TSource> source, Func<TSource, float> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, long?})"/>
        public static long? Min<TSource>(this IOpt<TSource> source, Func<TSource, long?> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, float?})"/>
        public static float? Min<TSource>(this IOpt<TSource> source, Func<TSource, float?> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, double})"/>
        public static double Min<TSource>(this IOpt<TSource> source, Func<TSource, double> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, int?})"/>
        public static int? Min<TSource>(this IOpt<TSource> source, Func<TSource, int?> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, decimal})"/>
        public static decimal Min<TSource>(this IOpt<TSource> source, Func<TSource, decimal> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Min{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>
        public static TResult Min<TSource, TResult>(this IOpt<TSource> source, Func<TSource, TResult> selector) => Extremum(source, selector);

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{float})"/>
        public static float Min(this IOpt<float> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{decimal})"/>
        public static decimal Min(this IOpt<decimal> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{double})"/>
        public static double Min(this IOpt<double> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{int})"/>
        public static int Min(this IOpt<int> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{long})"/>
        public static long Min(this IOpt<long> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource})"/>
        public static TSource Min<TSource>(this IOpt<TSource> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{double?})"/>
        public static double? Min(this IOpt<double?> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{int?})"/>
        public static int? Min(this IOpt<int?> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{long?})"/>
        public static long? Min(this IOpt<long?> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{float?})"/>
        public static float? Min(this IOpt<float?> source) => Extremum(source);

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{decimal?})"/>
        public static decimal? Min(this IOpt<decimal?> source) => Extremum(source);

        private static float Extremum(IOpt<float> source) => source.Single();

        private static decimal Extremum(IOpt<decimal> source) => source.Single();

        private static double Extremum(IOpt<double> source) => source.Single();

        private static int Extremum(IOpt<int> source) => source.Single();

        private static long Extremum(IOpt<long> source) => source.Single();

        // The proper response for Min() or Max() for an arbitrary unknown type.
        // If the source is empty and the type is non-nullable, throw a No-Elements exception.
        // If the source is empty and the type is nullable, return null.
        // Otherwise, return the contained value (even if it is null).
        private static TSource Extremum<TSource>(IOpt<TSource> source) => default(TSource) == null ? source.SingleOrDefault() : source.Single();

        private static double? Extremum(IOpt<double?> source) => source.SingleOrDefault();

        private static int? Extremum(IOpt<int?> source) => source.SingleOrDefault();

        private static long? Extremum(IOpt<long?> source) => source.SingleOrDefault();

        private static float? Extremum(IOpt<float?> source) => source.SingleOrDefault();

        private static decimal? Extremum(IOpt<decimal?> source) => source.SingleOrDefault();

        private static int Extremum<TSource>(IOpt<TSource> source, Func<TSource, int> selector) => Extremum(source.Select(selector));

        private static long Extremum<TSource>(IOpt<TSource> source, Func<TSource, long> selector) => Extremum(source.Select(selector));

        private static decimal? Extremum<TSource>(IOpt<TSource> source, Func<TSource, decimal?> selector) => Extremum(source.Select(selector));

        private static double? Extremum<TSource>(IOpt<TSource> source, Func<TSource, double?> selector) => Extremum(source.Select(selector));

        private static float Extremum<TSource>(IOpt<TSource> source, Func<TSource, float> selector) => Extremum(source.Select(selector));

        private static long? Extremum<TSource>(IOpt<TSource> source, Func<TSource, long?> selector) => Extremum(source.Select(selector));

        private static float? Extremum<TSource>(IOpt<TSource> source, Func<TSource, float?> selector) => Extremum(source.Select(selector));

        private static double Extremum<TSource>(IOpt<TSource> source, Func<TSource, double> selector) => Extremum(source.Select(selector));

        private static int? Extremum<TSource>(IOpt<TSource> source, Func<TSource, int?> selector) => Extremum(source.Select(selector));

        private static decimal Extremum<TSource>(IOpt<TSource> source, Func<TSource, decimal> selector) => Extremum(source.Select(selector));

        private static TResult Extremum<TSource, TResult>(IOpt<TSource> source, Func<TSource, TResult> selector) => Extremum(source.Select(selector));
    }
}