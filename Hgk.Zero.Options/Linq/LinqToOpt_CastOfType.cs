using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <inheritdoc cref="Enumerable.Cast{TResult}(System.Collections.IEnumerable)"/>
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
        public static IOpt<TResult> Cast<TResult>(this IOpt source)
        {
            if (source is IOpt<TResult> alreadyCorrectSource)
            {
                return alreadyCorrectSource;
            }
            return Opt.DeferRaw(() => Cast<object, TResult>(source.ToFixed()));
        }

        /// <inheritdoc cref="Enumerable.OfType{TResult}(System.Collections.IEnumerable)"/>
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
        public static IOpt<TResult> OfType<TResult>(this IOpt source)
        {
            if (source is IOpt<TResult> alreadyCorrectSource)
            {
                return alreadyCorrectSource;
            }
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