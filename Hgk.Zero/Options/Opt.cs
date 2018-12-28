using System;
using System.Collections;
using System.Collections.Generic;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// Type for immutable options.
    /// </summary>
    /// <typeparam name="T">Contained type for options of this type.</typeparam>
    public struct Opt<T> : IOpt<T>, IEquatable<IOpt>, IList<T>, IReadOnlyList<T>
    {
        /// <summary>
        /// The value contained by this option, if <see cref="HasValue"/> is <see langword="true"/>;
        /// otherwise, the default value of <typeparamref name="T"/>.
        /// </summary>
        internal readonly T ValueOrDefault;

        /// <summary>
        /// Creates an immutable option. Instead of this, use <see cref="Opt.Create{T}(bool, T)"/>,
        /// <see cref="Opt.Create{T}(T)"/>, <see cref="Opt.Create{T}(T?)"/>, <see
        /// cref="Opt.Full{T}(T)"/>, or <see cref="Opt.Empty{T}"/> where applicable.
        /// </summary>
        internal Opt(bool hasValue, T value = default(T))
        {
            HasValue = hasValue;
            ValueOrDefault = hasValue ? value : default(T);
        }

        /// <summary>
        /// Gets whether this option contains a value.
        /// </summary>
        public bool HasValue { get; }

        /// <summary>
        /// Gets the value contained by this option.
        /// </summary>
        /// <exception cref="InvalidOperationException">This option is empty.</exception>
        public T Value => HasValue ? ValueOrDefault : throw Error.NoOptionValue();

        int ICollection<T>.Count => Count;

        int IReadOnlyCollection<T>.Count => Count;

        bool ICollection<T>.IsReadOnly => true;

        private int Count => HasValue ? 1 : 0;

        T IList<T>.this[int index] { get => ElementAt(index); set => throw new NotSupportedException(); }

        T IReadOnlyList<T>.this[int index] => ElementAt(index);

        /// <summary>
        /// Gets whether this option is equal to another object.
        /// </summary>
        /// <remarks>
        /// <para>This option is equal to another object if:</para>
        /// <list type="bullet">
        /// <item>the other object is not <see langword="null"/> and</item>
        /// <item>the other object is an instance of <see cref="IOpt"/> and</item>
        /// <item>
        /// either
        /// <list type="bullet">
        /// <item>this option is empty and the other option is also empty, or</item>
        /// <item>
        /// this option is full, the other option is full, and the contained values of this option
        /// and the other option are equal (by <see cref="object.Equals(object, object)"/>).
        /// </item>
        /// </list>
        /// </item>
        /// </list>
        /// <para>
        /// If <paramref name="obj"/> is an <see cref="ISingleResultOpt"/> that represents a result
        /// of more than one element, this returns <see langword="false"/> (rather than throwing an exception).
        /// </para>
        /// </remarks>
        /// <param name="obj">An object to compare this option to.</param>
        /// <returns>
        /// <see langword="true"/> if this option equals <paramref name="obj"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj) => Opt.EqualsObject(this, obj);

        /// <summary>
        /// Gets a hash code for this object based on its contents.
        /// </summary>
        /// <returns>A hash code for this option.</returns>
        public override int GetHashCode() =>
            (HasValue && (ValueOrDefault != null)) ? ValueOrDefault.GetHashCode() : 0;

        /// <summary>
        /// Gets a string representation for this option.
        /// </summary>
        /// <returns>A string representation for this option.</returns>
        public override string ToString() =>
            HasValue ? string.Concat("Opt.Full(", ValueOrDefault, ")") : "Opt.Empty()";

        void ICollection<T>.Add(T item) => throw new NotSupportedException();

        void ICollection<T>.Clear() => throw new NotSupportedException();

        bool ICollection<T>.Contains(T item) => Contains(item);

        void ICollection<T>.CopyTo(T[] array, int arrayIndex)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0) throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            if (arrayIndex > array.Length) throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            if (HasValue)
            {
                if (array.Length - arrayIndex < 1) throw Error.ArrayPlusOffTooSmall();
                array[arrayIndex] = ValueOrDefault;
            }
            // else, no-op
        }

        bool IEquatable<IOpt>.Equals(IOpt other) => Opt.EqualsOpt(this, other);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        int IList<T>.IndexOf(T item) => Contains(item) ? 0 : -1;

        void IList<T>.Insert(int index, T item) => throw new NotSupportedException();

        bool ICollection<T>.Remove(T item) => throw new NotSupportedException();

        void IList<T>.RemoveAt(int index) => throw new NotSupportedException();

        internal T ElementAt(int index) =>
            (HasValue && index == 0) ? ValueOrDefault : throw new ArgumentOutOfRangeException(nameof(index));

        internal Opt<object> UntypedToFixed() => new Opt<object>(HasValue, ValueOrDefault);

        private bool Contains(T item) => Opt.Contains(this, item, null);

        private IEnumerator<T> GetEnumerator()
        {
            if (HasValue)
            {
                yield return ValueOrDefault;
            }
        }
    }
}