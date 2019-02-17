using System;
using System.Collections.Generic;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        public static IOpt<TResult> Join<TOuter, TInner, TKey, TResult>(this IOpt<TOuter> outer, IOpt<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector) => outer.Join(inner, outerKeySelector, innerKeySelector, resultSelector, null);

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