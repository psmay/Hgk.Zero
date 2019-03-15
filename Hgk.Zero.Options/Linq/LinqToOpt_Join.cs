using System;
using System.Collections.Generic;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Joins elements of an outer option with elements of an inner option having matching keys.
        /// </summary>
        /// <typeparam name="TOuter">The type of the elements of <paramref name="outer"/>.</typeparam>
        /// <typeparam name="TInner">The type of the elements of <paramref name="inner"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to match elements.</typeparam>
        /// <typeparam name="TResult">The type of the result value for each matched pair.</typeparam>
        /// <param name="outer">The outer option to join.</param>
        /// <param name="inner">The inner option to join.</param>
        /// <param name="outerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="outer"/>.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="inner"/>.
        /// </param>
        /// <param name="resultSelector">A function to select a result value for each matched pair.</param>
        /// <returns>
        /// An option that contains the result of applying <paramref name="resultSelector"/> to the
        /// element of <paramref name="outer"/> and the element of <paramref name="inner"/>, if both
        /// options are full and their corresponding keys are equal; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="outer"/>, <paramref name="inner"/>, <paramref name="outerKeySelector"/>,
        /// <paramref name="innerKeySelector"/>, or <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> Join<TOuter, TInner, TKey, TResult>(this IOpt<TOuter> outer, IOpt<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector) => outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

        /// <summary>
        /// Joins elements of an outer option with elements of an inner option having matching keys.
        /// </summary>
        /// <typeparam name="TOuter">The type of the elements of <paramref name="outer"/>.</typeparam>
        /// <typeparam name="TInner">The type of the elements of <paramref name="inner"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to match elements.</typeparam>
        /// <typeparam name="TResult">The type of the result value for each matched pair.</typeparam>
        /// <param name="outer">The outer option to join.</param>
        /// <param name="inner">The inner option to join.</param>
        /// <param name="outerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="outer"/>.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="inner"/>.
        /// </param>
        /// <param name="resultSelector">A function to select a result value for each matched pair.</param>
        /// <param name="comparer">
        /// A comparer to determine whether keys are equal. (If <see langword="null"/>, <see
        /// cref="EqualityComparer{T}.Default"/> is used.)
        /// </param>
        /// <returns>
        /// An option that contains the result of applying <paramref name="resultSelector"/> to the
        /// element of <paramref name="outer"/> and the element of <paramref name="inner"/>, if both
        /// options are full and their corresponding keys are equal according to <paramref
        /// name="comparer"/>; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="outer"/>, <paramref name="inner"/>, <paramref name="outerKeySelector"/>,
        /// <paramref name="innerKeySelector"/>, or <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> Join<TOuter, TInner, TKey, TResult>(this IOpt<TOuter> outer, IOpt<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            if (outer == null) throw new ArgumentNullException(nameof(outer));
            if (inner == null) throw new ArgumentNullException(nameof(inner));
            if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
            if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return outer
                .CrossJoinRaw(inner)
                .WhereRaw(x => comparer.DefaultIfNull().Equals(outerKeySelector(x.first), innerKeySelector(x.second)))
                .SelectRaw(x => resultSelector(x.first, x.second));
        }

        /// <summary>
        /// Returns the cross join of two options; if both options are full, the result is full and
        /// contains the combined option values; if either option is empty, the result is empty.
        /// </summary>
        private static IOpt<TResult> CrossJoinRaw<TFirst, TSecond, TResult>(this IOpt<TFirst> first, IOpt<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            return Opt.DeferRaw(() =>
            {
                var firstOpt = Opt.Fix(first);
                if (firstOpt.HasValue)
                {
                    var secondOpt = Opt.Fix(second);
                    if (secondOpt.HasValue)
                    {
                        return Opt.Full(resultSelector(firstOpt.ValueOrDefault, secondOpt.ValueOrDefault));
                    }
                }
                return Opt.Empty<TResult>();
            });
        }

        /// <summary>
        /// Returns the cross join of two options; if both options are full, the result is full and
        /// contains the paired option values; if either option is empty, the result is empty.
        /// </summary>
        private static IOpt<(TFirst first, TSecond second)> CrossJoinRaw<TFirst, TSecond>(this IOpt<TFirst> first, IOpt<TSecond> second) =>
            first.CrossJoinRaw(second, (firstValue, secondValue) => (firstValue, secondValue));
    }
}