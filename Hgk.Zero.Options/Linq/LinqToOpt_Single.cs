using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <inheritdoc cref="Enumerable.ElementAt{TSource}(IEnumerable{TSource}, int)"/>
        public static TSource ElementAt<TSource>(this IOpt<TSource> source, int index)
        {
            if (index != 0) throw new ArgumentOutOfRangeException(nameof(index));
            return source.ToFixed().ElementAt(index);
        }

        /// <inheritdoc cref="Enumerable.ElementAtOrDefault{TSource}(IEnumerable{TSource}, int)"/>
        public static TSource ElementAtOrDefault<TSource>(this IOpt<TSource> source, int index)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (index == 0)
            {
                var opt = source.ToFixed();
                return opt.ValueOrDefault;
            }
            return default(TSource);
        }

        /// <summary>
        /// Returns the element at a specified index in an option or a default value if the index is
        /// out of range.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="index">The index of the element to retrieve.</param>
        /// <param name="defaultValue">
        /// A default value to return if <paramref name="index"/> is out of bounds.
        /// </param>
        /// <returns>
        /// <paramref name="defaultValue"/> if the index is outside the bounds of <paramref
        /// name="source"/>; otherwise, the element at the specified position in <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource ElementAtOrDefault<TSource>(this IOpt<TSource> source, int index, TSource defaultValue)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (index == 0)
            {
                var opt = source.ToFixed();
                if (opt.HasValue)
                {
                    return opt.ValueOrDefault;
                }
            }
            return defaultValue;
        }

        /// <inheritdoc cref="Enumerable.First{TSource}(IEnumerable{TSource})"/>
        public static TSource First<TSource>(this IOpt<TSource> source) => source.Single();

        /// <inheritdoc cref="Enumerable.First{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource First<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Single(predicate);

        /// <inheritdoc cref="Enumerable.FirstOrDefault{TSource}(IEnumerable{TSource})"/>
        public static TSource FirstOrDefault<TSource>(this IOpt<TSource> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.FirstOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource FirstOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.SingleOrDefault(predicate);

        /// <summary>
        /// Returns the first element of an option, or a default value if the option contains no elements.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="defaultValue">A default value to return if <paramref name="source"/> contains no elements.</param>
        /// <returns><paramref name="defaultValue"/> if <paramref name="source"/> is empty; otherwise, the first element in <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource FirstOrDefault<TSource>(this IOpt<TSource> source, TSource defaultValue) => source.SingleOrDefault(defaultValue);

        /// <summary>
        /// Returns the first element of the option that satisfies a condition or a default value if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="defaultValue">A default value to return if <paramref name="source"/> contains no elements that satisfy <paramref name="predicate"/>.</param>
        /// <returns><paramref name="defaultValue"/> if <paramref name="source"/> is empty or if no element passes the test specified by <paramref name="predicate"/>; otherwise, the first element in <paramref name="source"/> that passes the test specified by <paramref name="predicate"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource FirstOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate, TSource defaultValue) => source.SingleOrDefault(predicate, defaultValue);

        /// <inheritdoc cref="Enumerable.Last{TSource}(IEnumerable{TSource})"/>
        public static TSource Last<TSource>(this IOpt<TSource> source) => source.Single();

        /// <inheritdoc cref="Enumerable.Last{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource Last<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Single(predicate);

        /// <inheritdoc cref="Enumerable.LastOrDefault{TSource}(IEnumerable{TSource})"/>
        public static TSource LastOrDefault<TSource>(this IOpt<TSource> source) => source.SingleOrDefault();

        /// <inheritdoc cref="Enumerable.LastOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource LastOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.SingleOrDefault(predicate);

        /// <summary>
        /// Returns the last element of an option, or a default value if the option contains no elements.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="defaultValue">A default value to return if <paramref name="source"/> contains no elements.</param>
        /// <returns><paramref name="defaultValue"/> if <paramref name="source"/> is empty; otherwise, the last element in <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource LastOrDefault<TSource>(this IOpt<TSource> source, TSource defaultValue) => source.SingleOrDefault(defaultValue);

        /// <summary>
        /// Returns the last element of an option that satisfies a condition or a default value if no such element is found.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="defaultValue">A default value to return if <paramref name="source"/> contains no elements that satisfy <paramref name="predicate"/>.</param>
        /// <returns><paramref name="defaultValue"/> if the option is empty or if no elements pass the test in the predicate function; otherwise, the last element that passes the test in the predicate function.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource LastOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate, TSource defaultValue) => source.SingleOrDefault(predicate, defaultValue);

        /// <inheritdoc cref="Enumerable.Single{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource Single<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return (opt.HasValue && predicate(opt.ValueOrDefault)) ? opt.ValueOrDefault : throw Error.NoMatch();
        }

        /// <inheritdoc cref="Enumerable.Single{TSource}(IEnumerable{TSource})"/>
        public static TSource Single<TSource>(this IOpt<TSource> source)
        {
            var opt = source.ToFixed();
            return opt.HasValue ? opt.ValueOrDefault : throw Error.NoElements();
        }

        /// <summary>
        /// Returns the only element of an option, or a default value if the option is empty.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="defaultValue">A default value to return if <paramref name="source"/> contains no elements.</param>
        /// <returns>The single element of the input option, or <paramref name="defaultValue"/> if the option contains no elements.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource SingleOrDefault<TSource>(this IOpt<TSource> source, TSource defaultValue)
        {
            var opt = source.ToFixed();
            return opt.HasValue ? opt.ValueOrDefault : defaultValue;
        }

        /// <summary>
        /// Returns the only element of an option that satisfies a specified condition or a default value if no such element exists.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="defaultValue">A default value to return if <paramref name="source"/> contains no elements that satisfy <paramref name="predicate"/>.</param>
        /// <returns>The single element of the input option that satisfies the condition, or <paramref name="defaultValue"/> if no such element is found.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource SingleOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return (opt.HasValue && predicate(opt.ValueOrDefault)) ? opt.ValueOrDefault : defaultValue;
        }

        /// <inheritdoc cref="Enumerable.SingleOrDefault{TSource}(IEnumerable{TSource})"/>
        public static TSource SingleOrDefault<TSource>(this IOpt<TSource> source)
        {
            var opt = source.ToFixed();
            return opt.ValueOrDefault;
        }

        /// <inheritdoc cref="Enumerable.SingleOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
        public static TSource SingleOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return (opt.HasValue && predicate(opt.ValueOrDefault)) ? opt.ValueOrDefault : default(TSource);
        }
    }
}