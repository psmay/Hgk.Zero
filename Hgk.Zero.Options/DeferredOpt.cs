using System;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// A complete deferred option based on the return value of a callback (use <see
    /// cref="Opt.Defer{TSource}(Func{Opt{TSource}})"/> to instantiate).
    /// </summary>
    internal class DeferredOpt<T> : AbstractOpt<T>
    {
        private readonly Func<Opt<T>> toFixedFunction;

        internal DeferredOpt(Func<Opt<T>> toFixedFunction)
        {
            this.toFixedFunction = toFixedFunction;
        }

        public override Opt<T> ToFixed() => toFixedFunction();
    }
}