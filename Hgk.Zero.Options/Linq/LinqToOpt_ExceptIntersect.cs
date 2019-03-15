using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {

        /// <summary>
        /// Finds the elements of an option that do not appear in a sequence.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="first"/> and <paramref name="second"/>.
        /// </typeparam>
        /// <param name="first">An option whose elements are to be subtracted from.</param>
        /// <param name="second">A sequence of elements to subtract from <paramref name="first"/>.</param>
        /// <returns>
        /// An option equivalent to <paramref name="first"/>, if the element of <paramref
        /// name="first"/> does not appear in <paramref name="second"/>; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="first"/> or <paramref name="second"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> Except<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second) => first.Except(second, null);

        /// <summary>
        /// Finds the elements of an option that do not appear in a sequence, using the specified
        /// comparer to determine equality.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="first"/> and <paramref name="second"/>.
        /// </typeparam>
        /// <param name="first">An option whose elements are to be subtracted from.</param>
        /// <param name="second">A sequence of elements to subtract from <paramref name="first"/>.</param>
        /// <param name="comparer">
        /// A comparer to determine whether elements are equal. (If <see langword="null"/>, <see
        /// cref="EqualityComparer{T}.Default"/> is used.)
        /// </param>
        /// <returns>
        /// An option equivalent to <paramref name="first"/>, if the element of <paramref
        /// name="first"/> does not appear in <paramref name="second"/>; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="first"/> or <paramref name="second"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> Except<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            return first.MetaSelect(opt => opt.WhereNotRaw(value => second.Contains(value, comparer)));
        }


        /// <summary>
        /// Finds the elements of an option that also appear in a sequence.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="first"/> and <paramref name="second"/>.
        /// </typeparam>
        /// <param name="first">An option whose elements are to be compared.</param>
        /// <param name="second">A sequence of elements to be compared.</param>
        /// <returns>
        /// An option equivalent to <paramref name="first"/>, if the element of <paramref
        /// name="first"/> appears in <paramref name="second"/>; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="first"/> or <paramref name="second"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> Intersect<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second) => first.Intersect(second, null);

        /// <summary>
        /// Finds the elements of an option that also appear in a sequence, using the specified
        /// comparer to determine equality.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">
        /// The type of the elements of <paramref name="first"/> and <paramref name="second"/>.
        /// </typeparam>
        /// <param name="first">An option whose elements are to be compared.</param>
        /// <param name="second">A sequence of elements to be compared.</param>
        /// <param name="comparer">
        /// A comparer to determine whether elements are equal. (If <see langword="null"/>, <see
        /// cref="EqualityComparer{T}.Default"/> is used.)
        /// </param>
        /// <returns>
        /// An option equivalent to <paramref name="first"/>, if the element of <paramref
        /// name="first"/> appears in <paramref name="second"/>; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="first"/> or <paramref name="second"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> Intersect<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            return first.MetaSelect(opt => opt.WhereRaw(value => second.Contains(value, comparer)));
        }
    }
}