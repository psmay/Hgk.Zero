using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <inheritdoc cref="Enumerable.Skip{TSource}(IEnumerable{TSource}, int)"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Skip<TSource>(this IOpt<TSource> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return (count <= 0) ? source : Opt.Empty<TSource>();
        }

        /// <inheritdoc cref="Enumerable.SkipWhile{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> SkipWhile<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereNotRaw(predicate));
        }

        /// <inheritdoc cref="Enumerable.SkipWhile{TSource}(IEnumerable{TSource}, Func{TSource, int, bool})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> SkipWhile<TSource>(this IOpt<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereNotRaw(predicate));
        }

        /// <inheritdoc cref="Enumerable.Take{TSource}(IEnumerable{TSource}, int)"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Take<TSource>(this IOpt<TSource> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return (count >= 1) ? source : Opt.Empty<TSource>();
        }

        /// <inheritdoc cref="Enumerable.TakeWhile{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> TakeWhile<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereRaw(predicate));
        }

        /// <inheritdoc cref="Enumerable.TakeWhile{TSource}(IEnumerable{TSource}, Func{TSource, int, bool})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> TakeWhile<TSource>(this IOpt<TSource> source, Func<TSource, int, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.MetaSelect(opt => opt.WhereRaw(predicate));
        }
    }
}