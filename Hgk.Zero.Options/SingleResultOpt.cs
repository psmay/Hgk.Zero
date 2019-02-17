using System;
using System.Collections.Generic;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// Facilities to manipulate single result options.
    /// </summary>
    /// <seealso cref="ISingleResultOpt"/>
    /// <seealso cref="ISingleResultOpt{T}"/>
    /// <seealso cref="Linq.EnumerableToOpt.WhereSingle{TSource}(IEnumerable{TSource})"/>
    /// <seealso cref="Linq.EnumerableToOpt.WhereSingle{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
    public static class SingleResultOpt
    {
        /// <summary>
        /// Converts a single result option to another option, substituting a full option containing
        /// the specified default value if this option represents more than one result.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source single result option.</param>
        /// <param name="defaultValue">
        /// The value to be contained by the returned option if <paramref name="source"/> represents
        /// more than one result.
        /// </param>
        /// <returns>
        /// An option equivalent to <paramref name="source"/>, if it represents a result of zero or
        /// one element; otherwise, an option containing <paramref name="defaultValue"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> DefaultIfMoreThanOne<TSource>(this ISingleResultOpt<TSource> source, TSource defaultValue) =>
            source.ReplaceIfMoreThanOne(Opt.Full<TSource>(defaultValue));

        /// <summary>
        /// Converts a single result option to another option, substituting a full option containing
        /// the default value of the contained type if this option represents more than one result.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source single result option.</param>
        /// <returns>
        /// An option equivalent to <paramref name="source"/>, if it represents a result of zero or
        /// one element; otherwise, an option containing the default value of <typeparamref name="TSource"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> DefaultIfMoreThanOne<TSource>(this ISingleResultOpt<TSource> source) =>
            source.DefaultIfMoreThanOne(default(TSource));

        /// <summary>
        /// Converts a single result option to another option, substituting an empty option if this
        /// option represents more than one result.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source single result option.</param>
        /// <returns>
        /// An option equivalent to <paramref name="source"/>, if it represents a result of zero or
        /// one element; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> EmptyIfMoreThanOne<TSource>(this ISingleResultOpt<TSource> source) =>
            source.ReplaceIfMoreThanOne(Opt.Empty<TSource>());

        /// <summary>
        /// Immediately computes the result of any deferred computation represented by a single
        /// result option and returns a new single result option representing the final result.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source single result option.</param>
        /// <returns>
        /// A single result option representing the final result of any deferred computation
        /// represented by <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static ISingleResultOpt<TSource> ForceSingleResultOpt<TSource>(this ISingleResultOpt<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.ToFixedSingleResultOpt();
        }

        /// <summary>
        /// Immediately computes the result of any deferred computation represented by a single
        /// result option and returns a new single result option representing the final result.
        /// </summary>
        /// <param name="source">A source single result option.</param>
        /// <returns>
        /// A single result option representing the final result of any deferred computation
        /// represented by <paramref name="source"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static ISingleResultOpt ForceSingleResultOpt(this ISingleResultOpt source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.ToFixedSingleResultOpt();
        }

        /// <summary>
        /// Converts a single result option to another value based on its contents.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The type of the result of this conversion.</typeparam>
        /// <param name="source">A source single result option.</param>
        /// <param name="ifZero">
        /// A function to produce the result if <paramref name="source"/> represents a result of zero elements.
        /// </param>
        /// <param name="ifOne">
        /// A function to produce the result if <paramref name="source"/> represents a result of one
        /// element, which accepts that element as a parameter.
        /// </param>
        /// <param name="ifMoreThanOne">
        /// A function to produce the result if <paramref name="source"/> represents a result of more
        /// than one element.
        /// </param>
        /// <returns>
        /// The result of calling <paramref name="ifZero"/>, <paramref name="ifOne"/>, or <paramref
        /// name="ifMoreThanOne"/> if <paramref name="source"/> represents a result of zero, one, or
        /// more than one element, respectively.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="ifZero"/> is <see langword="null"/> and <paramref name="source"/>
        /// represents a result of zero elements, or <paramref name="ifOne"/> is <see
        /// langword="null"/> and <paramref name="source"/> represents a result of one element, or
        /// <paramref name="ifMoreThanOne"/> is <see langword="null"/> and <paramref name="source"/>
        /// represents a result of more than one element.
        /// </exception>
        public static TResult Match<TSource, TResult>(this ISingleResultOpt<TSource> source, Func<TResult> ifZero = null, Func<TSource, TResult> ifOne = null, Func<TResult> ifMoreThanOne = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return source.ResolveSingleResultOption((isValidOption, hasValue, value) =>
            {
                if (isValidOption)
                {
                    if (hasValue)
                    {
                        if (ifOne == null) throw Error.MatchCaseFailed();
                        return ifOne(value);
                    }
                    else
                    {
                        if (ifZero == null) throw Error.MatchCaseFailed();
                        return ifZero();
                    }
                }
                else
                {
                    if (ifMoreThanOne == null) throw Error.MatchCaseFailed();
                    return ifMoreThanOne();
                }
            });
        }

        /// <summary>
        /// Converts a single result option to another option based on its contents.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <typeparam name="TResult">The element type of the result option for this conversion.</typeparam>
        /// <param name="source">A source single result option.</param>
        /// <param name="ifZero">
        /// A function to produce the result if <paramref name="source"/> represents a result of zero elements.
        /// </param>
        /// <param name="ifOne">
        /// A function to produce the result if <paramref name="source"/> represents a result of one
        /// element, which accepts that element as a parameter.
        /// </param>
        /// <param name="ifMoreThanOne">
        /// A function to produce the result if <paramref name="source"/> represents a result of more
        /// than one element.
        /// </param>
        /// <returns>
        /// An option equivalent to the result of calling <paramref name="ifZero"/>, <paramref
        /// name="ifOne"/>, or <paramref name="ifMoreThanOne"/> if <paramref name="source"/>
        /// represents a result of zero, one, or more than one element, respectively.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="ifZero"/> is <see langword="null"/> and <paramref name="source"/>
        /// represents a result of zero elements, or <paramref name="ifOne"/> is <see
        /// langword="null"/> and <paramref name="source"/> represents a result of one element, or
        /// <paramref name="ifMoreThanOne"/> is <see langword="null"/> and <paramref name="source"/>
        /// represents a result of more than one element.
        /// </exception>
        public static IOpt<TResult> MatchOpt<TSource, TResult>(this ISingleResultOpt<TSource> source, Func<Opt<TResult>> ifZero = null, Func<TSource, Opt<TResult>> ifOne = null, Func<Opt<TResult>> ifMoreThanOne = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return Opt.DeferRaw(() => source.Match(ifZero, ifOne, ifMoreThanOne));
        }

        /// <summary>
        /// Converts a single result option to another option, substituting the result of a callback
        /// if this option represents more than one result.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source single result option.</param>
        /// <param name="replacementFactory">
        /// A function to produce the result if <paramref name="source"/> represents a result of more
        /// than one element.
        /// </param>
        /// <returns>
        /// An option equivalent to <paramref name="source"/>, if it represents a result of zero or
        /// one element; otherwise, an option equivalent to the result of calling <paramref name="replacementFactory"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="replacementFactory"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> ReplaceIfMoreThanOne<TSource>(this ISingleResultOpt<TSource> source, Func<IOpt<TSource>> replacementFactory)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (replacementFactory == null) throw new ArgumentNullException(nameof(replacementFactory));
            return Opt.DeferRaw(() => ReplaceIfMoreThanOneImmediate(source, Opt.DeferRaw(() => Opt.Fix(replacementFactory()))));
        }

        /// <summary>
        /// Converts a single result option to another option, substituting a specified option if
        /// this option represents more than one result.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source single result option.</param>
        /// <param name="replacement">
        /// An option to produce the result if <paramref name="source"/> represents a result of more
        /// than one element.
        /// </param>
        /// <returns>
        /// An option equivalent to <paramref name="source"/>, if it represents a result of zero or
        /// one element; otherwise, an option equivalent to <paramref name="replacement"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="replacement"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> ReplaceIfMoreThanOne<TSource>(this ISingleResultOpt<TSource> source, IOpt<TSource> replacement)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (replacement == null) throw new ArgumentNullException(nameof(replacement));
            return Opt.DeferRaw(() => ReplaceIfMoreThanOneImmediate(source, replacement));
        }

        internal static DeferredSingleResultOpt<TSource> DeferRaw<TSource>(Func<FixedSingleResultOpt<TSource>> toFixedSingleResultOptFunction)
        {
            return new DeferredSingleResultOpt<TSource>(toFixedSingleResultOptFunction);
        }

        internal static FixedSingleResultOpt<TSource> GetFixedFromOpt<TSource>(Opt<TSource> source, bool usingPredicate) =>
            GetFixedFromValue(source.HasValue, source.ValueOrDefault, usingPredicate);

        internal static FixedSingleResultOpt<TSource> GetFixedFromValue<TSource>(bool hasValue, TSource valueOrDefault, bool usingPredicate) =>
            new FixedSingleResultOpt<TSource>(true, hasValue, valueOrDefault, usingPredicate);

        internal static FixedSingleResultOpt<TSource> GetFixedMoreThanOne<TSource>(bool usingPredicate) =>
            new FixedSingleResultOpt<TSource>(false, false, default, usingPredicate);

        internal static FixedSingleResultOpt<TSource> GetFixedOne<TSource>(bool usingPredicate, TSource value) =>
            new FixedSingleResultOpt<TSource>(true, true, value, usingPredicate);

        internal static FixedSingleResultOpt<TSource> GetFixedZero<TSource>(bool usingPredicate) =>
            new FixedSingleResultOpt<TSource>(true, false, default, usingPredicate);

        internal static FixedSingleResultOpt<T> ToFixedSingleResultOpt<T>(this ISingleResultOpt<T> source)
        {
            if (source is FixedSingleResultOpt<T> alreadyFixed)
            {
                return alreadyFixed;
            }
            else if (source is ISingleResultOptFixable<T> fixable)
            {
                return fixable.ToFixedSingleResultOpt();
            }
            else
            {
                const bool usingPredicate = false;

                return source.Match(
                    ifZero: () => GetFixedZero<T>(usingPredicate),
                    ifOne: value => GetFixedOne(usingPredicate, value),
                    ifMoreThanOne: () => GetFixedMoreThanOne<T>(usingPredicate));
            }
        }

        internal static FixedSingleResultOpt<object> ToFixedSingleResultOpt(this ISingleResultOpt source)
        {
            if (source is FixedSingleResultOpt<object> alreadyFixed)
            {
                return alreadyFixed;
            }
            else if (source is ISingleResultOptFixable fixable)
            {
                return fixable.ToFixedSingleResultOpt();
            }
            else
            {
                const bool usingPredicate = false;

                return source.ResolveUntypedSingleResultOption((isValidOption, hasValue, valueOrDefault) =>
                    new FixedSingleResultOpt<object>(isValidOption, hasValue, valueOrDefault, usingPredicate));
            }
        }

        internal static FixedSingleResultOpt<T> ToFixedSingleResultOpt<T>(this IOpt<T> source)
        {
            if (source is FixedSingleResultOpt<T> alreadyFixedSingleResultOpt)
            {
                return alreadyFixedSingleResultOpt;
            }
            else if (source is ISingleResultOpt<T> singleResultOpt)
            {
                return singleResultOpt.ToFixedSingleResultOpt();
            }
            else
            {
                return GetFixedFromOpt(Opt.Fix(source), false);
            }
        }

        internal static FixedSingleResultOpt<object> ToFixedSingleResultOpt(this IOpt source)
        {
            if (source is FixedSingleResultOpt<object> alreadyFixedSingleResultOpt)
            {
                return alreadyFixedSingleResultOpt;
            }
            else if (source is ISingleResultOpt singleResultOpt)
            {
                return singleResultOpt.ToFixedSingleResultOpt();
            }
            else
            {
                return GetFixedFromOpt(Opt.FixUntyped(source), false);
            }
        }

        private static Opt<TSource> ReplaceIfMoreThanOneImmediate<TSource>(ISingleResultOpt<TSource> source, IOpt<TSource> replacement)
        {
            var x = source.ToFixedSingleResultOpt();
            if (x.IsValidOption)
            {
                return x.HasValue ? Opt.Full(x.ValueOrDefault) : Opt.Empty<TSource>();
            }
            else
            {
                return Opt.Fix(replacement);
            }
        }
    }
}