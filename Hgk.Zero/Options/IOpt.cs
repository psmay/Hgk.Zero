using System.Collections;
using System.Collections.Generic;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// Type for options whose contained value type is not specified.
    /// </summary>
    /// <remarks>
    /// <para>
    /// An <see cref="IOpt"/> can be coerced to a typed option by using <see
    /// cref="Opt.Cast{TResult}(IOpt)"/>, which forcibly casts the contained value to the specified
    /// type if necessary, or <see cref="Opt.OfType{TResult}(IOpt)"/>, which produces an empty option
    /// if the contained value cannot be cast to the specified type.
    /// </para>
    /// <para>
    /// <see cref="IOpt"/> implements the non-generic <see cref="IEnumerable"/>. The contract of this
    /// interface requires that the enumerator returned from <see cref="IEnumerable.GetEnumerator"/>
    /// produces either zero values, if the option is empty, or one value, if the option is full.
    /// Behavior is undefined if the enumerable produces more than one value.
    /// </para>
    /// </remarks>
    /// <seealso cref="IOpt{T}"/>
    public interface IOpt : IEnumerable
    {
    }

    /// <summary>
    /// Generic type for options.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="IOpt{T}"/> implements <see cref="IEnumerable"/> and <see cref="IEnumerable{T}"/>.
    /// The contract of this interface requires that the enumerators returned from <see
    /// cref="IEnumerable.GetEnumerator"/> and <see cref="IEnumerable{T}.GetEnumerator"/> produce
    /// either zero values, if the option is empty, or one value, if the option is full. Behavior is
    /// undefined if the enumerable produces more than one value.
    /// </para>
    /// </remarks>
    /// <typeparam name="T">The type of value that may be contained in this option.</typeparam>
    /// <seealso cref="IOpt"/>
    public interface IOpt<out T> : IOpt, IEnumerable<T>
    {
    }
}