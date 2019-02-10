using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Converts this option to another value based on its contents.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This operation is performed immediately rather than by deferred execution. Compare <see
        /// cref="MatchOpt"/>, which uses deferred execution.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The result type for this conversion.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="ifEmpty">A function to produce the result if this option is empty.</param>
        /// <param name="ifFull">
        /// A function to produce the result if this option is full, which accepts the contained
        /// element as a parameter.
        /// </param>
        /// <returns>
        /// The result of calling <paramref name="ifEmpty"/>, if this option is empty; otherwise, the
        /// result of calling <paramref name="ifFull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="ifEmpty"/> is <see langword="null"/> and this option is empty, or
        /// <paramref name="ifFull"/> is <see langword="null"/> and this option is full.
        /// </exception>
        public static TResult Match<TSource, TResult>(this IOpt<TSource> source, Func<TResult> ifEmpty = null, Func<TSource, TResult> ifFull = null)
        {
            var opt = source.ToFixed();
            if (opt.HasValue)
            {
                if (ifFull == null)
                {
                    throw Error.MatchCaseFailed();
                }
                return ifFull(opt.ValueOrDefault);
            }
            else
            {
                if (ifEmpty == null)
                {
                    throw Error.MatchCaseFailed();
                }
                return ifEmpty();
            }
        }

        /// <summary>
        /// Converts this option to another option based on its contents.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>Compare <see cref="Match"/>, which uses immediate execution.</para>
        /// </remarks>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The element type for the result of this conversion.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="ifEmpty">A function to produce the result if this option is empty.</param>
        /// <param name="ifFull">
        /// A function to produce the result if this option is full, which accepts the contained
        /// element as a parameter.
        /// </param>
        /// <returns>
        /// An option equivalent to the result of calling <paramref name="ifEmpty"/>, if this option
        /// is empty; otherwise, an option equivalent to the result of calling <paramref name="ifFull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="ifEmpty"/> is <see langword="null"/> and this option is empty, or
        /// <paramref name="ifFull"/> is <see langword="null"/> and this option is full.
        /// </exception>
        public static IOpt<TResult> MatchOpt<TSource, TResult>(this IOpt<TSource> source, Func<Opt<TResult>> ifEmpty = null, Func<TSource, Opt<TResult>> ifFull = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return Opt.DeferRaw(() => source.Match(ifEmpty, ifFull));
        }
    }
}