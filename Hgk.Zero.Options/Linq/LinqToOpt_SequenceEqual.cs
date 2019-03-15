using System;
using System.Collections.Generic;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Determines whether an option has an equal length and sequence of elements to a sequence.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="first"/> and <paramref name="second"/>.
        /// </typeparam>
        /// <param name="first">A source option.</param>
        /// <param name="second">A sequence whose contents to compare with those of <paramref name="first"/>.</param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="first"/> and <paramref name="second"/> are both
        /// empty or each of <paramref name="first"/> and <paramref name="second"/> contains exactly
        /// one element and those elements are equal; otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="first"/> or <paramref name="second"/> is null.
        /// </exception>
        public static bool SequenceEqual<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second) => first.SequenceEqual(second, null);

        /// <summary>
        /// Determines whether an option has an equal length and sequence of elements to a sequence.
        /// </summary>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="first"/> and <paramref name="second"/>.
        /// </typeparam>
        /// <param name="first">A source option.</param>
        /// <param name="second">A sequence whose contents to compare with those of <paramref name="first"/>.</param>
        /// <param name="comparer">
        /// A comparer to determine whether values are equal. (If <see langword="null"/>, <see
        /// cref="EqualityComparer{T}.Default"/> is used.)
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="first"/> and <paramref name="second"/> are both
        /// empty or each of <paramref name="first"/> and <paramref name="second"/> contains exactly
        /// one element and those elements are equal; otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="first"/> or <paramref name="second"/> is null.
        /// </exception>
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
                            return comparer.DefaultIfNull().Equals(opt.ValueOrDefault, onlyValue);
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
    }
}