using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <inheritdoc cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, TResult})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TResult> Select<TSource, TResult>(this IOpt<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MetaSelect(opt => opt.SelectRaw(selector));
        }

        /// <inheritdoc cref="Enumerable.Select{TSource, TResult}(IEnumerable{TSource}, Func{TSource, int, TResult})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TResult> Select<TSource, TResult>(this IOpt<TSource> source, Func<TSource, int, TResult> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MetaSelect(opt => opt.SelectRaw(selector));
        }

        private static Opt<TResult> SelectRaw<TSource, TResult>(this Opt<TSource> source, Func<TSource, TResult> selector)
        {
            return source.HasValue ? Opt.Full(selector(source.ValueOrDefault)) : Opt.Empty<TResult>();
        }

        private static Opt<TResult> SelectRaw<TSource, TResult>(this Opt<TSource> source, Func<TSource, int, TResult> selector)
        {
            return source.HasValue ? Opt.Full(selector(source.ValueOrDefault, 0)) : Opt.Empty<TResult>();
        }
    }
}