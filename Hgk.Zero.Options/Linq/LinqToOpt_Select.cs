using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Produces a projection of an option by applying a transformation function to its contents.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The type of the elements of the result option.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// A full option containing the result of applying <paramref name="selector"/> to the
        /// element of <paramref name="source"/>, if <paramref name="source"/> is full; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> Select<TSource, TResult>(this IOpt<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MetaSelect(opt => opt.SelectRaw(selector));
        }

        /// <summary>
        /// Produces a projection of an option by applying a transformation function to its contents.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The type of the elements of the result option.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">
        /// A transform function applied to each element of <paramref name="source"/> and its index.
        /// </param>
        /// <returns>
        /// A full option containing the result of applying <paramref name="selector"/> to the
        /// element of <paramref name="source"/> and its index, if <paramref name="source"/> is full;
        /// otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> Select<TSource, TResult>(this IOpt<TSource> source, Func<TSource, int, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MetaSelect(opt => opt.SelectRaw(selector));
        }

        private static Opt<TResult> SelectRaw<TSource, TResult>(this Opt<TSource> source, Func<TSource, TResult> selector) =>
            source.HasValue ? Opt.Full(selector(source.ValueOrDefault)) : Opt.Empty<TResult>();

        private static Opt<TResult> SelectRaw<TSource, TResult>(this Opt<TSource> source, Func<TSource, int, TResult> selector) =>
            source.HasValue ? Opt.Full(selector(source.ValueOrDefault, 0)) : Opt.Empty<TResult>();

        private static IOpt<TResult> SelectRaw<TSource, TResult>(this IOpt<TSource> source, Func<TSource, TResult> selector) =>
            source.MetaSelect(opt => opt.SelectRaw(selector));
    }
}