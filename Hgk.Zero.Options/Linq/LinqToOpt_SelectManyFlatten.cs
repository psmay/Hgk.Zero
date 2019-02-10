using System;
using System.Collections.Generic;
using System.Linq;

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
        /// <param name="source">An outer option containing an inner option option.</param>
        /// <returns>
        /// An option equivalent to the inner option, if it exists; otherwise, an empty option.
        /// </returns>
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
        /// <param name="source">An outer option containing an inner option option.</param>
        /// <returns>
        /// An option equivalent to the inner option, if it exists; otherwise, an empty option.
        /// </returns>
        public static IOpt<TSource> Flatten<TSource>(this IOpt<Opt<TSource>> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.MetaSelect(FlattenFixedOpt);
        }

        /// <inheritdoc cref="Enumerable.SelectMany{TSource, TCollection, TResult}(IEnumerable{TSource}, Func{TSource, int, IEnumerable{TCollection}}, Func{TSource, TCollection, TResult})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TResult> SelectMany<TSource, TCollection, TResult>(this IOpt<TSource> source, Func<TSource, int, IOpt<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return source.MetaSelect(opt => SelectManyRaw(opt, collectionSelector, resultSelector));
        }

        /// <inheritdoc cref="Enumerable.SelectMany{TSource, TCollection, TResult}(IEnumerable{TSource}, Func{TSource, IEnumerable{TCollection}}, Func{TSource, TCollection, TResult})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TResult> SelectMany<TSource, TCollection, TResult>(this IOpt<TSource> source, Func<TSource, IOpt<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return source.MetaSelect(opt => SelectManyRaw(opt, collectionSelector, resultSelector));
        }

        /// <inheritdoc cref="Enumerable.SelectMany{TSource, TResult}(IEnumerable{TSource}, Func{TSource, int, IEnumerable{TResult}})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TResult> SelectMany<TSource, TResult>(this IOpt<TSource> source, Func<TSource, int, IOpt<TResult>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MetaSelect(opt => opt.SelectManyRaw(selector));
        }

        /// <inheritdoc cref="Enumerable.SelectMany{TSource, TResult}(IEnumerable{TSource}, Func{TSource, IEnumerable{TResult}})"/>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        public static IOpt<TResult> SelectMany<TSource, TResult>(this IOpt<TSource> source, Func<TSource, IOpt<TResult>> selector)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MetaSelect(opt => opt.SelectManyRaw(selector));
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

        private static Opt<TResult> SelectManyRaw<TSource, TResult>(this Opt<TSource> source, Func<TSource, IOpt<TResult>> selector)
        {
            return FlattenFixedOpt(source.SelectRaw(selector));
        }

        private static Opt<TResult> SelectManyRaw<TSource, TResult>(this Opt<TSource> source, Func<TSource, int, IOpt<TResult>> selector)
        {
            return FlattenFixedOpt(source.SelectRaw(selector));
        }

        private static Opt<TResult> SelectManyRaw<TSource, TCollection, TResult>(this Opt<TSource> source, Func<TSource, IOpt<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return source.SelectManyRaw(element => SubSelect(element, collectionSelector(element), resultSelector));
        }

        private static Opt<TResult> SelectManyRaw<TSource, TCollection, TResult>(this Opt<TSource> source, Func<TSource, int, IOpt<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
        {
            return source.SelectManyRaw(element => SubSelect(element, collectionSelector(element, 0), resultSelector));
        }

        // Performs the later half of the long-form SelectManyRaw.
        private static IOpt<TResult> SubSelect<TSource, TCollection, TResult>(TSource sourceElement, IOpt<TCollection> subCollection, Func<TSource, TCollection, TResult> resultSelector)
        {
            return subCollection.ToFixed().SelectRaw(subelement => resultSelector(sourceElement, subelement));
        }
    }
}