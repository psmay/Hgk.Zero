using System;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Collapses an option containing another option into a single option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The element type of the inner option.</typeparam>
        /// <param name="source">An outer option containing an inner option.</param>
        /// <returns>
        /// An option equivalent to the inner option, if it exists; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> is <see langword="null"/> (immediate) or the element of
        /// <paramref name="source"/> is <see langword="null"/> (deferred).
        /// </exception>
        public static IOpt<TSource> Flatten<TSource>(this IOpt<IOpt<TSource>> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.MetaSelect(FlattenFixedOpt);
        }

        /// <summary>
        /// Collapses an option containing another option into a single option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The element type of the inner option.</typeparam>
        /// <param name="source">An outer option containing an inner option.</param>
        /// <returns>
        /// An option equivalent to the inner option, if it exists; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> Flatten<TSource>(this IOpt<Opt<TSource>> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.MetaSelect(FlattenFixedOpt);
        }

        /// <summary>
        /// Projects each element of an option to a new option and flattens the result.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements of the option returned by <paramref name="selector"/>.
        /// </typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">A transform function applied to each element of <paramref name="source"/>.</param>
        /// <returns>
        /// A full option equivalent to the result of applying <paramref name="selector"/> to the
        /// element of <paramref name="source"/>, if <paramref name="source"/> is full; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> SelectMany<TSource, TResult>(this IOpt<TSource> source, Func<TSource, IOpt<TResult>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MetaSelect(opt => opt.SelectManyRaw(selector));
        }

        /// <summary>
        /// Projects each element of an option to a new option and flattens the result.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">
        /// The type of the elements of the option returned by <paramref name="selector"/>.
        /// </typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="selector">
        /// A transform function applied to each element of <paramref name="source"/> and its index.
        /// </param>
        /// <returns>
        /// A full option equivalent to the result of applying <paramref name="selector"/> to the
        /// element of <paramref name="source"/> and its index, if <paramref name="source"/> is full;
        /// otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="selector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> SelectMany<TSource, TResult>(this IOpt<TSource> source, Func<TSource, int, IOpt<TResult>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MetaSelect(opt => opt.SelectManyRaw(selector));
        }

        /// <summary>
        /// Projects each element of an option to a new option and flattens the result, then applies
        /// a transform to the result elements.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TCollection">
        /// The type of the elements of the intermediate option produced by applying <paramref
        /// name="collectionSelector"/> to an element of <paramref name="source"/>.
        /// </typeparam>
        /// <typeparam name="TResult">The type of the elements of the result option.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="collectionSelector">
        /// A transform function applied to each element of <paramref name="source"/>.
        /// </param>
        /// <param name="resultSelector">
        /// A transform function applied to each element of each intermediate option returned by
        /// <paramref name="collectionSelector"/> and its corresponding element from <paramref name="source"/>.
        /// </param>
        /// <returns>
        /// A full option containing the result of applying <paramref name="resultSelector"/> to the
        /// element of <paramref name="source"/> and the element of the intermediate option produced
        /// by applying <paramref name="collectionSelector"/> to the element of <paramref
        /// name="source"/>, if <paramref name="source"/> is full and the intermediate option is also
        /// full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/>, <paramref name="collectionSelector"/>, or <paramref
        /// name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> SelectMany<TSource, TCollection, TResult>(this IOpt<TSource> source, Func<TSource, IOpt<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return source.MetaSelect(opt => SelectManyRaw(opt, collectionSelector, resultSelector));
        }

        /// <summary>
        /// Projects each element of an option to a new option and flattens the result, then applies
        /// a transform to the result elements.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TCollection">
        /// The type of the elements of the intermediate option produced by applying <paramref
        /// name="collectionSelector"/> to an element of <paramref name="source"/> and its index.
        /// </typeparam>
        /// <typeparam name="TResult">The type of the elements of the result option.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="collectionSelector">
        /// A transform function applied to each element of <paramref name="source"/>.
        /// </param>
        /// <param name="resultSelector">
        /// A transform function applied to each element of each intermediate option returned by
        /// <paramref name="collectionSelector"/> and its corresponding element from <paramref name="source"/>.
        /// </param>
        /// <returns>
        /// A full option containing the result of applying <paramref name="resultSelector"/> to the
        /// element of <paramref name="source"/> and the element of the intermediate option produced
        /// by applying <paramref name="collectionSelector"/> to the element of <paramref
        /// name="source"/> and its index, if <paramref name="source"/> is full and the intermediate
        /// option is also full; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/>, <paramref name="collectionSelector"/>, or <paramref
        /// name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> SelectMany<TSource, TCollection, TResult>(this IOpt<TSource> source, Func<TSource, int, IOpt<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return source.MetaSelect(opt => SelectManyRaw(opt, collectionSelector, resultSelector));
        }

        private static Opt<TSource> FlattenFixedOpt<TSource>(Opt<IOpt<TSource>> fixedOpt1)
        {
            if (fixedOpt1.HasValue)
            {
                var fixedOpt0 = fixedOpt1.ValueOrDefault.ToFixed();
                return fixedOpt0;
            }
            return Opt.Empty<TSource>();
        }

        private static Opt<TSource> FlattenFixedOpt<TSource>(Opt<Opt<TSource>> fixedOpt1)
        {
            if (fixedOpt1.HasValue)
            {
                var fixedOpt0 = fixedOpt1.ValueOrDefault;
                return fixedOpt0;
            }
            return Opt.Empty<TSource>();
        }

        private static Opt<TResult> SelectManyRaw<TSource, TResult>(this Opt<TSource> source, Func<TSource, IOpt<TResult>> selector) => FlattenFixedOpt(source.SelectRaw(selector));

        private static Opt<TResult> SelectManyRaw<TSource, TResult>(this Opt<TSource> source, Func<TSource, int, IOpt<TResult>> selector) => FlattenFixedOpt(source.SelectRaw(selector));

        private static Opt<TResult> SelectManyRaw<TSource, TCollection, TResult>(this Opt<TSource> source, Func<TSource, IOpt<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) => source.SelectManyRaw(element => SubSelect(element, collectionSelector(element), resultSelector));

        private static Opt<TResult> SelectManyRaw<TSource, TCollection, TResult>(this Opt<TSource> source, Func<TSource, int, IOpt<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) => source.SelectManyRaw(element => SubSelect(element, collectionSelector(element, 0), resultSelector));

        // Performs the later half of the long-form SelectManyRaw.
        private static IOpt<TResult> SubSelect<TSource, TCollection, TResult>(TSource sourceElement, IOpt<TCollection> subCollection, Func<TSource, TCollection, TResult> resultSelector) => subCollection.ToFixed().SelectRaw(subelement => resultSelector(sourceElement, subelement));
    }
}
