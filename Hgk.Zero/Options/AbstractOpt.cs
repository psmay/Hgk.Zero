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
        public override bool Equals(object obj) => Opt.EqualsObject(this, obj);

        public bool Equals(IOpt other) => Opt.EqualsOpt(this, other);

        public virtual IEnumerator<T> GetEnumerator() => new OptEnumerator<T>(this);

        public override int GetHashCode() => ToFixed().GetHashCode();

        public abstract Opt<T> ToFixed();

        public override string ToString() => ToFixed().ToString();

        IEnumerator IEnumerable.GetEnumerator() => UntypedGetEnumerator();

        Opt<object> IOptFixable.ToFixed() => UntypedToFixed();

        protected virtual IEnumerator UntypedGetEnumerator() => GetEnumerator();

        protected virtual Opt<object> UntypedToFixed() => ToFixed().UntypedToFixed();
    }
}