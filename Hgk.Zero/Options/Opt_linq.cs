using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options
{
    public static partial class Opt
    {
        /// <inheritdoc cref="Enumerable.Aggregate{TSource}(IEnumerable{TSource}, Func{TSource, TSource, TSource})"/>
        public static TSource Aggregate<TSource>(this IOpt<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            return source.Single();
        }

        /// <inheritdoc cref="Enumerable.Aggregate{TSource, TAccumulate}(IEnumerable{TSource}, TAccumulate, Func{TAccumulate, TSource, TAccumulate})"/>
        public static TAccumulate Aggregate<TSource, TAccumulate>(this IOpt<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            var opt = source.ToFixed();
            return opt.HasValue ? func(seed, opt.ValueOrDefault) : seed;
        }

        /// <inheritdoc cref="Enumerable.Aggregate{TSource, TAccumulate, TResult}(IEnumerable{TSource}, TAccumulate, Func{TAccumulate, TSource, TAccumulate}, Func{TAccumulate, TResult})"/>
        public static TResult Aggregate<TSource, TAccumulate, TResult>(this IOpt<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return resultSelector(source.Aggregate(seed, func));
        }

        /// <inheritdoc cref="Enumerable.All{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static bool All<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return opt.HasValue ? predicate(opt.ValueOrDefault) : true;
        }

        /// <inheritdoc cref="Enumerable.Any{TSource}(IEnumerable{TSource})"/>
        public static bool Any<TSource>(this IOpt<TSource> source) => source.ToFixed().HasValue;

        /// <inheritdoc cref="Enumerable.Any{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static bool Any<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return opt.HasValue ? predicate(opt.ValueOrDefault) : false;
        }

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

        /// <inheritdoc cref="Enumerable.Cast{TResult}(System.Collections.IEnumerable)"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>
        /// If <paramref name="source"/> is already an <see cref="IOpt{T}"/> with <typeparamref
        /// name="TResult"/> as its element type, it is returned unchanged.
        /// </para>
        /// </remarks>
        public static IOpt<TResult> Cast<TResult>(this IOpt source)
        {
            if (source is IOpt<TResult> alreadyCorrectSource)
            {
                return alreadyCorrectSource;
            }
            return Defer(() => Cast<object, TResult>(source.ToFixed()));
        }

        /// <inheritdoc cref="Enumerable.Contains{TSource}(IEnumerable{TSource}, TSource)"/>
        public static bool Contains<TSource>(this IOpt<TSource> source, TSource value) => source.Contains(value, null);

        /// <inheritdoc cref="Enumerable.Contains{TSource}(IEnumerable{TSource}, TSource, IEqualityComparer{TSource})"/>
        public static bool Contains<TSource>(this IOpt<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            Opt<TSource> opt = source.ToFixed();
            return Contains(opt, value, comparer);
        }

        /// <inheritdoc cref="Enumerable.Count{TSource}(IEnumerable{TSource})"/>
        public static int Count<TSource>(this IOpt<TSource> source) => source.Any() ? 1 : 0;

        /// <inheritdoc cref="Enumerable.Count{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static int Count<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Any(predicate) ? 1 : 0;

        /// <inheritdoc cref="Enumerable.DefaultIfEmpty{TSource}(IEnumerable{TSource})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> DefaultIfEmpty<TSource>(this IOpt<TSource> source)
        {
            return source.DefaultIfEmpty(default(TSource));
        }

        /// <inheritdoc cref="Enumerable.DefaultIfEmpty{TSource}(IEnumerable{TSource}, TSource)"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> DefaultIfEmpty<TSource>(this IOpt<TSource> source, TSource defaultValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.MetaSelect(opt => opt.HasValue ? opt : Full(defaultValue));
        }

        /// <inheritdoc cref="Enumerable.Distinct{TSource}(IEnumerable{TSource})"/>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, never contains
        /// duplicate elements, this method returns <paramref name="source"/> unmodified (after
        /// ensuring that it is not <see langword="null"/>).
        /// </remarks>
        public static IOpt<TSource> Distinct<TSource>(this IOpt<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source;
        }

        /// <inheritdoc cref="Enumerable.Distinct{TSource}(IEnumerable{TSource}, IEqualityComparer{TSource})"/>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, never contains
        /// duplicate elements, this method returns <paramref name="source"/> unmodified (after
        /// ensuring that it is not <see langword="null"/>).
        /// </remarks>
        public static IOpt<TSource> Distinct<TSource>(this IOpt<TSource> source, IEqualityComparer<TSource> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source;
        }

        /// <inheritdoc cref="Enumerable.ElementAt{TSource}(IEnumerable{TSource}, int)"/>
        public static TSource ElementAt<TSource>(this IOpt<TSource> source, int index)
        {
            if (index != 0) throw new ArgumentOutOfRangeException(nameof(index));
            return source.ToFixed().ElementAt(index);
        }

        /// <inheritdoc cref="Enumerable.ElementAtOrDefault{TSource}(IEnumerable{TSource}, int)"/>
        public static TSource ElementAtOrDefault<TSource>(this IOpt<TSource> source, int index)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (index == 0)
            {
                var opt = source.ToFixed();
                return opt.ValueOrDefault;
            }
            return default(TSource);
        }

        /// <inheritdoc cref="Enumerable.Except{TSource}(IEnumerable{TSource}, IEnumerable{TSource})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Except<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second) => first.Except(second, null);

        /// <inheritdoc cref="Enumerable.Except{TSource}(IEnumerable{TSource}, IEnumerable{TSource}, IEqualityComparer{TSource})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Except<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            return first.MetaSelect(opt => opt.WhereNotRaw(value => !second.Contains(value)));
        }

        /// <inheritdoc cref="Enumerable.First{TSource}(IEnumerable{TSource})"/>
        public static TSource First<TSource>(this IOpt<TSource> source) => source.Single();

        /// <inheritdoc cref="Enumerable.First{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource First<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Single(predicate);

        /// <inheritdoc cref="Enumerable.FirstOrDefault{TSource}(IEnumerable{TSource})"/>
        public static TSource FirstOrDefault<TSource>(this IOpt<TSource> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.FirstOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource FirstOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.SingleOrDefault(predicate);

        /// <inheritdoc cref="Enumerable.Intersect{TSource}(IEnumerable{TSource}, IEnumerable{TSource}, IEqualityComparer{TSource})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Intersect<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            return first.MetaSelect(opt => opt.WhereRaw(value => second.Contains(value)));
        }

        /// <inheritdoc cref="Enumerable.Intersect{TSource}(IEnumerable{TSource}, IEnumerable{TSource})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Intersect<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second) => first.Intersect(second, null);

        /// <inheritdoc cref="Enumerable.Last{TSource}(IEnumerable{TSource})"/>
        public static TSource Last<TSource>(this IOpt<TSource> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Last{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource Last<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Single(predicate);

        /// <inheritdoc cref="Enumerable.LastOrDefault{TSource}(IEnumerable{TSource})"/>
        public static TSource LastOrDefault<TSource>(this IOpt<TSource> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.LastOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource LastOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.SingleOrDefault(predicate);

        /// <inheritdoc cref="Enumerable.LongCount{TSource}(IEnumerable{TSource})"/>
        public static long LongCount<TSource>(this IOpt<TSource> source) => source.Count();

        /// <inheritdoc cref="Enumerable.LongCount{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static long LongCount<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Count(predicate);

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, int})"/>
        public static int Max<TSource>(this IOpt<TSource> source, Func<TSource, int> selector) => Max(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, long})"/>
        public static long Max<TSource>(this IOpt<TSource> source, Func<TSource, long> selector) => Max(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, decimal?})"/>
        public static decimal? Max<TSource>(this IOpt<TSource> source, Func<TSource, decimal?> selector) => Max(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, double?})"/>
        public static double? Max<TSource>(this IOpt<TSource> source, Func<TSource, double?> selector) => Max(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, float})"/>
        public static float Max<TSource>(this IOpt<TSource> source, Func<TSource, float> selector) => Max(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, long?})"/>
        public static long? Max<TSource>(this IOpt<TSource> source, Func<TSource, long?> selector) => Max(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, float?})"/>
        public static float? Max<TSource>(this IOpt<TSource> source, Func<TSource, float?> selector) => Max(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, double})"/>
        public static double Max<TSource>(this IOpt<TSource> source, Func<TSource, double> selector) => Max(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, int?})"/>
        public static int? Max<TSource>(this IOpt<TSource> source, Func<TSource, int?> selector) => Max(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource}, Func{TSource, decimal})"/>
        public static decimal Max<TSource>(this IOpt<TSource> source, Func<TSource, decimal> selector) => Max(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Max{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>
        public static TResult Max<TSource, TResult>(this IOpt<TSource> source, Func<TSource, TResult> selector) => Max(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{float})"/>
        public static float Max(this IOpt<float> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{decimal})"/>
        public static decimal Max(this IOpt<decimal> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{double})"/>
        public static double Max(this IOpt<double> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{int})"/>
        public static int Max(this IOpt<int> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{long})"/>
        public static long Max(this IOpt<long> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Max{TSource}(IEnumerable{TSource})"/>
        public static TSource Max<TSource>(this IOpt<TSource> source) => SingleOrNull(source);

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{double?})"/>
        public static double? Max(this IOpt<double?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{int?})"/>
        public static int? Max(this IOpt<int?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{long?})"/>
        public static long? Max(this IOpt<long?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{float?})"/>
        public static float? Max(this IOpt<float?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Max(IEnumerable{decimal?})"/>
        public static decimal? Max(this IOpt<decimal?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, int})"/>
        public static int Min<TSource>(this IOpt<TSource> source, Func<TSource, int> selector) => Min(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Min{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>
        public static TResult Min<TSource, TResult>(this IOpt<TSource> source, Func<TSource, TResult> selector) => Min(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, float})"/>
        public static float Min<TSource>(this IOpt<TSource> source, Func<TSource, float> selector) => Min(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, float?})"/>
        public static float? Min<TSource>(this IOpt<TSource> source, Func<TSource, float?> selector) => Min(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, long?})"/>
        public static long? Min<TSource>(this IOpt<TSource> source, Func<TSource, long?> selector) => Min(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, int?})"/>
        public static int? Min<TSource>(this IOpt<TSource> source, Func<TSource, int?> selector) => Min(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, double?})"/>
        public static double? Min<TSource>(this IOpt<TSource> source, Func<TSource, double?> selector) => Min(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, decimal?})"/>
        public static decimal? Min<TSource>(this IOpt<TSource> source, Func<TSource, decimal?> selector) => Min(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, long})"/>
        public static long Min<TSource>(this IOpt<TSource> source, Func<TSource, long> selector) => Min(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, decimal})"/>
        public static decimal Min<TSource>(this IOpt<TSource> source, Func<TSource, decimal> selector) => Min(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource}, Func{TSource, double})"/>
        public static double Min<TSource>(this IOpt<TSource> source, Func<TSource, double> selector) => Min(source.Select(selector));

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{float})"/>
        public static float Min(this IOpt<float> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{float?})"/>
        public static float? Min(this IOpt<float?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{long?})"/>
        public static long? Min(this IOpt<long?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{int?})"/>
        public static int? Min(this IOpt<int?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{double?})"/>
        public static double? Min(this IOpt<double?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{decimal?})"/>
        public static decimal? Min(this IOpt<decimal?> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{long})"/>
        public static long Min(this IOpt<long> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{int})"/>
        public static int Min(this IOpt<int> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{double})"/>
        public static double Min(this IOpt<double> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Min(IEnumerable{decimal})"/>
        public static decimal Min(this IOpt<decimal> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Min{TSource}(IEnumerable{TSource})"/>
        public static TSource Min<TSource>(this IOpt<TSource> source) => source.SingleOrNull();

        /// <inheritdoc cref="Enumerable.OfType{TResult}(System.Collections.IEnumerable)"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>
        /// If <paramref name="source"/> is already an <see cref="IOpt{T}"/> with <typeparamref
        /// name="TResult"/> as its element type, it is returned unchanged.
        /// </para>
        /// </remarks>
        public static IOpt<TResult> OfType<TResult>(this IOpt source)
        {
            if (source is IOpt<TResult> alreadyCorrectSource)
            {
                return alreadyCorrectSource;
            }
            return Defer(() => OfType<object, TResult>(source.ToFixed()));
        }

        /// <inheritdoc cref="Enumerable.Reverse{TSource}(IEnumerable{TSource})"/>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, is its own reverse,
        /// this method returns <paramref name="source"/> unmodified (after ensuring that it is not
        /// <see langword="null"/>).
        /// </remarks>
        public static IOpt<TSource> Reverse<TSource>(this IOpt<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source;
        }

        /// <inheritdoc cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TResult> Select<TSource, TResult>(this IOpt<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MetaSelect(opt => opt.SelectRaw(selector));
        }

        /// <inheritdoc cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, int, TResult})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TResult> Select<TSource, TResult>(this IOpt<TSource> source, Func<TSource, int, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MetaSelect(opt => opt.SelectRaw(selector));
        }

        /// <inheritdoc cref="Enumerable.SequenceEqual{TSource}(IEnumerable{TSource}, IEnumerable{TSource}, IEqualityComparer{TSource})"/>
        public static bool SequenceEqual<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            var opt = first.ToFixed();

            if (opt.HasValue)
            {
                using (var secondEnumerator = second.GetEnumerator())
                {
                    if (secondEnumerator.MoveNext())
                    {
                        var onlyValue = secondEnumerator.Current;

                        if (!secondEnumerator.MoveNext())
                        {
                            // second is same length
                            return (comparer ?? EqualityComparer<TSource>.Default).Equals(opt.ValueOrDefault, onlyValue);
                        }
                    }
                }

                // Number of elements did not match
                return false;
            }
            else
            {
                using (var secondEnumerator = second.GetEnumerator())
                {
                    return !secondEnumerator.MoveNext();
                }
            }
        }

        /// <inheritdoc cref="Enumerable.SequenceEqual{TSource}(IEnumerable{TSource}, IEnumerable{TSource})"/>
        public static bool SequenceEqual<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second) => first.SequenceEqual(second, null);

        /// <inheritdoc cref="Enumerable.Single{TSource}(IEnumerable{TSource})"/>
        public static TSource Single<TSource>(this IOpt<TSource> source)
        {
            var opt = source.ToFixed();
            return opt.HasValue ? opt.ValueOrDefault : throw Error.NoElements();
        }

        /// <inheritdoc cref="Enumerable.Single{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource Single<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return (opt.HasValue && predicate(opt.ValueOrDefault)) ? opt.ValueOrDefault : throw Error.NoMatch();
        }

        /// <inheritdoc cref="Enumerable.SingleOrDefault{TSource}(IEnumerable{TSource})"/>
        public static TSource SingleOrDefault<TSource>(this IOpt<TSource> source)
        {
            var opt = source.ToFixed();
            return opt.ValueOrDefault;
        }

        /// <inheritdoc cref="Enumerable.SingleOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource SingleOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return (opt.HasValue && predicate(opt.ValueOrDefault)) ? opt.ValueOrDefault : default(TSource);
        }

        /// <inheritdoc cref="Enumerable.Skip{TSource}(IEnumerable{TSource}, int)"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Skip<TSource>(this IOpt<TSource> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.KeepIf(count <= 0);
        }

        /// <inheritdoc cref="Enumerable.SkipWhile{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> SkipWhile<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereNotRaw(predicate));
        }

        /// <inheritdoc cref="Enumerable.SkipWhile{TSource}(IEnumerable{TSource}, Func{TSource, int, bool})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> SkipWhile<TSource>(this IOpt<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereNotRaw(predicate));
        }

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
        public static float? Sum(this IOpt<float?> source) => source.ToFixed().WhereNotNull().SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{long?})"/>
        public static long? Sum(this IOpt<long?> source) => source.ToFixed().WhereNotNull().SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{int?})"/>
        public static int? Sum(this IOpt<int?> source) => source.ToFixed().WhereNotNull().SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{double?})"/>
        public static double? Sum(this IOpt<double?> source) => source.ToFixed().WhereNotNull().SingleOrDefault();

        /// <inheritdoc cref="Enumerable.Sum(IEnumerable{decimal?})"/>
        public static decimal? Sum(this IOpt<decimal?> source) => source.ToFixed().WhereNotNull().SingleOrDefault();

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

        /// <inheritdoc cref="Enumerable.Take{TSource}(IEnumerable{TSource}, int)"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Take<TSource>(this IOpt<TSource> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.KeepIf(count >= 1);
        }

        /// <inheritdoc cref="Enumerable.TakeWhile{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> TakeWhile<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereRaw(predicate));
        }

        /// <inheritdoc cref="Enumerable.TakeWhile{TSource}(IEnumerable{TSource}, Func{TSource, int, bool})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> TakeWhile<TSource>(this IOpt<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereRaw(predicate));
        }

        /// <inheritdoc cref="Enumerable.ToArray{TSource}(IEnumerable{TSource})"/>
        public static TSource[] ToArray<TSource>(this IOpt<TSource> source)
        {
            var opt = source.ToFixed();
            return opt.HasValue ? new TSource[] { opt.ValueOrDefault } : new TSource[0];
        }

        /// <inheritdoc cref="Enumerable.ToList{TSource}(IEnumerable{TSource})"/>
        public static List<TSource> ToList<TSource>(this IOpt<TSource> source)
        {
            var opt = source.ToFixed();
            return opt.HasValue ? new List<TSource>(1) { opt.ValueOrDefault } : new List<TSource>(0);
        }

        /// <inheritdoc cref="Enumerable.Where{TSource}(IEnumerable{TSource}, Func{TSource, int, bool})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Where<TSource>(this IOpt<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereRaw(predicate));
        }

        /// <inheritdoc cref="Enumerable.Where{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Where<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereRaw(predicate));
        }

        /// <inheritdoc cref="Enumerable.Zip{TFirst, TSecond, TResult}(IEnumerable{TFirst}, IEnumerable{TSecond}, Func{TFirst, TSecond, TResult})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TResult> Zip<TFirst, TSecond, TResult>(this IOpt<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return first.MetaSelect(opt =>
            {
                if (opt.HasValue)
                {
                    foreach (var secondValue in second)
                    {
                        return Full(resultSelector(opt.ValueOrDefault, secondValue));
                    }
                }
                return Empty<TResult>();
            });
        }
    }
}