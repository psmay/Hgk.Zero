using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Applies an accumulator function over the elements of an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Since an option can only ever have zero elements or one element, <paramref name="func"/>
        /// is never called (but must still be supplied).
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="func">An accumulator function to be applied to an element of <paramref name="source"/>.</param>
        /// <returns>The final accumulator value, which is the single element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="func"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static TSource Aggregate<TSource>(this IOpt<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            return source.Single();
        }

        /// <summary>
        /// Applies an accumulator function over the elements of an option, using the specified seed value.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="seed">The initial value for the accumulator.</param>
        /// <param name="func">
        /// An accumulator function to be applied to the accumulator and an element of <paramref name="source"/>.
        /// </param>
        /// <returns>
        /// The final accumulator value, which is either <paramref name="seed"/>, if <paramref
        /// name="source"/> is empty, or the result of applying <paramref name="func"/> to <paramref
        /// name="seed"/> and the single element of <paramref name="source"/>, otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="func"/> is <see langword="null"/>.
        /// </exception>
        public static TAccumulate Aggregate<TSource, TAccumulate>(this IOpt<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (func == null) throw new ArgumentNullException(nameof(func));
            var opt = source.ToFixed();
            return opt.HasValue ? func(seed, opt.ValueOrDefault) : seed;
        }

        /// <summary>
        /// Applies an accumulator function over the elements of an option, using the specified seed
        /// value, and transforming the final result with the specified result selector.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="seed">The initial value for the accumulator.</param>
        /// <param name="func">
        /// An accumulator function to be applied to the accumulator and an element of <paramref name="source"/>.
        /// </param>
        /// <param name="resultSelector">
        /// A function to transform the accumulator value into the result.
        /// </param>
        /// <returns>
        /// The result of applying <paramref name="resultSelector"/> to the final accumulator value,
        /// which is either <paramref name="seed"/>, if <paramref name="source"/> is empty, or the
        /// result of applying <paramref name="func"/> to <paramref name="seed"/> and the single
        /// element of <paramref name="source"/>, otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/>, <paramref name="func"/>, or <paramref name="resultSelector"/>
        /// is <see langword="null"/>.
        /// </exception>
        public static TResult Aggregate<TSource, TAccumulate, TResult>(this IOpt<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return resultSelector(source.Aggregate(seed, func));
        }
    }
}