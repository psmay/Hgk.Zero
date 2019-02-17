using System;
using System.Collections;
using System.Collections.Generic;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// A fixed, immutable single result option.
    /// </summary>
    internal struct FixedSingleResultOpt<T> : ISingleResultOpt<T>, IOptFixable<T>, ISingleResultOptFixable<T>, IEquatable<IOpt>
    {
        internal FixedSingleResultOpt(bool isValidOption, bool hasValue, T value, bool usingPredicate)
        {
            IsValidOption = isValidOption;
            HasValue = isValidOption && hasValue;
            ValueOrDefault = hasValue ? value : default;
            UsingPredicate = usingPredicate;
        }

        internal bool HasValue { get; }
        internal bool IsValidOption { get; }
        internal bool UsingPredicate { get; }
        internal T ValueOrDefault { get; }

        public override bool Equals(object obj) => OptEquality.SingleResultOptEqualsObject(this, obj);

        public bool Equals(IOpt other) => OptEquality.SingleResultOptEqualsObject(this, other);

        public IEnumerator<T> GetEnumerator()
        {
            IEnumerable<T> x = ToFixed();
            return x.GetEnumerator();
        }

        public override int GetHashCode()
        {
            return IsValidOption
                ? (HasValue && ValueOrDefault != null)
                    ? ValueOrDefault.GetHashCode()
                    : 0
                : -1;
        }

        public TResult ResolveOption<TResult>(Func<bool, T, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ResolveOptionRaw(resultSelector);
        }

        public TResult ResolveSingleResultOption<TResult>(Func<bool, bool, T, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ResolveSingleResultOptionRaw(resultSelector);
        }

        public TResult ResolveUntypedOption<TResult>(Func<bool, object, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ResolveUntypedOptionRaw(resultSelector);
        }

        public TResult ResolveUntypedSingleResultOption<TResult>(Func<bool, bool, object, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ResolveUntypedSingleResultOptionRaw(resultSelector);
        }

        public Opt<T> ToFixed()
        {
            if (IsValidOption)
            {
                return Opt.Create(HasValue, ValueOrDefault);
            }
            throw Error.MoreThanOneResult(UsingPredicate);
        }

        public FixedSingleResultOpt<T> ToFixedSingleResultOpt() => this;

        public override string ToString()
        {
            var description = DescribeCount();

            if (HasValue)
            {
                return string.Format(OptStrings.SingleResultOptWithValue, description, ValueOrDefault);
            }
            else
            {
                return string.Format(OptStrings.SingleResultOptWithoutValue, description);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        Opt<object> IOptFixable.ToFixed()
        {
            if (IsValidOption)
            {
                return Opt.Create<object>(HasValue, ValueOrDefault);
            }
            throw Error.MoreThanOneResult(UsingPredicate);
        }

        FixedSingleResultOpt<object> ISingleResultOptFixable.ToFixedSingleResultOpt()
        {
            if (this is FixedSingleResultOpt<object> alreadyCorrect)
            {
                return alreadyCorrect;
            }
            return new FixedSingleResultOpt<object>(IsValidOption, HasValue, ValueOrDefault, UsingPredicate);
        }

        internal TResult ResolveOptionRaw<TResult>(Func<bool, T, TResult> resultSelector)
        {
            if (IsValidOption)
            {
                return resultSelector(HasValue, ValueOrDefault);
            }
            throw Error.MoreThanOneResult(UsingPredicate);
        }

        internal TResult ResolveSingleResultOptionRaw<TResult>(Func<bool, bool, T, TResult> resultSelector) =>
            resultSelector(IsValidOption, HasValue, ValueOrDefault);

        internal TResult ResolveUntypedOptionRaw<TResult>(Func<bool, object, TResult> resultSelector)
        {
            if (IsValidOption)
            {
                return resultSelector(HasValue, ValueOrDefault);
            }
            throw Error.MoreThanOneResult(UsingPredicate);
        }

        internal TResult ResolveUntypedSingleResultOptionRaw<TResult>(Func<bool, bool, object, TResult> resultSelector) =>
            resultSelector(IsValidOption, HasValue, ValueOrDefault);

        private string DescribeCount()
        {
            if (IsValidOption)
            {
                if (HasValue)
                {
                    return UsingPredicate ? OptStrings.MatchesOne : OptStrings.ElementsOne;
                }
                else
                {
                    return UsingPredicate ? OptStrings.MatchesZero : OptStrings.ElementsZero;
                }
            }
            else
            {
                return UsingPredicate ? OptStrings.MatchesMoreThanOne : OptStrings.ElementsMoreThanOne;
            }
        }
    }
}