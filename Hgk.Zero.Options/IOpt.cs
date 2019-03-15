using Hgk.Zero.Options.Linq;
using System;
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
    /// cref="LinqToOpt.Cast{TResult}(IOpt)"/>, which forcibly casts the contained value to the
    /// specified type if necessary, or <see cref="LinqToOpt.OfType{TResult}(IOpt)"/>, which produces
    /// an empty option if the contained value cannot be cast to the specified type.
    /// </para>
    /// <para>
    /// <see cref="IOpt"/> implements the non-generic <see cref="IEnumerable"/>. The contract of this
    /// interface requires that the enumerator returned from <see cref="IEnumerable.GetEnumerator"/>
    /// produces either zero values, if the option is empty, or one value, if the option is full.
    /// Behavior is undefined if the enumerable produces more than one value.
    /// </para>
    /// <para>
    /// In general, this interface should not be directly implemented in an application. Refer to
    /// <see cref="IOpt{T}"/> for preferred ways to obtain an option.
    /// </para>
    /// </remarks>
    /// <seealso cref="IOpt{T}"/>
    public interface IOpt : IEnumerable
    {
        /// <summary>
        /// Resolves the <see cref="object"/>-typed contents of this option, producing a result using
        /// the specified result selector function.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The resolver function accepts two parameters: A has-value flag and a value. (These values
        /// roughly correspond to <see cref="LinqToOpt.Any{TSource}(IOpt{TSource})"/> and <see
        /// cref="LinqToOpt.SingleOrDefault{TSource}(IOpt{TSource})"/>, respectively.)
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If this option contains a value, the has-value flag is <see langword="true"/> and the
        /// value parameter is the contained value.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If this option is empty, the has-value flag is <see langword="false"/> and the value
        /// parameter is undefined. (The caller must not use the value of the value parameter. In
        /// order to prevent accidental misbehavior, the implementation should supply <see
        /// langword="null"/>, but this is not required.)
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <typeparam name="TResult">The return type of <paramref name="resultSelector"/>.</typeparam>
        /// <param name="resultSelector">
        /// A transform function that accepts a has-value flag and a value.
        /// </param>
        /// <returns>
        /// The result of calling <paramref name="resultSelector"/> on the current resolved state of
        /// this option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        TResult ResolveUntypedOption<TResult>(Func<bool, object, TResult> resultSelector);
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
    /// <para>In general, this interface should not be directly implemented in an application. Instead:</para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// If the contained value is known immediately, use the fixed option type <see cref="Opt{T}"/>.
    /// An instance can be created using static methods of <see cref="Opt"/> including <see
    /// cref="Opt.Create{T}(T)"/>, <see cref="Opt.Full{T}(T)"/>, and <see cref="Opt.Empty{T}"/>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the contained value is not yet determined and should be deferred, use <see
    /// cref="Opt.Defer{T}(Func{Opt{T}})"/> to create a deferred option based on a function that
    /// returns a fixed option.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the contained value is the first element, last element, an element at a particular index,
    /// or the only element of an <see cref="IEnumerable{T}"/>, use <see
    /// cref="EnumerableToOpt.WhereFirst{TSource}(IEnumerable{TSource})"/>, <see
    /// cref="EnumerableToOpt.WhereLast{TSource}(IEnumerable{TSource})"/>, <see
    /// cref="EnumerableToOpt.WhereElementAt{TSource}(IEnumerable{TSource}, int)"/>, or <see
    /// cref="EnumerableToOpt.WhereSingle{TSource}(IEnumerable{TSource})"/>, respectively, to obtain
    /// a deferred option containing the indicated element.
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <typeparam name="T">The type of value that may be contained in this option.</typeparam>
    /// <seealso cref="IOpt"/>
    public interface IOpt<out T> : IOpt, IEnumerable<T>
    {
        /// <summary>
        /// Resolves the contents of this option, producing a result using the specified result
        /// selector function.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The resolver function accepts two parameters: A has-value flag and a value. (These values
        /// roughly correspond to <see cref="LinqToOpt.Any{TSource}(IOpt{TSource})"/> and <see
        /// cref="LinqToOpt.SingleOrDefault{TSource}(IOpt{TSource})"/>, respectively.)
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If this option contains a value, the has-value flag is <see langword="true"/> and the
        /// value parameter is the contained value.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If this option is empty, the has-value flag is <see langword="false"/> and the value
        /// parameter is undefined. (The caller must not use the value of the value parameter. In
        /// order to prevent accidental misbehavior, the implementation should supply <see
        /// langword="default"/>( <typeparamref name="T"/>), but this is not required.)
        /// </description>
        /// </item>
        /// </list>
        /// </remarks>
        /// <typeparam name="TResult">The return type of <paramref name="resultSelector"/>.</typeparam>
        /// <param name="resultSelector">
        /// A transform function that accepts a has-value flag and a value.
        /// </param>
        /// <returns>
        /// The result of calling <paramref name="resultSelector"/> on the current resolved state of
        /// this option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        TResult ResolveOption<TResult>(Func<bool, T, TResult> resultSelector);
    }
}
