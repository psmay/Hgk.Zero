using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
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
    }
}