using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <inheritdoc cref="Enumerable.Aggregate{TSource}(IEnumerable{TSource}, Func{TSource, TSource, TSource})"/>
        public static TSource Aggregate<TSource>(this IOpt<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            return source.Single();
        }

        /// <inheritdoc cref="Enumerable.Aggregate{TSource, TAccumulate}(IEnumerable{TSource}, TAccumulate, Func{TAccumulate, TSource, TAccumulate})"/>
        public static TAccumulate Aggregate<TSource, TAccumulate>(this IOpt<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            var opt = source.ToFixed();
            return opt.HasValue ? func(seed, opt.ValueOrDefault) : seed;
        }

        /// <inheritdoc cref="Enumerable.Aggregate{TSource, TAccumulate, TResult}(IEnumerable{TSource}, TAccumulate, Func{TAccumulate, TSource, TAccumulate}, Func{TAccumulate, TResult})"/>
        public static TResult Aggregate<TSource, TAccumulate, TResult>(this IOpt<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return resultSelector(source.Aggregate(seed, func));
        }
    }
}