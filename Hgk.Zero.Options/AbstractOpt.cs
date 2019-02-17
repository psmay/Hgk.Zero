using System;
using System.Collections;
using System.Collections.Generic;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// An abstract class that implements <see cref="IOpt{T}"/>, <see cref="IOptFixable{T}"/>, and
    /// <see cref="IEquatable{T}"/> based on the object returned by <see cref="ToFixed"/>.
    /// </summary>
    internal abstract class AbstractOpt<T> : IOpt<T>, IOptFixable<T>, IEquatable<IOpt>
    {
        public override bool Equals(object obj) => OptEquality.PlainOptEqualsObject(this, obj);

        public bool Equals(IOpt other) => OptEquality.PlainOptEqualsObject(this, other);

        public virtual IEnumerator<T> GetEnumerator() => new OptEnumerator<T>(this);

        public override int GetHashCode() => ToFixed().GetHashCode();

        public TResult ResolveOption<TResult>(Func<bool, T, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ToFixed().ResolveOptionRaw(resultSelector);
        }

        public TResult ResolveUntypedOption<TResult>(Func<bool, object, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ToFixed().ResolveUntypedOptionRaw(resultSelector);
        }

        public abstract Opt<T> ToFixed();

        public override string ToString() => ToFixed().ToString();

        IEnumerator IEnumerable.GetEnumerator() => UntypedGetEnumerator();

        Opt<object> IOptFixable.ToFixed() => UntypedToFixed();

        protected virtual IEnumerator UntypedGetEnumerator() => GetEnumerator();

        protected virtual Opt<object> UntypedToFixed() => ToFixed().UntypedToFixed();
    }
}