using Hgk.Zero.Options.Query;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// Type for results of a single-element filter operation which represents a result count of
    /// zero, one, or more than one element.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="ISingleResultOpt"/> is a supertype of <see cref="ISingleResultOpt{T}"/>, the type
    /// returned by the single-element filter operations <see
    /// cref="EnumerableToOpt.WhereSingle{TSource}(IEnumerable{TSource})"/> and <see
    /// cref="EnumerableToOpt.WhereSingle{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>. If
    /// such an operation finds zero elements or one element, a single-result option behaves the same
    /// as an ordinary <see cref="IOpt"/>. However, if such an operation finds more than one element,
    /// it behaves differently:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Resolving a single-result option as an ordinary option ( <see cref="IOpt"/>) or enumerable (
    /// <see cref="IEnumerable"/>) will result in an <see cref="InvalidOperationException"/>.
    /// Operations that resolve immediately (such as a <see langword="foreach"/> loop or <see
    /// cref="Opt.ToFixed(IOpt)"/>) will cause the exception to be thrown immediately, while deferred
    /// operations (such as <see cref="Opt.OfType{TResult}(IOpt)"/>) will cause the exception to be
    /// thrown when they are resolved themselves.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Explicit operations such as <see cref="Match{TResult}(Func{TResult}, Func{object, TResult},
    /// Func{TResult})"/> can be used to convert a single-result option to another kind of value
    /// without throwing an exception.
    /// </description>
    /// </item>
    /// </list>
    /// <para>The following is information about the contract for this interface.</para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="Match{TResult}(Func{TResult}, Func{object, TResult}, Func{TResult})"/> must be
    /// implemented as specified.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ISingleResultOpt"/> implements <see cref="IEnumerable"/>. The contract of this
    /// interface requires that the enumerator returned from <see cref="IEnumerable.GetEnumerator"/>
    /// behave as follows:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// If the operation produced no elements, the enumeration produces zero elements.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the operation produced one element, the enumeration produces that one element.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the operation produced more than one element, the enumeration throws <see
    /// cref="InvalidOperationException"/> instead of producing any elements. (The throwing of the
    /// exception should be deferred to the first <see cref="IEnumerator.MoveNext"/> rather than
    /// occurring immediately.)
    /// </description>
    /// </item>
    /// </list>
    /// <para>Behavior is undefined if the enumerable produces more than one value.</para>
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <seealso cref="ISingleResultOpt{T}"/>
    public interface ISingleResultOpt : IOpt
    {
        /// <summary>
        /// Converts this single result option to another value based on its contents.
        /// </summary>
        /// <typeparam name="TResult">The result type for this conversion.</typeparam>
        /// <param name="ifZero">
        /// A function to produce the result if this single result option represents a result of zero elements.
        /// </param>
        /// <param name="ifOne">
        /// A function to produce the result if this single result option represents a result of one
        /// element, which accepts that element as a parameter.
        /// </param>
        /// <param name="ifMoreThanOne">
        /// A function to produce the result if this single result option represents a result of more
        /// than one element.
        /// </param>
        /// <returns>
        /// The result of calling <paramref name="ifZero"/>, <paramref name="ifOne"/>, or <paramref
        /// name="ifMoreThanOne"/> if this single result option represents a result of zero, one, or
        /// more than one element, respectively.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="ifZero"/> is <see langword="null"/> and this single result option
        /// represents a result of zero elements, or <paramref name="ifOne"/> is <see
        /// langword="null"/> and this single result option represents a result of one element, or
        /// <paramref name="ifMoreThanOne"/> is <see langword="null"/> and this single result option
        /// represents a result of more than one element.
        /// </exception>
        TResult Match<TResult>(Func<TResult> ifZero = null, Func<object, TResult> ifOne = null, Func<TResult> ifMoreThanOne = null);
    }

    /// <summary>
    /// Generic type for results of a single-element filter operation which represents a result count
    /// of zero, one, or more than one element.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="ISingleResultOpt{T}"/> is the type returned by the single-element filter
    /// operations <see cref="EnumerableToOpt.WhereSingle{TSource}(IEnumerable{TSource})"/> and <see
    /// cref="EnumerableToOpt.WhereSingle{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>. If
    /// such an operation finds zero elements or one element, a single-result option behaves the same
    /// as an ordinary <see cref="IOpt{T}"/>. However, if such an operation finds more than one
    /// element, it behaves differently:
    /// </para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// Resolving a single-result option as an ordinary option ( <see cref="IOpt"/> or <see
    /// cref="IOpt{T}"/>) or enumerable ( <see cref="IEnumerable"/> or <see cref="IEnumerable{T}"/>)
    /// will result in an <see cref="InvalidOperationException"/>. Operations that resolve
    /// immediately (such as a <see langword="foreach"/> loop or <see
    /// cref="Opt.ToFixed{TSource}(IOpt{TSource})"/>) will cause the exception to be thrown
    /// immediately, while deferred operations (such as <see cref="Opt.Select{TSource,
    /// TResult}(IOpt{TSource}, Func{TSource, TResult})"/>) will cause the exception to be thrown
    /// when they are resolved themselves.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Explicit operations such as <see cref="Match{TResult}(Func{TResult}, Func{T, TResult},
    /// Func{TResult})"/> and methods from <see cref="SingleResultOpt"/> such as <see
    /// cref="SingleResultOpt.EmptyIfMoreThanOne{TSource}(ISingleResultOpt{TSource})"/> can be used
    /// to convert a single-result option to another kind of value without throwing an exception.
    /// </description>
    /// </item>
    /// </list>
    /// <para>The following is information about the contract for this interface.</para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// The interface <see cref="ISingleResultOpt"/> must be implemented as specified.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="Match{TResult}(Func{TResult}, Func{T, TResult}, Func{TResult})"/> must be
    /// implemented as specified.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="ISingleResultOpt{T}"/> implements <see cref="IEnumerable"/> and <see
    /// cref="IEnumerable{T}"/>. The contract of this interface requires that the enumerator returned
    /// from <see cref="IEnumerable.GetEnumerator"/> and <see cref="IEnumerable{T}.GetEnumerator"/>
    /// behave as follows:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// If the operation produced no elements, the enumeration produces zero elements.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the operation produced one element, the enumeration produces that one element.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// If the operation produced more than one element, the enumeration throws <see
    /// cref="InvalidOperationException"/> instead of producing any elements. (The throwing of the
    /// exception should be deferred to the first <see cref="IEnumerator.MoveNext"/> rather than
    /// occurring immediately.)
    /// </description>
    /// </item>
    /// </list>
    /// <para>Behavior is undefined if the enumerable produces more than one value.</para>
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <typeparam name="T">The type of value that may be contained in this option.</typeparam>
    /// <seealso cref="ISingleResultOpt"/>
    /// <seealso cref="EnumerableToOpt.WhereSingle{TSource}(IEnumerable{TSource})"/>
    /// <seealso cref="EnumerableToOpt.WhereSingle{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>
    public interface ISingleResultOpt<out T> : IOpt<T>, ISingleResultOpt
    {
        /// <summary>
        /// Converts this single result option to another value based on its contents.
        /// </summary>
        /// <typeparam name="TResult">The result type for this conversion.</typeparam>
        /// <param name="ifZero">
        /// A function to produce the result if this single result option represents a result of zero elements.
        /// </param>
        /// <param name="ifOne">
        /// A function to produce the result if this single result option represents a result of one
        /// element, which accepts that element as a parameter.
        /// </param>
        /// <param name="ifMoreThanOne">
        /// A function to produce the result if this single result option represents a result of more
        /// than one element.
        /// </param>
        /// <returns>
        /// The result of calling <paramref name="ifZero"/>, <paramref name="ifOne"/>, or <paramref
        /// name="ifMoreThanOne"/> if this single result option represents a result of zero, one, or
        /// more than one element, respectively.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// <paramref name="ifZero"/> is <see langword="null"/> and this single result option
        /// represents a result of zero elements, or <paramref name="ifOne"/> is <see
        /// langword="null"/> and this single result option represents a result of one element, or
        /// <paramref name="ifMoreThanOne"/> is <see langword="null"/> and this single result option
        /// represents a result of more than one element.
        /// </exception>
        TResult Match<TResult>(Func<TResult> ifZero = null, Func<T, TResult> ifOne = null, Func<TResult> ifMoreThanOne = null);
    }
}