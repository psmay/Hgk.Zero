using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Returns a full option containing either the same contents as a specified option, if it is
        /// full, or the default value for the type, if it is empty.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <returns>
        /// An option that is equivalent to <paramref name="source"/>, if <paramref name="source"/>
        /// is full; otherwise, a full option containing the <see langword="default"/> value for the type.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> DefaultIfEmpty<TSource>(this IOpt<TSource> source) => source.DefaultIfEmpty(default);

        /// <summary>
        /// Returns a full option containing either the same contents as a specified option, if it is
        /// full, or a specified default value, if it is empty.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="defaultValue">
        /// A default value for the result to contain if <paramref name="source"/> is empty.
        /// </param>
        /// <returns>
        /// An option that is equivalent to <paramref name="source"/>, if <paramref name="source"/>
        /// is full; otherwise, a full option containing <paramref name="defaultValue"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> DefaultIfEmpty<TSource>(this IOpt<TSource> source, TSource defaultValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.MetaSelect(opt => opt.HasValue ? opt : Opt.Full(defaultValue));
        }

        /// <summary>
        /// Substitutes the result of a callback if this option is empty.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="replacementFactory">
        /// A function to produce the result if <paramref name="source"/> is empty.
        /// </param>
        /// <returns>
        /// An option equivalent to <paramref name="source"/>, if it is full;
        /// otherwise, an option equivalent to the result of calling <paramref name="replacementFactory"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="replacementFactory"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> ReplaceIfEmpty<TSource>(this IOpt<TSource> source, Func<IOpt<TSource>> replacementFactory)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (replacementFactory == null) throw new ArgumentNullException(nameof(replacementFactory));
            return Opt.DeferRaw(() => source.ToFixed().ReplaceIfEmptyImmediate(replacementFactory));
        }

        /// <summary>
        /// Substitutes the specified replacement option if this option is empty.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="replacement">
        /// An option to produce the result if <paramref name="source"/> is empty.
        /// </param>
        /// <returns>
        /// An option equivalent to <paramref name="source"/>, if it is full; otherwise, an option equivalent to <paramref name="replacement"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="replacement"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> ReplaceIfEmpty<TSource>(this IOpt<TSource> source, IOpt<TSource> replacement)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (replacement == null) throw new ArgumentNullException(nameof(replacement));
            return Opt.DeferRaw(() => source.ToFixed().ReplaceIfEmptyImmediate(replacement));
        }

        private static Opt<TSource> ReplaceIfEmptyImmediate<TSource>(this Opt<TSource> source, Func<IOpt<TSource>> replacementFactory)
        {
            return source.HasValue ? source : replacementFactory().ToFixed();
        }

        private static Opt<TSource> ReplaceIfEmptyImmediate<TSource>(this Opt<TSource> source, IOpt<TSource> replacement)
        {
            return source.HasValue ? source : replacement.ToFixed();
        }
    }
}