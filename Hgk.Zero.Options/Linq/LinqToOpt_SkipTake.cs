using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Returns the remaining contents of an option after skipping a specified number of elements.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>
        /// If <paramref name="count"/> is zero or negative, no elements are skipped. If <paramref
        /// name="count"/> is greater than or equal to the number of elements of <paramref name="source"/>, all
        /// elements are skipped.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="count">The number of elements to skip.</param>
        /// <returns>
        /// <paramref name="source"/>, if <paramref name="count"/> is less than or equal to 0;
        /// otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> Skip<TSource>(this IOpt<TSource> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return (count <= 0) ? source : Opt.Empty<TSource>();
        }

        /// <summary>
        /// Returns the first element of an option that does not satisfy a predicate and all
        /// following elements.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>
        /// If all elements of <paramref name="source"/> satisfy <paramref name="predicate"/>, the
        /// result is empty.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// An empty option, if <paramref name="source"/> is empty or contains an element that
        /// satisfies <paramref name="predicate"/>; otherwise, an option with the same contents as
        /// <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> SkipWhile<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereNotRaw(predicate));
        }

        /// <summary>
        /// Returns the first element of an option that does not satisfy a predicate and all
        /// following elements.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>
        /// If all elements of <paramref name="source"/> satisfy <paramref name="predicate"/>, the
        /// result is empty.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="predicate">A function to test each element and its index for a condition.</param>
        /// <returns>
        /// An empty option, if <paramref name="source"/> is empty or contains an element that
        /// satisfies <paramref name="predicate"/>; otherwise, an option with the same contents as
        /// <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> SkipWhile<TSource>(this IOpt<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereNotRaw(predicate));
        }

        /// <summary>
        /// Returns the specified number of elements from an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>
        /// If <paramref name="count"/> is zero or negative, no elements are returned. If <paramref
        /// name="count"/> is greater than or equal to the number of elements of <paramref
        /// name="source"/>, all elements are returned.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="count">The number of elements to return.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> Take<TSource>(this IOpt<TSource> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return (count >= 1) ? source : Opt.Empty<TSource>();
        }

        /// <summary>
        /// Returns all elements of an option before the first element that does not satisfy a predicate.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>
        /// If no elements of <paramref name="source"/> satisfy <paramref name="predicate"/>, the
        /// result is empty.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// An empty option, if <paramref name="source"/> is empty or contains an element that does
        /// not satisfy <paramref name="predicate"/>; otherwise, an option with the same contents as
        /// <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> TakeWhile<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereRaw(predicate));
        }

        /// <summary>
        /// Returns all elements of an option before the first element that does not satisfy a predicate.
        /// </summary>
        /// <para>
        /// If no elements of <paramref name="source"/> satisfy <paramref name="predicate"/>, the
        /// result is empty.
        /// </para>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="predicate">A function to test each element and its index for a condition.</param>
        /// <returns>
        /// An empty option, if <paramref name="source"/> is empty or contains an element that does
        /// not satisfy <paramref name="predicate"/>; otherwise, an option with the same contents as
        /// <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> TakeWhile<TSource>(this IOpt<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereRaw(predicate));
        }
    }
}