using System;
using System.Collections.Generic;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        public static IOpt<TSource> OrderBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) => source.OrderByNoop(keySelector);

        public static IOpt<TSource> OrderBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector) => source.OrderByNoop(keySelector);

        public static IOpt<TSource> OrderByDescending<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector) => source.OrderByNoop(keySelector);

        public static IOpt<TSource> OrderByDescending<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) => source.OrderByNoop(keySelector);

        public static IOpt<TSource> ThenBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) => source.OrderByNoop(keySelector);

        public static IOpt<TSource> ThenBy<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector) => source.OrderByNoop(keySelector);

        public static IOpt<TSource> ThenByDescending<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector) => source.OrderByNoop(keySelector);

        public static IOpt<TSource> ThenByDescending<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey> comparer) => source.OrderByNoop(keySelector);

        private static IOpt<TSource> OrderByNoop<TSource, TKey>(this IOpt<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
            return source;
        }
    }
}