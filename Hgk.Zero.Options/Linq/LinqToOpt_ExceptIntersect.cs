using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <inheritdoc cref="Enumerable.Except{TSource}(IEnumerable{TSource}, IEnumerable{TSource})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Except<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second) => first.Except(second, null);

        /// <inheritdoc cref="Enumerable.Except{TSource}(IEnumerable{TSource}, IEnumerable{TSource}, IEqualityComparer{TSource})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Except<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            return first.MetaSelect(opt => opt.WhereNotRaw(value => second.Contains(value, comparer)));
        }

        /// <inheritdoc cref="Enumerable.Intersect{TSource}(IEnumerable{TSource}, IEnumerable{TSource}, IEqualityComparer{TSource})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Intersect<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            return first.MetaSelect(opt => opt.WhereRaw(value => second.Contains(value, comparer)));
        }

        /// <inheritdoc cref="Enumerable.Intersect{TSource}(IEnumerable{TSource}, IEnumerable{TSource})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TSource> Intersect<TSource>(this IOpt<TSource> first, IEnumerable<TSource> second) => first.Intersect(second, null);
    }
}