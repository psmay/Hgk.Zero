using System;
using System.Collections.Generic;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// Facilities to manipulate single result options.
    /// </summary>
    /// <seealso cref="ISingleResultOpt"/>
    /// <seealso cref="ISingleResultOpt{T}"/>
    /// <seealso cref="Query.EnumerableToOpt.WhereSingle{TSource}(IEnumerable{TSource})"/>
    /// <seealso cref="Query.EnumerableToOpt.WhereSingle{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
    public static class SingleResultOpt
    {
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
            return Opt.Defer(() => source.Match(ifZero, ifOne, ifMoreThanOne));
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
        public static IOpt<TSource> ReplaceIfMoreThanOne<TSource>(this ISingleResultOpt<TSource> source, Func<Opt<TSource>> replacementFactory)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (replacementFactory == null) throw new ArgumentNullException(nameof(replacementFactory));
            return Opt.Defer(() => ReplaceIfMoreThanOneCore(source, Opt.Defer(replacementFactory)));
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
            return Opt.Defer(() => ReplaceIfMoreThanOneCore(source, replacement));
        }

        internal static DeferredSingleResultOpt<TSource> Defer<TSource>(Func<FixedSingleResultOpt<TSource>> toFixedSingleResultOptFunction)
        {
            return new DeferredSingleResultOpt<TSource>(toFixedSingleResultOptFunction);
        }

        internal static bool Equals(SingleResultQuantity quantityA, object valueOrDefaultA, SingleResultQuantity quantityB, object valueOrDefaultB)
        {
            if (quantityA == quantityB)
            {
                switch (quantityA)
                {
                    case SingleResultQuantity.Zero:
                        return true;

                    case SingleResultQuantity.One:
                        return Equals(valueOrDefaultA, valueOrDefaultB);

                    case SingleResultQuantity.MoreThanOne:
                        return false;

                    default:
                        throw Error.InvalidSingleResultQuantity();
                }
            }
            return false;
        }

        internal static bool EqualsObject(ISingleResultOpt a, object b)
        {
            if (a == b)
            {
                return true;
            }
            else if (a == null || b == null)
            {
                return false;
            }
            else if (b is ISingleResultOpt singleResultOptB)
            {
                return EqualsSingleResultOpt(a, singleResultOptB);
            }
            else if (b is IOpt optB)
            {
                return EqualsOpt(a, optB);
            }
            else
            {
                return false;
            }
        }

        internal static bool EqualsOpt(ISingleResultOpt a, IOpt b)
        {
            if (a == b)
            {
                return true;
            }
            else if (a == null || b == null)
            {
                return false;
            }
            else
            {
                var fixedA = a.ToFixedSingleResultOpt();
                var fixedB = b.ToFixedSingleResultOpt();
                return Equals(fixedA, fixedB);
            }
        }

        internal static bool EqualsSingleResultOpt(ISingleResultOpt a, ISingleResultOpt b)
        {
            if (a == b)
            {
                return true;
            }
            else if (a == null || b == null)
            {
                return false;
            }
            else
            {
                var xa = a.ToFixedSingleResultOpt();
                var xb = b.ToFixedSingleResultOpt();
                return Equals(xa.Quantity, xa.ValueOrDefault, xb.Quantity, xb.ValueOrDefault);
            }
        }

        internal static IEnumerator<T> GetEnumerator<T>(SingleResultQuantity quantity, T valueOrDefault, bool usingPredicate)
        {
            switch (quantity)
            {
                case SingleResultQuantity.Zero:
                    break;

                case SingleResultQuantity.One:
                    yield return valueOrDefault;
                    break;

                case SingleResultQuantity.MoreThanOne:
                    throw Error.MoreThanOneResult(usingPredicate);
                default:
                    throw Error.InvalidSingleResultQuantity();
            }
        }

        internal static FixedSingleResultOpt<TSource> GetFixedFromOpt<TSource>(Opt<TSource> source, bool usingPredicate) =>
            GetFixedFromValue(source.HasValue, source.ValueOrDefault, usingPredicate);

        internal static FixedSingleResultOpt<TSource> GetFixedFromValue<TSource>(bool hasValue, TSource valueOrDefault, bool usingPredicate) =>
            new FixedSingleResultOpt<TSource>(hasValue ? SingleResultQuantity.One : SingleResultQuantity.Zero, usingPredicate, valueOrDefault);

        internal static FixedSingleResultOpt<TSource> GetFixedMoreThanOne<TSource>(bool usingPredicate) =>
            new FixedSingleResultOpt<TSource>(SingleResultQuantity.MoreThanOne, usingPredicate);

        internal static FixedSingleResultOpt<TSource> GetFixedOne<TSource>(bool usingPredicate, TSource value) =>
            new FixedSingleResultOpt<TSource>(SingleResultQuantity.One, usingPredicate, value);

        internal static FixedSingleResultOpt<TSource> GetFixedZero<TSource>(bool usingPredicate) =>
            new FixedSingleResultOpt<TSource>(SingleResultQuantity.Zero, usingPredicate);

        internal static TResult Match<T, TResult>(SingleResultQuantity quantity, T valueOrDefault, Func<TResult> ifZero, Func<T, TResult> ifOne, Func<TResult> ifMoreThanOne)
        {
            switch (quantity)
            {
                case SingleResultQuantity.Zero:
                    if (ifZero == null) throw Error.MatchCaseFailed();
                    return ifZero();

                case SingleResultQuantity.One:
                    if (ifOne == null) throw Error.MatchCaseFailed();
                    return ifOne(valueOrDefault);

                case SingleResultQuantity.MoreThanOne:
                    if (ifMoreThanOne == null) throw Error.MatchCaseFailed();
                    return ifMoreThanOne();

                default:
                    throw Error.InvalidSingleResultQuantity();
            }
        }

        internal static Opt<T> ToFixed<T>(SingleResultQuantity quantity, T valueOrDefault, bool usingPredicate)
        {
            switch (quantity)
            {
                case SingleResultQuantity.Zero:
                    return Opt.Empty<T>();

                case SingleResultQuantity.One:
                    return Opt.Full(valueOrDefault);

                case SingleResultQuantity.MoreThanOne:
                    throw Error.MoreThanOneResult(usingPredicate);
                default:
                    throw Error.InvalidSingleResultQuantity();
            }
        }

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

                return source.Match(
                    ifZero: () => GetFixedZero<object>(usingPredicate),
                    ifOne: value => GetFixedOne(usingPredicate, value),
                    ifMoreThanOne: () => GetFixedMoreThanOne<object>(usingPredicate));
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
                return GetFixedFromOpt(source.ToFixed(), false);
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
                return GetFixedFromOpt(source.ToFixed(), false);
            }
        }

        internal static string ToString(SingleResultQuantity quantity, object valueOrDefault, bool usingPredicate)
        {
            var countText = QuantityToString(quantity, usingPredicate);

            if (quantity == SingleResultQuantity.One)
            {
                string valueOrDefaultString = string.Concat(valueOrDefault);

                return string.Format(OptStrings.SingleResultOptWithValue, countText, valueOrDefaultString);
            }
            else
            {
                return string.Format(OptStrings.SingleResultOptWithoutValue, countText);
            }
        }

        private static bool Equals(this FixedSingleResultOpt<object> fixedA, FixedSingleResultOpt<object> fixedB)
        {
            return Equals(fixedA.Quantity, fixedA.ValueOrDefault, fixedB.Quantity, fixedB.ValueOrDefault);
        }

        private static string QuantityToString(SingleResultQuantity quantity, bool usingPredicate)
        {
            if (usingPredicate)
            {
                switch (quantity)
                {
                    case SingleResultQuantity.Zero: return OptStrings.MatchesZero;
                    case SingleResultQuantity.One: return OptStrings.MatchesOne;
                    case SingleResultQuantity.MoreThanOne: return OptStrings.MatchesMoreThanOne;
                    default: throw Error.InvalidSingleResultQuantity();
                }
            }
            else
            {
                switch (quantity)
                {
                    case SingleResultQuantity.Zero: return OptStrings.ElementsZero;
                    case SingleResultQuantity.One: return OptStrings.ElementsOne;
                    case SingleResultQuantity.MoreThanOne: return OptStrings.ElementsMoreThanOne;
                    default: throw Error.InvalidSingleResultQuantity();
                }
            }
        }

        private static Opt<TSource> ReplaceIfMoreThanOneCore<TSource>(ISingleResultOpt<TSource> source, IOpt<TSource> replacement)
        {
            var x = source.ToFixedSingleResultOpt();
            switch (x.Quantity)
            {
                case SingleResultQuantity.Zero:
                    return Opt.Empty<TSource>();

                case SingleResultQuantity.One:
                    return Opt.Full(x.ValueOrDefault);

                case SingleResultQuantity.MoreThanOne:
                    return replacement.ToFixed();

                default:
                    throw Error.InvalidSingleResultQuantity();
            }
        }
    }
}