using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        public static IOpt<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IOpt<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return source.Select(value => resultSelector(keySelector(value), Opt.Full(elementSelector(value))));
        }

        public static IOpt<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IOpt<TElement>, TResult> resultSelector) => source.GroupBy(keySelector, elementSelector, resultSelector, null);

        public static IOpt<TResult> GroupBy<TSource, TKey, TResult>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IOpt<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return source.Select(value => resultSelector(keySelector(value), Opt.Full(value)));
        }

        public static IOpt<TResult> GroupBy<TSource, TKey, TResult>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IOpt<TSource>, TResult> resultSelector) => source.GroupBy(keySelector, resultSelector, null);

        public static IOpt<IOptGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector) => source.GroupBy(keySelector, null);

        public static IOpt<IOptGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer) => source.GroupBy(keySelector, GetGrouping);

        public static IOpt<IOptGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) => source.GroupBy(keySelector, elementSelector, null);

        public static IOpt<IOptGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer) => source.GroupBy(keySelector, elementSelector, GetGrouping);

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

        public static IOpt<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IOpt<TOuter> outer, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector) => outer.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, null);

        public static IOpt<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IOpt<TOuter> outer, IOpt<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IOpt<TInner>, TResult> resultSelector) => outer.GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, null);

        private static IOptGrouping<TKey, TElement> GetGrouping<TKey, TElement>(TKey key, IOpt<TElement> values) => new OptGrouping<TKey, TElement>(key, values.ToFixed());
    }
}