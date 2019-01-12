using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// Facilities to create and manipulate options.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This class contains a large number of LINQ-compatible methods. While all options are also
    /// enumerables, and can therefore be used with methods provided by <see cref="Enumerable"/>,
    /// most of the operators are specialized here for options in order to optimize the algorithms
    /// for use with zero- or one-element collections (such as <see
    /// cref="Opt.Distinct{TSource}(IOpt{TSource})"/>), and also to return options from operations
    /// guaranteed to return at most one element when performed on an option (such as <see
    /// cref="Opt.Zip{TFirst, TSecond, TResult}(IOpt{TFirst}, IEnumerable{TSecond}, Func{TFirst,
    /// TSecond, TResult})"/>). In general, the result of applying any LINQ operation in this class
    /// to an option is defined to be sequence-equal to the result of applying the same operation
    /// from <see cref="Enumerable"/> to the same option.
    /// </para>
    /// <para>
    /// Similarly to the methods in <see cref="Enumerable"/>, most option-returning methods in this
    /// class are implemented using deferred execution; that is, the query represented by the method
    /// is not actually executed until the contents of the result are resolved directly, for example,
    /// by enumeration, using foreach, or calling a method such as <see
    /// cref="ToFixed{TSource}(IOpt{TSource})"/> or <see cref="Match{TSource,
    /// TResult}(IOpt{TSource}, Func{TResult}, Func{TSource, TResult})"/>.
    /// </para>
    /// <para>
    /// Some methods instead use or return <see cref="Opt{T}"/>, which is a type for fixed, immutable
    /// options. The contents of these are immediate and not deferred.
    /// </para>
    /// </remarks>
    public static partial class Opt
    {
        /// <summary>
        /// Returns this option typed as <see cref="IOpt{T}"/>.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">An option to type as <see cref="IOpt{T}"/>.</param>
        /// <returns><paramref name="source"/>, typed as <see cref="IOpt{T}"/>.</returns>
        public static IOpt<TSource> AsIOpt<TSource>(this IOpt<TSource> source) => source;

        /// <summary>
        /// Creates a fixed option with the same contents as the specified <see cref="Nullable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The non-nullable basis type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value to be contained in the new option, if not <see langword="null"/>.</param>
        /// <returns>
        /// An option that contains the <see cref="Nullable{T}.Value"/> of <paramref name="value"/>,
        /// if present; otherwise, an empty option.
        /// </returns>
        /// <seealso cref="Create{T}(T)"/>
        /// <seealso cref="Empty{T}"/>
        /// <seealso cref="Full{T}(T)"/>
        /// <seealso cref="Create{T}(bool, T)"/>
        public static Opt<T> Create<T>(T? value) where T : struct => value.HasValue ? Full(value.Value) : Empty<T>();

        /// <summary>
        /// Creates a fixed option which contains the specified value, if it is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value to be contained in the new option, if not <see langword="null"/>.</param>
        /// <returns>
        /// An option that contains <paramref name="value"/> if it is not <see langword="null"/>;
        /// otherwise, an empty option.
        /// </returns>
        /// <seealso cref="Create{T}(T?)"/>
        /// <seealso cref="Empty{T}"/>
        /// <seealso cref="Full{T}(T)"/>
        /// <seealso cref="Create{T}(bool, T)"/>
        public static Opt<T> Create<T>(T value) where T : class => new Opt<T>(value != null, value);

        /// <summary>
        /// Creates a fixed option which contains the specified value, if a flag is set.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="hasValue">A flag to determine whether to produce a full option.</param>
        /// <param name="value">
        /// The value to be contained in the new option, if <paramref name="hasValue"/> is <see langword="true"/>.
        /// </param>
        /// <returns>
        /// An option that contains <paramref name="value"/>, if <paramref name="hasValue"/> is <see
        /// langword="true"/>; otherwise, an empty option.
        /// </returns>
        /// <seealso cref="Create{T}(T)"/>
        /// <seealso cref="Create{T}(T?)"/>
        /// <seealso cref="Empty{T}"/>
        /// <seealso cref="Full{T}(T)"/>
        public static Opt<T> Create<T>(bool hasValue, T value) => new Opt<T>(hasValue, value);

        /// <summary>
        /// Creates a fixed, empty option.
        /// </summary>
        /// <typeparam name="T">The element type of the new option.</typeparam>
        /// <returns>An empty option.</returns>
        /// <seealso cref="Full{T}(T)"/>
        /// <seealso cref="Create{T}(T)"/>
        /// <seealso cref="Create{T}(T?)"/>
        /// <seealso cref="Create{T}(bool, T)"/>
        public static Opt<T> Empty<T>() => new Opt<T>();

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

        /// <summary>
        /// Creates a fixed option that contains the specified value (even if the value is <see langword="null"/>).
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value to be contained in the new option.</param>
        /// <returns>An option that contains <paramref name="value"/>.</returns>
        /// <seealso cref="Empty{T}"/>
        /// <seealso cref="Create{T}(T)"/>
        /// <seealso cref="Create{T}(T?)"/>
        /// <seealso cref="Create{T}(bool, T)"/>
        public static Opt<T> Full<T>(T value) => new Opt<T>(true, value);

        /// <summary>
        /// Converts this option to another value based on its contents.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This operation is performed immediately rather than by deferred execution. Compare <see
        /// cref="MatchOpt"/>, which uses deferred execution.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The result type for this conversion.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="ifEmpty">A function to produce the result if this option is empty.</param>
        /// <param name="ifFull">
        /// A function to produce the result if this option is full, which accepts the contained
        /// element as a parameter.
        /// </param>
        /// <returns>
        /// The result of calling <paramref name="ifEmpty"/>, if this option is empty; otherwise, the
        /// result of calling <paramref name="ifFull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="ifEmpty"/> is <see langword="null"/> and this option is empty, or
        /// <paramref name="ifFull"/> is <see langword="null"/> and this option is full.
        /// </exception>
        public static TResult Match<TSource, TResult>(this IOpt<TSource> source, Func<TResult> ifEmpty = null, Func<TSource, TResult> ifFull = null)
        {
            var opt = source.ToFixed();
            if (opt.HasValue)
            {
                if (ifFull == null)
                {
                    throw Error.MatchCaseFailed();
                }
                return ifFull(opt.ValueOrDefault);
            }
            else
            {
                if (ifEmpty == null)
                {
                    throw Error.MatchCaseFailed();
                }
                return ifEmpty();
            }
        }

        /// <summary>
        /// Converts this option to another option based on its contents.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>Compare <see cref="Match"/>, which uses immediate execution.</para>
        /// </remarks>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The element type for the result of this conversion.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="ifEmpty">A function to produce the result if this option is empty.</param>
        /// <param name="ifFull">
        /// A function to produce the result if this option is full, which accepts the contained
        /// element as a parameter.
        /// </param>
        /// <returns>
        /// An option equivalent to the result of calling <paramref name="ifEmpty"/>, if this option
        /// is empty; otherwise, an option equivalent to the result of calling <paramref name="ifFull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="ifEmpty"/> is <see langword="null"/> and this option is empty, or
        /// <paramref name="ifFull"/> is <see langword="null"/> and this option is full.
        /// </exception>
        public static IOpt<TResult> MatchOpt<TSource, TResult>(this IOpt<TSource> source, Func<Opt<TResult>> ifEmpty = null, Func<TSource, Opt<TResult>> ifFull = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return Defer(() => source.Match(ifEmpty, ifFull));
        }

        /// <summary>
        /// Substitutes the result of a callback if this option is empty.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="replacementFactory">
        /// A function to produce the result if <paramref name="source"/> is empty.
        /// </param>
        /// <returns>
        /// An option equivalent to <paramref name="source"/>, if it is full;
        /// otherwise, an option equivalent to the result of calling <paramref name="replacementFactory"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="replacementFactory"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> ReplaceIfEmpty<TSource>(this IOpt<TSource> source, Func<IOpt<TSource>> replacementFactory)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (replacementFactory == null) throw new ArgumentNullException(nameof(replacementFactory));
            return Defer(() => source.ToFixed().ReplaceIfEmptyImmediate(replacementFactory));
        }

        /// <summary>
        /// Substitutes the specified replacement option if this option is empty.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <param name="replacement">
        /// An option to produce the result if <paramref name="source"/> is empty.
        /// </param>
        /// <returns>
        /// An option equivalent to <paramref name="source"/>, if it is full; otherwise, an option equivalent to <paramref name="replacement"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="replacement"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> ReplaceIfEmpty<TSource>(this IOpt<TSource> source, IOpt<TSource> replacement)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (replacement == null) throw new ArgumentNullException(nameof(replacement));
            return Defer(() => source.ToFixed().ReplaceIfEmptyImmediate(replacement));
        }

        /// <summary>
        /// Returns a fixed option reflecting the current state of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>A fixed option reflecting the current state of <paramref name="source"/>.</returns>
        public static Opt<object> ToFixed(this IOpt source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            else if (source is Opt<object> alreadyFixedSource)
            {
                return alreadyFixedSource;
            }
            else if (source is IOptFixable fixableSource)
            {
                return fixableSource.ToFixed();
            }
            else
            {
                return ToFixed(source.GetEnumerator());
            }
        }

        /// <summary>
        /// Returns a fixed option reflecting the current state of an option.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <returns>A fixed option reflecting the current state of <paramref name="source"/>.</returns>
        public static Opt<TSource> ToFixed<TSource>(this IOpt<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            else if (source is Opt<TSource> alreadyFixedSource)
            {
                return alreadyFixedSource;
            }
            else if (source is IOptFixable<TSource> fixableSource)
            {
                return fixableSource.ToFixed();
            }
            else
            {
                using (var se = source.GetEnumerator())
                {
                    return ToFixed(se);
                }
            }
        }

        /// <summary>
        /// Gets the value contained by an option, if it exists.
        /// </summary>
        /// <typeparam name="TSource">The element type of source.</typeparam>
        /// <param name="source">An option whose value to get.</param>
        /// <param name="value">
        /// When this method returns, is set to the value contained by <paramref name="source"/>, if
        /// any, or the default value of <typeparamref name="TSource"/>, otherwise.
        /// </param>
        /// <returns><see langword="true"/>, if source contains a value; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static bool TryGetValue<TSource>(this IOpt<TSource> source, out TSource value) =>
            source.ToFixed().TryGetValueRaw(out value);

        internal static bool Contains<TSource>(Opt<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            if (source.HasValue)
            {
                return (comparer ?? EqualityComparer<TSource>.Default).Equals(source.ValueOrDefault, value);
            }
            return false;
        }

        internal static DeferredOpt<TSource> Defer<TSource>(this Func<Opt<TSource>> toFixedFunction)
        {
            return new DeferredOpt<TSource>(toFixedFunction);
        }

        internal static bool EqualsObject(IOpt a, object b)
        {
            if (a == null)
            {
                return b == null;
            }
            else if (b is IOpt otherOpt)
            {
                return EqualsOpt(a, otherOpt);
            }
            else
            {
                return false;
            }
        }

        internal static bool EqualsOpt(IOpt a, IOpt b)
        {
            if (a == b)
            {
                return true;
            }
            else if (a == null || b == null)
            {
                return false;
            }
            else if (a is ISingleResultOpt singleResultA)
            {
                return SingleResultOpt.EqualsOpt(singleResultA, b);
            }
            else if (b is ISingleResultOpt singleResultB)
            {
                return SingleResultOpt.EqualsSingleResultOpt(a.ToFixedSingleResultOpt(), singleResultB);
            }
            else
            {
                var fixedA = a.ToFixed();
                var fixedB = b.ToFixed();
                if (fixedA.HasValue)
                {
                    return fixedB.HasValue && Equals(fixedA.ValueOrDefault, fixedB.ValueOrDefault);
                }
                else
                {
                    return !fixedB.HasValue;
                }
            }
        }

        internal static Opt<TSource> WhereRaw<TSource>(this Opt<TSource> source, Func<TSource, bool> predicate)
        {
            return (source.HasValue && predicate(source.ValueOrDefault)) ? source : Empty<TSource>();
        }

        private static Opt<TResult> Cast<TSource, TResult>(Opt<TSource> source)
        {
            return source.HasValue ? Full((TResult)(object)source.ValueOrDefault) : Empty<TResult>();
        }

        private static Opt<TSource> FlattenFixedOpt<TSource>(Opt<IOpt<TSource>> fixedOpt1)
        {
            if (fixedOpt1.HasValue)
            {
                var fixedOpt0 = fixedOpt1.ValueOrDefault.ToFixed();
                return fixedOpt0;
            }
            return Empty<TSource>();
        }

        private static Opt<TSource> FlattenFixedOpt<TSource>(Opt<Opt<TSource>> fixedOpt1)
        {
            if (fixedOpt1.HasValue)
            {
                var fixedOpt0 = fixedOpt1.ValueOrDefault;
                return fixedOpt0;
            }
            return Empty<TSource>();
        }

        private static IOpt<TSource> KeepIf<TSource>(this IOpt<TSource> source, bool condition) => condition ? source : Empty<TSource>();

        private static MetaSelectOpt<TSource, TResult> MetaSelect<TSource, TResult>(this IOpt<TSource> source, Func<Opt<TSource>, Opt<TResult>> metaselector)
        {
            return new MetaSelectOpt<TSource, TResult>(source, metaselector);
        }

        private static Opt<TResult> OfType<TResult>(bool hasValue, object valueOrDefault)
        {
            return hasValue && (valueOrDefault is TResult value) ? Full(value) : Empty<TResult>();
        }

        private static Opt<TResult> OfType<TSource, TResult>(Opt<TSource> source)
        {
            return OfType<TResult>(source.HasValue, source.ValueOrDefault);
        }

        private static Opt<TSource> ReplaceIfEmptyImmediate<TSource>(this Opt<TSource> source, Func<IOpt<TSource>> replacementFactory)
        {
            return source.HasValue ? source : replacementFactory().ToFixed();
        }

        private static Opt<TSource> ReplaceIfEmptyImmediate<TSource>(this Opt<TSource> source, IOpt<TSource> replacement)
        {
            return source.HasValue ? source : replacement.ToFixed();
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

        private static Opt<TResult> SelectRaw<TSource, TResult>(this Opt<TSource> source, Func<TSource, TResult> selector)
        {
            return source.HasValue ? Full(selector(source.ValueOrDefault)) : Empty<TResult>();
        }

        private static Opt<TResult> SelectRaw<TSource, TResult>(this Opt<TSource> source, Func<TSource, int, TResult> selector)
        {
            return source.HasValue ? Full(selector(source.ValueOrDefault, 0)) : Empty<TResult>();
        }

        // The proper response for Min() or Max() for an arbitrary unknown type.
        // If the source is empty and the type is non-nullable, throw a No-Elements exception.
        // If the source is empty and the type is nullable, return null.
        // Otherwise, return the contained value (even if it is null).
        private static TSource SingleOrNull<TSource>(this IOpt<TSource> source) => default(TSource) == null ? source.SingleOrDefault() : source.Single();

        // Performs the later half of the long-form SelectManyRaw.
        private static IOpt<TResult> SubSelect<TSource, TCollection, TResult>(TSource sourceElement, IOpt<TCollection> subCollection, Func<TSource, TCollection, TResult> resultSelector)
        {
            return subCollection.ToFixed().SelectRaw(subelement => resultSelector(sourceElement, subelement));
        }

        private static Opt<TSource> ToFixed<TSource>(IEnumerator<TSource> source)
        {
            if (source.MoveNext())
            {
                TSource value = source.Current;
                if (source.MoveNext())
                {
                    throw Error.OptionEnumeratorMoreThanOneElement();
                }
                else
                {
                    return Full(value);
                }
            }
            else
            {
                return Empty<TSource>();
            }
        }

        private static Opt<object> ToFixed(IEnumerator source)
        {
            if (source.MoveNext())
            {
                object value = source.Current;
                if (source.MoveNext())
                {
                    throw Error.OptionEnumeratorMoreThanOneElement();
                }
                else
                {
                    return Full(value);
                }
            }
            else
            {
                return Empty<object>();
            }
        }

        private static bool TryGetValueRaw<TSource>(this Opt<TSource> source, out TSource value)
        {
            value = source.ValueOrDefault;
            return source.HasValue;
        }

        private static Opt<TSource> WhereNotNull<TSource>(this Opt<TSource> source) where TSource : class =>
            source.HasValue && source.ValueOrDefault != null ? source : Empty<TSource>();

        private static Opt<TSource> WhereNotNull<TSource>(this Opt<TSource?> source) where TSource : struct =>
            (source.HasValue && source.ValueOrDefault.HasValue) ? Full(source.ValueOrDefault.Value) : Empty<TSource>();

        private static Opt<TSource> WhereNotRaw<TSource>(this Opt<TSource> source, Func<TSource, bool> predicate)
        {
            return (source.HasValue && !predicate(source.ValueOrDefault)) ? source : Empty<TSource>();
        }

        private static Opt<TSource> WhereNotRaw<TSource>(this Opt<TSource> source, Func<TSource, int, bool> predicate)
        {
            return (source.HasValue && !predicate(source.ValueOrDefault, 0)) ? source : Empty<TSource>();
        }

        private static Opt<TSource> WhereRaw<TSource>(this Opt<TSource> source, Func<TSource, int, bool> predicate)
        {
            return (source.HasValue && predicate(source.ValueOrDefault, 0)) ? source : Empty<TSource>();
        }
    }
}