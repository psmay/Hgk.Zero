using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <inheritdoc cref="Enumerable.All{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static bool All<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return opt.HasValue ? predicate(opt.ValueOrDefault) : true;
        }

        /// <inheritdoc cref="Enumerable.Any{TSource}(IEnumerable{TSource})"/>
        public static bool Any<TSource>(this IOpt<TSource> source) => source.ToFixed().HasValue;

        /// <inheritdoc cref="Enumerable.Any{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static bool Any<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return opt.HasValue ? predicate(opt.ValueOrDefault) : false;
        }

        /// <inheritdoc cref="Enumerable.Count{TSource}(IEnumerable{TSource})"/>
        public static int Count<TSource>(this IOpt<TSource> source) => source.Any() ? 1 : 0;

        /// <inheritdoc cref="Enumerable.Count{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static int Count<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Any(predicate) ? 1 : 0;

        /// <inheritdoc cref="Enumerable.LongCount{TSource}(IEnumerable{TSource})"/>
        public static long LongCount<TSource>(this IOpt<TSource> source) => source.Count();

        /// <inheritdoc cref="Enumerable.LongCount{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static long LongCount<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Count(predicate);
    }
}