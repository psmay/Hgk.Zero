using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Returns the element at a specified index in an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="index">The index of the element to retrieve.</param>
        /// <returns>The element at the specified position in <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="source"/> is empty or <paramref name="index"/> is nonzero.
        /// </exception>
        public static TSource ElementAt<TSource>(this IOpt<TSource> source, int index)
        {
            if (index != 0) throw new ArgumentOutOfRangeException(nameof(index));
            return source.ToFixed().ElementAt(index);
        }

        /// <summary>
        /// Returns the element at a specified index in an option or the type's default value if the
        /// index is out of range.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="index">The index of the element to retrieve.</param>
        /// <returns>
        /// The default value of <typeparamref name="TSource"/> if the index is outside the bounds of
        /// <paramref name="source"/>; otherwise, the element at the specified position in <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource ElementAtOrDefault<TSource>(this IOpt<TSource> source, int index)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (index == 0)
            {
                var opt = source.ToFixed();
                return opt.ValueOrDefault;
            }
            return default;
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

        /// <summary>
        /// Returns the first element of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <returns>The first element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static TSource First<TSource>(this IOpt<TSource> source) => source.Single();

        /// <summary>
        /// Returns the first element of an option that satisfies a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// The first element of <paramref name="source"/> that satisfies <paramref name="predicate"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="source"/> does not contain any element that satisfies <paramref name="predicate"/>.
        /// </exception>
        public static TSource First<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Single(predicate);

        /// <summary>
        /// Returns the first element of an option, or the default value for the type if the option
        /// is empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <returns>
        /// The first element of <paramref name="source"/>, or the default value for <typeparamref
        /// name="TSource"/> if <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource FirstOrDefault<TSource>(this IOpt<TSource> source) => source.SingleOrDefault();

        /// <summary>
        /// Returns the first element of an option, or a specified default value if the option is empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="defaultValue">
        /// A default value to return if <paramref name="source"/> contains no elements.
        /// </param>
        /// <returns>
        /// The first element of <paramref name="source"/>, or <paramref name="defaultValue"/> if
        /// <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource FirstOrDefault<TSource>(this IOpt<TSource> source, TSource defaultValue) => source.SingleOrDefault(defaultValue);

        /// <summary>
        /// Returns the first element of an option that satisfies a condition, or the default value
        /// for the type if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// The first element of <paramref name="source"/> that satisfies <paramref
        /// name="predicate"/>, or the default value for <typeparamref name="TSource"/> if no such
        /// element is found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static TSource FirstOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.SingleOrDefault(predicate);

        /// <summary>
        /// Returns the first element of an option that satisfies a condition, or a specified default
        /// value if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="defaultValue">
        /// A default value to return if <paramref name="source"/> contains no elements that satisfy
        /// <paramref name="predicate"/>.
        /// </param>
        /// <returns>
        /// The first element of <paramref name="source"/> that satisfies <paramref
        /// name="predicate"/>, or <paramref name="defaultValue"/> if no such element is found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static TSource FirstOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate, TSource defaultValue) => source.SingleOrDefault(predicate, defaultValue);

        /// <summary>
        /// Returns the first element of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <returns>The first element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static TSource Last<TSource>(this IOpt<TSource> source) => source.Single();

        /// <summary>
        /// Returns the first element of an option that satisfies a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// The first element of <paramref name="source"/> that satisfies <paramref name="predicate"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="source"/> does not contain any element that satisfies <paramref name="predicate"/>.
        /// </exception>
        public static TSource Last<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.Single(predicate);

        /// <summary>
        /// Returns the first element of an option, or the default value for the type if the option
        /// is empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <returns>
        /// The first element of <paramref name="source"/>, or the default value for <typeparamref
        /// name="TSource"/> if <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource LastOrDefault<TSource>(this IOpt<TSource> source) => source.SingleOrDefault();

        /// <summary>
        /// Returns the first element of an option, or a specified default value if the option is empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="defaultValue">
        /// A default value to return if <paramref name="source"/> contains no elements.
        /// </param>
        /// <returns>
        /// The first element of <paramref name="source"/>, or <paramref name="defaultValue"/> if
        /// <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource LastOrDefault<TSource>(this IOpt<TSource> source, TSource defaultValue) => source.SingleOrDefault(defaultValue);

        /// <summary>
        /// Returns the first element of an option that satisfies a condition, or the default value
        /// for the type if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// The first element of <paramref name="source"/> that satisfies <paramref
        /// name="predicate"/>, or the default value for <typeparamref name="TSource"/> if no such
        /// element is found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static TSource LastOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate) => source.SingleOrDefault(predicate);

        /// <summary>
        /// Returns the first element of an option that satisfies a condition, or a specified default
        /// value if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="defaultValue">
        /// A default value to return if <paramref name="source"/> contains no elements that satisfy
        /// <paramref name="predicate"/>.
        /// </param>
        /// <returns>
        /// The first element of <paramref name="source"/> that satisfies <paramref
        /// name="predicate"/>, or <paramref name="defaultValue"/> if no such element is found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static TSource LastOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate, TSource defaultValue) => source.SingleOrDefault(predicate, defaultValue);

        /// <summary>
        /// Returns the only element of an option.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <returns>The only element of <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="source"/> is empty.</exception>
        public static TSource Single<TSource>(this IOpt<TSource> source)
        {
            var opt = source.ToFixed();
            return opt.HasValue ? opt.ValueOrDefault : throw Error.NoElements();
        }

        /// <summary>
        /// Returns the only element of an option that satisfies a condition.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>The only element of <paramref name="source"/> that satisfies <paramref name="predicate"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="source"/> does not contain any element that satisfies <paramref name="predicate"/>.
        /// </exception>
        public static TSource Single<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return (opt.HasValue && predicate(opt.ValueOrDefault)) ? opt.ValueOrDefault : throw Error.NoMatch();
        }

        /// <summary>
        /// Returns the only element of an option, or the default value for the type if the option is empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <returns>
        /// The only element of <paramref name="source"/>, or the default value for <typeparamref
        /// name="TSource"/> if <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource SingleOrDefault<TSource>(this IOpt<TSource> source)
        {
            var opt = source.ToFixed();
            return opt.ValueOrDefault;
        }

        /// <summary>
        /// Returns the only element of an option, or a specified default value if the option is empty.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="defaultValue">
        /// A default value to return if <paramref name="source"/> contains no elements.
        /// </param>
        /// <returns>
        /// The only element of <paramref name="source"/>, or <paramref name="defaultValue"/> if
        /// <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static TSource SingleOrDefault<TSource>(this IOpt<TSource> source, TSource defaultValue)
        {
            var opt = source.ToFixed();
            return opt.HasValue ? opt.ValueOrDefault : defaultValue;
        }

        /// <summary>
        /// Returns the only element of an option that satisfies a condition, or the default value
        /// for the type if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>
        /// The only element of <paramref name="source"/> that satisfies <paramref
        /// name="predicate"/>, or the default value for <typeparamref name="TSource"/> if no such
        /// element is found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static TSource SingleOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return (opt.HasValue && predicate(opt.ValueOrDefault)) ? opt.ValueOrDefault : default;
        }

        /// <summary>
        /// Returns the only element of an option that satisfies a condition, or a specified default
        /// value if no such element is found.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <param name="defaultValue">
        /// A default value to return if <paramref name="source"/> contains no elements that satisfy
        /// <paramref name="predicate"/>.
        /// </param>
        /// <returns>
        /// The only element of <paramref name="source"/> that satisfies <paramref
        /// name="predicate"/>, or <paramref name="defaultValue"/> if no such element is found.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        public static TSource SingleOrDefault<TSource>(this IOpt<TSource> source, Func<TSource, bool> predicate, TSource defaultValue)
        {
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            var opt = source.ToFixed();
            return (opt.HasValue && predicate(opt.ValueOrDefault)) ? opt.ValueOrDefault : defaultValue;
        }
    }
}