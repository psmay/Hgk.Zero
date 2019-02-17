using System;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// A complete deferred single result option based on the return value of a callback (use <see
    /// cref="SingleResultOpt.DeferRaw{TSource}(Func{FixedSingleResultOpt{TSource}})"/> to instantiate).
    /// </summary>
    internal class DeferredSingleResultOpt<T> : AbstractSingleResultOpt<T>
    {
        private readonly Func<FixedSingleResultOpt<T>> toFixedSingleResultOptFunction;

        public DeferredSingleResultOpt(Func<FixedSingleResultOpt<T>> toFixedSingleResultOptFunction)
        {
            this.toFixedSingleResultOptFunction = toFixedSingleResultOptFunction;
        }

        public override FixedSingleResultOpt<T> ToFixedSingleResultOpt() => toFixedSingleResultOptFunction();
    }
}