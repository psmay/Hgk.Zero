using System;
using System.Collections;
using System.Collections.Generic;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// An abstract single result option based on the implementation of ToFixedSingleResultOpt().
    /// </summary>
    internal abstract class AbstractSingleResultOpt<T> : ISingleResultOpt<T>, IOptFixable<T>, ISingleResultOptFixable<T>, IEquatable<IOpt>
    {
        public bool Equals(IOpt other) => OptEquality.SingleResultOptEqualsObject(this, other);

        public override bool Equals(object obj) => OptEquality.SingleResultOptEqualsObject(this, obj);

        public IEnumerator<T> GetEnumerator() => new OptEnumerator<T>(this);

        public override int GetHashCode() => ToFixedSingleResultOpt().GetHashCode();

        public TResult ResolveOption<TResult>(Func<bool, T, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ToFixedSingleResultOpt().ResolveOptionRaw(resultSelector);
        }

        public TResult ResolveSingleResultOption<TResult>(Func<bool, bool, T, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ToFixedSingleResultOpt().ResolveSingleResultOptionRaw(resultSelector);
        }

        public TResult ResolveUntypedOption<TResult>(Func<bool, object, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ToFixedSingleResultOpt().ResolveUntypedOptionRaw(resultSelector);
        }

        public TResult ResolveUntypedSingleResultOption<TResult>(Func<bool, bool, object, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ToFixedSingleResultOpt().ResolveUntypedSingleResultOptionRaw(resultSelector);
        }

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