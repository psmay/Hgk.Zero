using Hgk.Zero.Options.Linq;
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
    /// Operations that resolve immediately (such as a <see langword="foreach"/> loop, <see
    /// cref="IOpt.ResolveUntypedOption{TResult}(Func{bool, object, TResult})"/>, or <see
    /// cref="Opt.FixUntyped(IOpt)"/>) will cause the exception to be thrown immediately, while
    /// deferred operations (such as <see cref="LinqToOpt.OfType{TResult}(IOpt)"/>) will cause the
    /// exception to be thrown when they are resolved themselves.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Explicit operations such as <see cref="ResolveUntypedSingleResultOption{TResult}(Func{bool,
    /// bool, object, TResult})"/> can be used to convert a single-result option to another kind of
    /// value without throwing an exception.
    /// </description>
    /// </item>
    /// </list>
    /// <para>The following is information about the contract for this interface.</para>
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="ResolveUntypedSingleResultOption{TResult}(Func{bool, bool, object, TResult})"/>
    /// must be implemented as specified.
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
        /// Resolves the <see cref="object"/>-typed contents of this single result option, producing
        /// a result using the specified result selector.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The resolver function accepts three parameters: An is-valid-option flag, a has-value
        /// flag, and a value.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If this single result option represents one result, the is-valid-option flag and
        /// has-value flag are <see langword="true"/> and the value parameter is the result value.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If this single result option represents zero results, the is-valid-option flag is <see
        /// langword="true"/>, the has-value flag is <see langword="false"/>, and the value parameter
        /// is undefined.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If this single result option represents more than one result (and is thus not a valid
        /// option), the is-valid-option flag is <see langword="false"/> and the remaining parameters
        /// are undefined.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// If the has-value flag or the value parameter is undefined, the caller must not use their
        /// values. To prevent accidental misuse, the implementation should supply <see
        /// langword="false"/> or <see langword="null"/>, respectively, but this is not required.
        /// </para>
        /// </remarks>
        /// <typeparam name="TResult">The return type of <paramref name="resultSelector"/>.</typeparam>
        /// <param name="resultSelector">
        /// A transform function that accepts an is-valid-option flag, a has-value flag, and a value.
        /// </param>
        /// <returns>
        /// The result of calling resultSelector on the current resolved state of this single result option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        TResult ResolveUntypedSingleResultOption<TResult>(Func<bool, bool, object, TResult> resultSelector);
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
    /// immediately (such as a <see langword="foreach"/> loop, <see
    /// cref="IOpt{T}.ResolveOption{TResult}(Func{bool, T, TResult})"/>, or <see
    /// cref="Opt.Fix{TSource}(IOpt{TSource})"/>) will cause the exception to be thrown immediately,
    /// while deferred operations (such as <see cref="LinqToOpt.Select{TSource,
    /// TResult}(IOpt{TSource}, Func{TSource, TResult})"/>) will cause the exception to be thrown
    /// when they are resolved themselves.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// Explicit operations such as <see cref="ResolveSingleResultOption{TResult}(Func{bool, bool, T,
    /// TResult})"/> and methods from <see cref="SingleResultOpt"/> such as <see
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
    /// <see cref="ResolveSingleResultOption{TResult}(Func{bool, bool, T, TResult})"/> must be
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
        /// Resolves the contents of this single result option, producing a result using the
        /// specified result selector.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The resolver function accepts three parameters: An is-valid-option flag, a has-value
        /// flag, and a value.
        /// </para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// If this single result option represents one result, the is-valid-option flag and
        /// has-value flag are <see langword="true"/> and the value parameter is the result value.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If this single result option represents zero results, the is-valid-option flag is <see
        /// langword="true"/>, the has-value flag is <see langword="false"/>, and the value parameter
        /// is undefined.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// If this single result option represents more than one result (and is thus not a valid
        /// option), the is-valid-option flag is <see langword="false"/> and the remaining parameters
        /// are undefined.
        /// </description>
        /// </item>
        /// </list>
        /// <para>
        /// If the has-value flag or the value parameter is undefined, the caller must not use their
        /// values. To prevent accidental misuse, the implementation should supply <see
        /// langword="false"/> or <see langword="default"/>( <typeparamref name="T"/>), respectively,
        /// but this is not required.
        /// </para>
        /// </remarks>
        /// <typeparam name="TResult">The return type of <paramref name="resultSelector"/>.</typeparam>
        /// <param name="resultSelector">
        /// A transform function that accepts an is-valid-option flag, a has-value flag, and a value.
        /// </param>
        /// <returns>
        /// The result of calling resultSelector on the current resolved state of this single result option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="resultSelector"/> is <see langword="null"/>.
        /// </exception>
        TResult ResolveSingleResultOption<TResult>(Func<bool, bool, T, TResult> resultSelector);
    }
}