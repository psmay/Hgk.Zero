using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Casts the elements of an option to the specified type.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>
        /// If <paramref name="source"/> is already an <see cref="IOpt{T}"/> with <typeparamref
        /// name="TResult"/> as its element type, it is returned unchanged.
        /// </para>
        /// </remarks>
        /// <typeparam name="TResult">The type to which to cast the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// An option having the same contents as <paramref name="source"/>, cast to <typeparamref name="TResult"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidCastException">
        /// <paramref name="source"/> is not empty and its element cannot be cast to <typeparamref
        /// name="TResult"/>. (Deferred.)
        /// </exception>
        public static IOpt<TResult> Cast<TResult>(this IOpt source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            if (source is IOpt<TResult> alreadyCorrectSource)
            {
                return alreadyCorrectSource;
            }
            return Opt.DeferRaw(() => Cast<object, TResult>(source.ToFixed()));
        }

        /// <summary>
        /// Filters the elements of an option to those of a specified type.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TResult">
        /// The type to which to filter the elements of <paramref name="source"/>.
        /// </typeparam>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// An option having the same contents as <paramref name="source"/>, if it contains an
        /// element that is of type <typeparamref name="TResult"/> (according to the <see
        /// langword="is"/> operator); otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TResult> OfType<TResult>(this IOpt source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return Opt.DeferRaw(() => OfType<object, TResult>(source.ToFixed()));
        }

        private static Opt<TResult> Cast<TSource, TResult>(Opt<TSource> source)
        {
            return source.HasValue ? Opt.Full((TResult)(object)source.ValueOrDefault) : Opt.Empty<TResult>();
        }

        private static Opt<TResult> OfType<TSource, TResult>(Opt<TSource> source)
        {
            return source.HasValue && (source.ValueOrDefault is TResult value) ? Opt.Full(value) : Opt.Empty<TResult>();
        }
    }
}