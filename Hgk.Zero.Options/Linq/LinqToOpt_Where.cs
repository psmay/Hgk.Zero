using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Filters the elements of an option to those that satisfy a predicate.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="predicate">A function to test an element of <paramref name="source"/>.</param>
        /// <returns>
        /// An option containing the same element as source, if <paramref name="source"/> is full and
        /// its element satisfies <paramref name="predicate"/>; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> Where<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereRaw(predicate));
        }

        /// <summary>
        /// Filters the elements of an option to those that satisfy a predicate.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="predicate">
        /// A function to test an element of <paramref name="source"/> and its index.
        /// </param>
        /// <returns>
        /// An option containing the same element as <paramref name="source"/>, if source is full and
        /// its element and index satisfy <paramref name="predicate"/>; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> Where<TSource>(this IOpt<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereRaw(predicate));
        }

        /// <summary>
        /// Filters the contents of an option to include only non- <see langword="null"/> values.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to filter.</param>
        /// <returns>
        /// An option equivalent to <paramref name="source"/>, if it is full and contains a non- <see
        /// langword="null"/> value; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> WhereNotNull<TSource>(this IOpt<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.MetaSelect(opt => opt.WhereNotNullRaw());
        }

        /// <summary>
        /// Filters the contents of an option to include only non- <see langword="null"/> values,
        /// converting the results to their non-nullable type.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">
        /// The non-nullable basis type of the type of the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">An option to filter.</param>
        /// <returns>
        /// An option containing the same value as source, if it is full and contains a non- <see
        /// langword="null"/> value; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> WhereNotNullSelectValue<TSource>(this IOpt<TSource?> source) where TSource : struct
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.MetaSelect(opt => opt.WhereNotNullSelectValueRaw());
        }

        internal static Opt<TSource> WhereRaw<TSource>(this Opt<TSource> source, Func<TSource, bool> predicate)
        {
            return (source.HasValue && predicate(source.ValueOrDefault)) ? source : Opt.Empty<TSource>();
        }

        private static Opt<TSource> WhereNotNullRaw<TSource>(this Opt<TSource> source) =>
            source.HasValue && source.ValueOrDefault != null ? source : Opt.Empty<TSource>();

        private static Opt<TSource> WhereNotNullSelectValueRaw<TSource>(this Opt<TSource?> source) where TSource : struct =>
            (source.HasValue && source.ValueOrDefault.HasValue) ? Opt.Full(source.ValueOrDefault.Value) : Opt.Empty<TSource>();

        private static Opt<TSource> WhereNotRaw<TSource>(this Opt<TSource> source, Func<TSource, bool> predicate)
        {
            return (source.HasValue && !predicate(source.ValueOrDefault)) ? source : Opt.Empty<TSource>();
        }

        private static Opt<TSource> WhereNotRaw<TSource>(this Opt<TSource> source, Func<TSource, int, bool> predicate)
        {
            return (source.HasValue && !predicate(source.ValueOrDefault, 0)) ? source : Opt.Empty<TSource>();
        }

        /// <summary>
        /// Gets a fixed option containing the element of source if it satisfies predicate, or an
        /// empty option if there is no such element.
        /// </summary>
        private static Opt<TSource> WhereOptRaw<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) =>
            Opt.Fix(source).WhereOptRaw(predicate);

        /// <summary>
        /// Gets a fixed option containing the element of source if it satisfies predicate, or an
        /// empty option if there is no such element.
        /// </summary>
        private static Opt<TSource> WhereOptRaw<TSource>(this Opt<TSource> source, Func<TSource, bool> predicate) =>
            source.HasValue && predicate(source.ValueOrDefault) ? source : Opt.Empty<TSource>();

        private static Opt<TSource> WhereRaw<TSource>(this Opt<TSource> source, Func<TSource, int, bool> predicate) =>
            (source.HasValue && predicate(source.ValueOrDefault, 0)) ? source : Opt.Empty<TSource>();

        private static IOpt<TSource> WhereRaw<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) =>
            source.MetaSelect(opt => opt.WhereRaw(predicate));
    }
}