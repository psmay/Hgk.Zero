using System;
using System.Collections;
using System.Collections.Generic;

namespace Hgk.Zero.Options.Linq
{
    internal class OptGrouping<TKey, TElement> : IOptGrouping<TKey, TElement>, IOptFixable<TElement>, IList<TElement>, IReadOnlyList<TElement>
    {
        private readonly Opt<TElement> contents;
        private readonly TKey key;

        public OptGrouping(TKey key, Opt<TElement> contents)
        {
            this.key = key;
            this.contents = contents;
        }

        public bool IsReadOnly => true;
        public TKey Key => key;
        public int Count => ((IList<TElement>)contents).Count;

        public TElement this[int index]
        {
            get => ((IList<TElement>)contents)[index];
            set => throw new NotSupportedException();
        }

        public void Add(TElement item) => throw new NotSupportedException();

        public void Clear() => throw new NotSupportedException();

        public bool Contains(TElement item) => ((IList<TElement>)contents).Contains(item);

        public void CopyTo(TElement[] array, int arrayIndex) => ((IList<TElement>)contents).CopyTo(array, arrayIndex);

        public override bool Equals(object obj) => contents.Equals(obj);

        public IEnumerator<TElement> GetEnumerator() => ((IList<TElement>)contents).GetEnumerator();

        public override int GetHashCode() => contents.GetHashCode();

        public int IndexOf(TElement item) => ((IList<TElement>)contents).IndexOf(item);

        public void Insert(int index, TElement item) => throw new NotSupportedException();

        public bool Remove(TElement item) => throw new NotSupportedException();

        public void RemoveAt(int index) => throw new NotSupportedException();

        public TResult ResolveOption<TResult>(Func<bool, TElement, TResult> resultSelector) => ((IOpt<TElement>)contents).ResolveOption(resultSelector);

        public TResult ResolveUntypedOption<TResult>(Func<bool, object, TResult> resultSelector) => ((IOpt<TElement>)contents).ResolveUntypedOption(resultSelector);

        public Opt<TElement> ToFixed() => contents;

        public override string ToString() => contents.ToString();

        IEnumerator IEnumerable.GetEnumerator() => ((IList<TElement>)contents).GetEnumerator();

        Opt<object> IOptFixable.ToFixed() => contents.UntypedToFixed();
    }
}