using System;
using System.Collections;
using System.Collections.Generic;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// Enumerator that defers evaluation of the contained option until the first MoveNext. (Reset is
    /// supported; if used, the option will be reevaluated.)
    /// </summary>
    internal class OptEnumerator<T> : IEnumerator<T>
    {
        private bool isResolved = false;
        private IOpt<T> source;

        internal OptEnumerator(IOpt<T> source)
        {
            this.source = source;
        }

        public T Current { get; private set; } = default(T);

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            if (isResolved)
            {
                return false;
            }
            else
            {
                var fixedSource = source.ToFixed();
                var moved = fixedSource.HasValue;
                Current = fixedSource.ValueOrDefault;
                isResolved = true;
                return moved;
            }
        }

        public void Reset()
        {
            isResolved = false;
            Current = default(T);
        }

        void IDisposable.Dispose()
        {
            // not needed
        }
    }
}