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
        public readonly SingleResultQuantity Quantity;
        internal T ValueOrDefault;
        private readonly bool usingPredicate;

        internal FixedSingleResultOpt(SingleResultQuantity quantity, bool usingPredicate, T value = default(T))
        {
            this.Quantity = quantity;
            this.usingPredicate = usingPredicate;

            switch (quantity)
            {
                case SingleResultQuantity.Zero:
                case SingleResultQuantity.MoreThanOne:
                    ValueOrDefault = default(T);
                    break;

                case SingleResultQuantity.One:
                    ValueOrDefault = value;
                    break;

                default:
                    throw Error.InvalidSingleResultQuantity();
            }
        }

        public override bool Equals(object obj) => SingleResultOpt.EqualsObject(this, obj);

        public bool Equals(IOpt other) => SingleResultOpt.EqualsOpt(this, other);

        public IEnumerator<T> GetEnumerator() => SingleResultOpt.GetEnumerator(Quantity, ValueOrDefault, usingPredicate);

        public override int GetHashCode()
        {
            switch (Quantity)
            {
                case SingleResultQuantity.Zero:
                    return 0;

                case SingleResultQuantity.One:
                    return ValueOrDefault == null ? 0 : ValueOrDefault.GetHashCode();

                case SingleResultQuantity.MoreThanOne:
                    return -1;

                default:
                    throw Error.InvalidSingleResultQuantity();
            }
        }

        public TResult Match<TResult>(Func<TResult> ifZero = null, Func<T, TResult> ifOne = null, Func<TResult> ifMoreThanOne = null) =>
                    SingleResultOpt.Match(Quantity, ValueOrDefault, ifZero, ifOne, ifMoreThanOne);

        public TResult Match<TResult>(Func<TResult> ifZero = null, Func<object, TResult> ifOne = null, Func<TResult> ifMoreThanOne = null) =>
            SingleResultOpt.Match(Quantity, ValueOrDefault, ifZero, ifOne, ifMoreThanOne);

        public Opt<T> ToFixed() => SingleResultOpt.ToFixed(Quantity, ValueOrDefault, usingPredicate);

        public FixedSingleResultOpt<T> ToFixedSingleResultOpt() => this;

        public override string ToString() => SingleResultOpt.ToString(Quantity, ValueOrDefault, usingPredicate);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        Opt<object> IOptFixable.ToFixed() => SingleResultOpt.ToFixed<object>(Quantity, ValueOrDefault, usingPredicate);

        FixedSingleResultOpt<object> ISingleResultOptFixable.ToFixedSingleResultOpt() => new FixedSingleResultOpt<object>(Quantity, usingPredicate, ValueOrDefault);
    }
}