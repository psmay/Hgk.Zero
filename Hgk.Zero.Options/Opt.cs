﻿using Hgk.Zero.Options.Linq;
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
        /// <item>
        /// <description>the other object is not <see langword="null"/> and</description>
        /// </item>
        /// <item>
        /// <description>the other object is an instance of <see cref="IOpt"/> and</description>
        /// </item>
        /// <item>
        /// <description>
        /// either
        /// <list type="bullet">
        /// <item>
        /// <description>this option is empty and the other option is also empty, or</description>
        /// </item>
        /// <item>
        /// <description>
        /// this option is full, the other option is full, and the contained values of this option
        /// and the other option are equal (by <see cref="object.Equals(object, object)"/>).
        /// </description>
        /// </item>
        /// </list>
        /// </description>
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
        public override bool Equals(object obj) => OptEquality.PlainOptEqualsObject(this, obj);

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

        /// <summary>
        /// Gets the value contained by this option, if it exists.
        /// </summary>
        /// <param name="value">
        /// When this method returns, is set to the value contained by this option, if any, or the
        /// default value of <typeparamref name="T"/>, otherwise.
        /// </param>
        /// <returns><see langword="true"/>, if source contains a value; otherwise, <see langword="false"/>.</returns>
        public bool TryGetValue(out T value)
        {
            value = ValueOrDefault;
            return HasValue;
        }

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

        bool IEquatable<IOpt>.Equals(IOpt other) => OptEquality.PlainOptEqualsObject(this, other);

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        int IList<T>.IndexOf(T item) => Contains(item) ? 0 : -1;

        void IList<T>.Insert(int index, T item) => throw new NotSupportedException();

        bool ICollection<T>.Remove(T item) => throw new NotSupportedException();

        void IList<T>.RemoveAt(int index) => throw new NotSupportedException();

        TResult IOpt<T>.ResolveOption<TResult>(Func<bool, T, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ResolveOptionRaw(resultSelector);
        }

        TResult IOpt.ResolveUntypedOption<TResult>(Func<bool, object, TResult> resultSelector)
        {
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return ResolveUntypedOptionRaw(resultSelector);
        }

        internal bool Contains(T value, IEqualityComparer<T> comparer) =>
            HasValue && comparer.DefaultIfNull().Equals(ValueOrDefault, value);

        internal T ElementAt(int index) =>
            (HasValue && index == 0) ? ValueOrDefault : throw new ArgumentOutOfRangeException(nameof(index));

        internal TResult ResolveOptionRaw<TResult>(Func<bool, T, TResult> resultSelector) => resultSelector(HasValue, ValueOrDefault);

        internal TResult ResolveUntypedOptionRaw<TResult>(Func<bool, object, TResult> resultSelector) => resultSelector(HasValue, ValueOrDefault);

        internal Opt<object> UntypedToFixed() => new Opt<object>(HasValue, ValueOrDefault);

        private bool Contains(T item) => Contains(item, null);

        private IEnumerator<T> GetEnumerator()
        {
            if (HasValue)
            {
                yield return ValueOrDefault;
            }
        }
    }
}