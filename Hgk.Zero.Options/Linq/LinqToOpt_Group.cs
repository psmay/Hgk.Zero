using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Groups the elements of an option by a selected key.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to group elements.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">A function to select the key that corresponds to an element.</param>
        /// <returns>
        /// An option that contains a grouping for the element of <paramref name="source"/>, if
        /// <paramref name="source"/> is full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<IOptGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector) => source.GroupBy(keySelector, null);

        /// <summary>
        /// Groups the elements of an option by a selected key.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to group elements.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">A function to select the key that corresponds to an element.</param>
        /// <param name="comparer">
        /// A comparer to determine whether keys are equal. (This parameter is ignored.)
        /// </param>
        /// <returns>
        /// An option that contains a grouping for the element of <paramref name="source"/>, if
        /// <paramref name="source"/> is full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="keySelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<IOptGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) => source.GroupBy(keySelector, GetGrouping);

        /// <summary>
        /// Groups the projected elements of an option by a selected key.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to group elements.</typeparam>
        /// <typeparam name="TElement">
        /// The type of the transformed elements to include in the grouping.
        /// </typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <param name="elementSelector">
        /// A function to transform an element of <paramref name="source"/> to an element to include
        /// in a grouping.
        /// </param>
        /// <returns>
        /// An option that contains a grouping for the projected element of <paramref
        /// name="source"/>, if <paramref name="source"/> is full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/>, <paramref name="keySelector"/>, or <paramref
        /// name="elementSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<IOptGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) => source.GroupBy(keySelector, elementSelector, null);

        /// <summary>
        /// Groups the projected elements of an option by a selected key.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to group elements.</typeparam>
        /// <typeparam name="TElement">
        /// The type of the transformed elements to include in the grouping.
        /// </typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <param name="elementSelector">
        /// A function to transform an element of <paramref name="source"/> to an element to include
        /// in a grouping.
        /// </param>
        /// <param name="comparer">
        /// A comparer to determine whether keys are equal. (This parameter is ignored.)
        /// </param>
        /// <returns>
        /// An option that contains a grouping for the projected element of <paramref
        /// name="source"/>, if <paramref name="source"/> is full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/>, <paramref name="keySelector"/>, or <paramref
        /// name="elementSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<IOptGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) => source.GroupBy(keySelector, elementSelector, GetGrouping);

        /// <summary>
        /// Groups the elements of an option by a selected key, then applies a transform to each grouping.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to group elements.</typeparam>
        /// <typeparam name="TResult">The type of the result value for each grouping.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <param name="resultSelector">A function to select a result value for each grouping.</param>
        /// <returns>
        /// An option that contains the result of applying <paramref name="resultSelector"/> to the
        /// grouping for the element of <paramref name="source"/>, if <paramref name="source"/> is
        /// full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/>, <paramref name="keySelector"/>, or <paramref
        /// name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> GroupBy<TSource, TKey, TResult>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IOpt<TSource>, TResult> resultSelector) => source.GroupBy(keySelector, resultSelector, null);

        /// <summary>
        /// Groups the elements of an option by a selected key, then applies a transform to each grouping.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to group elements.</typeparam>
        /// <typeparam name="TResult">The type of the result value for each grouping.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <param name="resultSelector">A function to select a result value for each grouping.</param>
        /// <param name="comparer">
        /// A comparer to determine whether keys are equal. (This parameter is ignored.)
        /// </param>
        /// <returns>
        /// An option that contains the result of applying <paramref name="resultSelector"/> to the
        /// grouping for the element of <paramref name="source"/>, if <paramref name="source"/> is
        /// full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/>, <paramref name="keySelector"/>, or <paramref
        /// name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> GroupBy<TSource, TKey, TResult>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IOpt<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return source.Select(value => resultSelector(keySelector(value), Opt.Full(value)));
        }

        /// <summary>
        /// Groups the projected elements of an option by a selected key, then applies a transform to
        /// each grouping.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to group elements.</typeparam>
        /// <typeparam name="TElement">
        /// The type of the transformed elements to include in the grouping.
        /// </typeparam>
        /// <typeparam name="TResult">The type of the result value for each grouping.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <param name="elementSelector">
        /// A function to transform an element of <paramref name="source"/> to an element to include
        /// in a grouping.
        /// </param>
        /// <param name="resultSelector">A function to select a result value for each grouping.</param>
        /// <returns>
        /// An option that contains the result of applying <paramref name="resultSelector"/> to the
        /// grouping for the projected element of <paramref name="source"/>, if <paramref
        /// name="source"/> is full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/>, <paramref name="keySelector"/>, <paramref
        /// name="elementSelector"/>, or <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IOpt<TElement>, TResult> resultSelector) => source.GroupBy(keySelector, elementSelector, resultSelector, null);

        /// <summary>
        /// Groups the projected elements of an option by a selected key, then applies a transform to
        /// each grouping.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to group elements.</typeparam>
        /// <typeparam name="TElement">
        /// The type of the transformed elements to include in the grouping.
        /// </typeparam>
        /// <typeparam name="TResult">The type of the result value for each grouping.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="keySelector">
        /// A function to select the key that corresponds to an element of <paramref name="source"/>.
        /// </param>
        /// <param name="elementSelector">
        /// A function to transform an element of <paramref name="source"/> to an element to include
        /// in a grouping.
        /// </param>
        /// <param name="resultSelector">A function to select a result value for each grouping.</param>
        /// <param name="comparer">
        /// A comparer to determine whether keys are equal. (This parameter is ignored.)
        /// </param>
        /// <returns>
        /// An option that contains the result of applying <paramref name="resultSelector"/> to the
        /// grouping for the projected element of <paramref name="source"/>, if <paramref
        /// name="source"/> is full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/>, <paramref name="keySelector"/>, <paramref
        /// name="elementSelector"/>, or <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IOpt<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return source.Select(value => resultSelector(keySelector(value), Opt.Full(elementSelector(value))));
        }

        /// <summary>
        /// Joins each element of an outer option to a grouping of inner elements with matching keys,
        /// then applies a transform to each grouping.
        /// </summary>
        /// <typeparam name="TOuter">The type of the elements of <paramref name="outer"/>.</typeparam>
        /// <typeparam name="TInner">The type of the elements of <paramref name="inner"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to match and group elements.</typeparam>
        /// <typeparam name="TResult">The type of the result value for each grouping.</typeparam>
        /// <param name="outer">The outer option to join.</param>
        /// <param name="inner">The inner sequence to join.</param>
        /// <param name="outerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="outer"/>.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="inner"/>.
        /// </param>
        /// <param name="resultSelector">A function to select a result value for each grouping.</param>
        /// <returns>
        /// An option that contains the result of applying <paramref name="resultSelector"/> to the
        /// grouping for the element of <paramref name="outer"/> and its corresponding elements of
        /// <paramref name="inner"/>, if <paramref name="outer"/> is full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="outer"/>, <paramref name="inner"/>, <paramref name="outerKeySelector"/>,
        /// <paramref name="innerKeySelector"/>, or <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IOpt<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector) => outer.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, null);

        /// <summary>
        /// Joins each element of an outer option to a grouping of inner elements with matching keys,
        /// then applies a transform to each grouping.
        /// </summary>
        /// <typeparam name="TOuter">The type of the elements of <paramref name="outer"/>.</typeparam>
        /// <typeparam name="TInner">The type of the elements of <paramref name="inner"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to match and group elements.</typeparam>
        /// <typeparam name="TResult">The type of the result value for each grouping.</typeparam>
        /// <param name="outer">The outer option to join.</param>
        /// <param name="inner">The inner sequence to join.</param>
        /// <param name="outerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="outer"/>.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="inner"/>.
        /// </param>
        /// <param name="resultSelector">A function to select a result value for each grouping.</param>
        /// <param name="comparer">
        /// A comparer to determine whether keys are equal. (If <see langword="null"/>, <see
        /// cref="EqualityComparer{T}.Default"/> is used.)
        /// </param>
        /// <returns>
        /// An option that contains the result of applying <paramref name="resultSelector"/> to the
        /// grouping for the element of <paramref name="outer"/> and its corresponding elements of
        /// <paramref name="inner"/>, if <paramref name="outer"/> is full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="outer"/>, <paramref name="inner"/>, <paramref name="outerKeySelector"/>,
        /// <paramref name="innerKeySelector"/>, or <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IOpt<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            if (outer == null) throw new ArgumentNullException(nameof(outer));
            if (inner == null) throw new ArgumentNullException(nameof(inner));
            if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
            if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return outer.SelectRaw(outerValue =>
            {
                var comparerNonNull = comparer.DefaultIfNull();
                var outerKey = outerKeySelector(outerValue);
                var innerValues = inner.Where(innerValue => comparerNonNull.Equals(outerKey, innerKeySelector(innerValue))).ToArray();
                return resultSelector(outerValue, innerValues);
            });
        }

        /// <summary>
        /// Joins each element of an outer option to a grouping of inner elements with matching keys,
        /// then applies a transform to each grouping.
        /// </summary>
        /// <typeparam name="TOuter">The type of the elements of <paramref name="outer"/>.</typeparam>
        /// <typeparam name="TInner">The type of the elements of <paramref name="inner"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to match and group elements.</typeparam>
        /// <typeparam name="TResult">The type of the result value for each grouping.</typeparam>
        /// <param name="outer">The outer option to join.</param>
        /// <param name="inner">The inner option to join.</param>
        /// <param name="outerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="outer"/>.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="inner"/>.
        /// </param>
        /// <param name="resultSelector">A function to select a result value for each grouping.</param>
        /// <returns>
        /// An option that contains the result of applying <paramref name="resultSelector"/> to the
        /// grouping for the element of <paramref name="outer"/> and its corresponding elements of
        /// <paramref name="inner"/>, if <paramref name="outer"/> is full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="outer"/>, <paramref name="inner"/>, <paramref name="outerKeySelector"/>,
        /// <paramref name="innerKeySelector"/>, or <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IOpt<TOuter> outer, IOpt<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IOpt<TInner>, TResult> resultSelector) => outer.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, null);

        /// <summary>
        /// Joins each element of an outer option to a grouping of inner elements with matching keys,
        /// then applies a transform to each grouping.
        /// </summary>
        /// <typeparam name="TOuter">The type of the elements of <paramref name="outer"/>.</typeparam>
        /// <typeparam name="TInner">The type of the elements of <paramref name="inner"/>.</typeparam>
        /// <typeparam name="TKey">The type of the key used to match and group elements.</typeparam>
        /// <typeparam name="TResult">The type of the result value for each grouping.</typeparam>
        /// <param name="outer">The outer option to join.</param>
        /// <param name="inner">The inner option to join.</param>
        /// <param name="outerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="outer"/>.
        /// </param>
        /// <param name="innerKeySelector">
        /// A function to select the key that corresponds to an element of <paramref name="inner"/>.
        /// </param>
        /// <param name="resultSelector">A function to select a result value for each grouping.</param>
        /// <param name="comparer">
        /// A comparer to determine whether keys are equal. (If <see langword="null"/>, <see
        /// cref="EqualityComparer{T}.Default"/> is used.)
        /// </param>
        /// <returns>
        /// An option that contains the result of applying <paramref name="resultSelector"/> to the
        /// grouping for the element of <paramref name="outer"/> and its corresponding elements of
        /// <paramref name="inner"/>, if <paramref name="outer"/> is full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="outer"/>, <paramref name="inner"/>, <paramref name="outerKeySelector"/>,
        /// <paramref name="innerKeySelector"/>, or <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IOpt<TOuter> outer, IOpt<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IOpt<TInner>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            if (outer == null) throw new ArgumentNullException(nameof(outer));
            if (inner == null) throw new ArgumentNullException(nameof(inner));
            if (outerKeySelector == null) throw new ArgumentNullException(nameof(outerKeySelector));
            if (innerKeySelector == null) throw new ArgumentNullException(nameof(innerKeySelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return outer.SelectRaw(outerValue =>
            {
                var comparerNonNull = comparer.DefaultIfNull();
                var outerKey = outerKeySelector(outerValue);
                var innerValues = inner.WhereOptRaw(innerValue => comparerNonNull.Equals(outerKey, innerKeySelector(innerValue)));
                return resultSelector(outerValue, innerValues);
            });
        }

        private static IOptGrouping<TKey, TElement> GetGrouping<TKey, TElement>(TKey key, IOpt<TElement> values) => new OptGrouping<TKey, TElement>(key, values.ToFixed());
    }
}