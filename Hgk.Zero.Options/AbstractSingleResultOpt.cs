using System;
using System.Collections;
using System.Collections.Generic;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// An abstract class that implements <see cref="ISingleResultOpt{T}"/>, <see
    /// cref="IOptFixable{T}"/>, <see cref="ISingleResultOptFixable{T}"/>, and <see
    /// cref="IEquatable{T}"/> based on the object returned by <see cref="ToFixedSingleResultOpt"/>.
    /// </summary>
    internal abstract class AbstractSingleResultOpt<T> : ISingleResultOpt<T>, IOptFixable<T>, ISingleResultOptFixable<T>, IEquatable<IOpt>
    {
        public bool Equals(IOpt other) => SingleResultOpt.EqualsOpt(this, other);

        public override bool Equals(object obj) => SingleResultOpt.EqualsObject(this, obj);

        public IEnumerator<T> GetEnumerator() => new OptEnumerator<T>(this);

        public override int GetHashCode() => ToFixedSingleResultOpt().GetHashCode();

        public TResult Match<TResult>(Func<TResult> ifZero = null, Func<T, TResult> ifOne = null, Func<TResult> ifMoreThanOne = null) =>
            ToFixedSingleResultOpt().Match(ifZero, ifOne, ifMoreThanOne);

        public TResult Match<TResult>(Func<TResult> ifZero = null, Func<object, TResult> ifOne = null, Func<TResult> ifMoreThanOne = null) =>
            ToFixedSingleResultOpt().Match(ifZero, ifOne, ifMoreThanOne);

        public Opt<T> ToFixed() => ToFixedSingleResultOpt().ToFixed();

        public abstract FixedSingleResultOpt<T> ToFixedSingleResultOpt();

        public override string ToString() => ToFixedSingleResultOpt().ToString();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        Opt<object> IOptFixable.ToFixed()
        {
            IOptFixable untypedOptFixable = ToFixedSingleResultOpt();
            return untypedOptFixable.ToFixed();
        }

        FixedSingleResultOpt<object> ISingleResultOptFixable.ToFixedSingleResultOpt()
        {
            ISingleResultOptFixable untypedFixable = ToFixedSingleResultOpt();
            return untypedFixable.ToFixedSingleResultOpt();
        }
    }
}