using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    /// <summary>
    /// LINQ facilities for options.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class contains a large number of LINQ-compatible methods. While all options are also
    /// enumerables, and can therefore be used with methods provided by <see cref="Enumerable"/>,
    /// most of the operators are specialized here for options in order to optimize the algorithms
    /// for use with zero- or one-element collections (such as <see
    /// cref="Distinct{TSource}(IOpt{TSource})"/>), and also to return options from operations
    /// guaranteed to return at most one element when performed on an option (such as <see
    /// cref="Zip{TFirst, TSecond, TResult}(IOpt{TFirst}, IEnumerable{TSecond}, Func{TFirst, TSecond,
    /// TResult})"/>). In general, the result of applying any LINQ operation in this class to an
    /// option is defined to be sequence-equal to the result of applying the same operation from <see
    /// cref="Enumerable"/> to the same option.
    /// </para>
    /// <para>
    /// Similarly to the methods in <see cref="Enumerable"/>, most option-returning methods in this
    /// class are implemented using deferred execution; that is, the query represented by the method
    /// is not actually executed until the contents of the result are resolved directly, for example,
    /// by enumeration, using foreach, or calling a method such as <see
    /// cref="ToFixed{TSource}(IOpt{TSource})"/> or <see cref="Match{TSource, TResult}(IOpt{TSource},
    /// Func{TResult}, Func{TSource, TResult})"/>.
    /// </para>
    /// <para>
    /// Some methods instead use or return <see cref="Opt{T}"/>, which is a type for fixed, immutable
    /// options. The contents of these are immediate and not deferred.
    /// </para>
    /// </remarks>
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Returns this option typed as <see cref="IOpt{T}"/>.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to type as <see cref="IOpt{T}"/>.</param>
        /// <returns><paramref name="source"/>, typed as <see cref="IOpt{T}"/>.</returns>
        public static IOpt<TSource> AsIOpt<TSource>(this IOpt<TSource> source) => source;

        /// <inheritdoc cref="Enumerable.Contains{TSource}(IEnumerable{TSource}, TSource)"/>
        public static bool Contains<TSource>(this IOpt<TSource> source, TSource value) => source.Contains(value, null);

        /// <inheritdoc cref="Enumerable.Contains{TSource}(IEnumerable{TSource}, TSource, IEqualityComparer{TSource})"/>
        public static bool Contains<TSource>(this IOpt<TSource> source, TSource value, IEqualityComparer<TSource> comparer) => source.ToFixed().Contains(value, comparer);

        /// <inheritdoc cref="Enumerable.Distinct{TSource}(IEnumerable{TSource})"/>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, never contains
        /// duplicate elements, this method returns <paramref name="source"/> unmodified (after
        /// ensuring that it is not <see langword="null"/>).
        /// </remarks>
        public static IOpt<TSource> Distinct<TSource>(this IOpt<TSource> source) => SimpleNoop(source);

        /// <inheritdoc cref="Enumerable.Distinct{TSource}(IEnumerable{TSource}, IEqualityComparer{TSource})"/>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, never contains
        /// duplicate elements, this method returns <paramref name="source"/> unmodified (after
        /// ensuring that it is not <see langword="null"/>).
        /// </remarks>
        public static IOpt<TSource> Distinct<TSource>(this IOpt<TSource> source, IEqualityComparer<TSource> comparer) => SimpleNoop(source);

        /// <inheritdoc cref="Enumerable.Reverse{TSource}(IEnumerable{TSource})"/>
        /// <remarks>
        /// Since an option, by virtue of being a zero- or one-element sequence, is its own reverse,
        /// this method returns <paramref name="source"/> unmodified (after ensuring that it is not
        /// <see langword="null"/>).
        /// </remarks>
        public static IOpt<TSource> Reverse<TSource>(this IOpt<TSource> source) => SimpleNoop(source);

        /// <inheritdoc cref="Enumerable.ToArray{TSource}(IEnumerable{TSource})"/>
        public static TSource[] ToArray<TSource>(this IOpt<TSource> source)
        {
            var opt = source.ToFixed();
            return opt.HasValue ? new TSource[] { opt.ValueOrDefault } : new TSource[0];
        }

        /// <summary>
        /// Returns a fixed option reflecting the current state of an option.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <returns>A fixed option reflecting the current state of <paramref name="source"/>.</returns>
        public static Opt<TSource> ToFixed<TSource>(this IOpt<TSource> source) => Opt.Fix(source);

        /// <summary>
        /// Returns a fixed option reflecting the current state of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>A fixed option reflecting the current state of <paramref name="source"/>.</returns>
        public static Opt<object> ToFixed(this IOpt source) => Opt.FixUntyped(source);

        /// <inheritdoc cref="Enumerable.ToList{TSource}(IEnumerable{TSource})"/>
        public static List<TSource> ToList<TSource>(this IOpt<TSource> source)
        {
            var opt = source.ToFixed();
            return opt.HasValue ? new List<TSource>(1) { opt.ValueOrDefault } : new List<TSource>(0);
        }

        /// <summary>
        /// Gets the value contained by an option, if it exists.
        /// </summary>
        /// <typeparam name="TSource">The element type of source.</typeparam>
        /// <param name="source">An option whose value to get.</param>
        /// <param name="value">
        /// When this method returns, is set to the value contained by <paramref name="source"/>, if
        /// any, or the default value of <typeparamref name="TSource"/>, otherwise.
        /// </param>
        /// <returns><see langword="true"/>, if source contains a value; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static bool TryGetValue<TSource>(this IOpt<TSource> source, out TSource value)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.ToFixed().TryGetValue(out value);
        }

        private static IOpt<TSource> SimpleNoop<TSource>(IOpt<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source;
        }
    }
}