using System;
using System.Collections.Generic;
using System.Linq;

namespace Hgk.Zero.Options.Query
{
    /// <summary>
    /// Facilities for narrowing an existing enumerable to an option value.
    /// </summary>
    public static class EnumerableToOpt
    {
        /// <summary>
        /// Returns an option that contains the element of a sequence at the specified index.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an option-returning counterpart to <see
        /// cref="Enumerable.ElementAtOrDefault{TSource}(IEnumerable{TSource}, int)"/>.
        /// </para>
        /// <para>This method is implemented using deferred execution; the query represented by this method is not performed until the contents of the returned option are resolved, such as by enumeration.</para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source sequence.</param>
        /// <param name="index">The zero-based index of the element in source to retrieve.</param>
        /// <returns>
        /// An option containing the element of <paramref name="source"/> at the index <paramref
        /// name="index"/>, or an empty option if index is out of range.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> WhereElementAt<TSource>(this IEnumerable<TSource> source, int index)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (index < 0)
            {
                return Opt.Empty<TSource>();
            }
            return Opt.Defer(() => source.WhereElementAtImmediate(index));
        }

        /// <summary>
        /// Returns an option that contains the first element of a sequence.
        /// </summary>
        /// <remarks>
        /// <para>This method is an option-returning counterpart to <see cref="Enumerable.FirstOrDefault{TSource}(IEnumerable{TSource})"/>.</para>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source sequence.</param>
        /// <returns>
        /// An option containing the first element of <paramref name="source"/>, or an empty option
        /// if <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> WhereFirst<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return Opt.Defer(() => source.WhereFirstImmediate());
        }

        /// <summary>
        /// Returns an option that contains the first element of a sequence that satisfies a predicate.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an option-returning counterpart to <see
        /// cref="Enumerable.FirstOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>.
        /// </para>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source sequence.</param>
        /// <param name="predicate">A function to test elements of <paramref name="source"/>.</param>
        /// <returns>
        /// An option containing the first element of <paramref name="source"/> that satisfies
        /// predicate, or an empty option if no such element exists.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or predicate is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> WhereFirst<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(source));
            return Opt.Defer(() => source.WhereFirstImmediate(predicate));
        }

        /// <summary>
        /// Returns an option that contains the last element of a sequence.
        /// </summary>
        /// <remarks>
        /// <para>This method is an option-returning counterpart to <see cref="Enumerable.LastOrDefault{TSource}(IEnumerable{TSource})"/>.</para>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source sequence.</param>
        /// <returns>
        /// An option containing the last element of <paramref name="source"/>, or an empty option if
        /// <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        public static IOpt<TSource> WhereLast<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return Opt.Defer(() => source.WhereLastImmediate());
        }

        /// <summary>
        /// Returns an option that contains the last element of a sequence that satisfies a predicate.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an option-returning counterpart to <see
        /// cref="Enumerable.LastOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>.
        /// </para>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source sequence.</param>
        /// <param name="predicate">A function to test elements of <paramref name="source"/>.</param>
        /// <returns>
        /// An option containing the last element of <paramref name="source"/> that satisfies
        /// predicate, or an empty option if no such element exists.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or predicate is <see langword="null"/>.
        /// </exception>
        public static IOpt<TSource> WhereLast<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(source));
            return Opt.Defer(() => source.WhereLastImmediate(predicate));
        }

        /// <summary>
        /// Returns an option that contains the only element of a sequence.
        /// </summary>
        /// <remarks>
        /// <para>This method is an option-returning counterpart to <see cref="Enumerable.SingleOrDefault{TSource}(IEnumerable{TSource})"/>.</para>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>
        /// This method returns a single result option ( <see cref="ISingleResultOpt{T}"/>). If
        /// <paramref name="source"/> contains zero elements or one element, this option can be used
        /// as an ordinary option ( <see cref="IOpt{T}"/>). If <paramref name="source"/> contains
        /// more than one element, enumerating or resolving this option as an ordinary option will
        /// result in an <see cref="InvalidOperationException"/> being thrown. Methods such as <see
        /// cref="ISingleResultOpt{T}.Match{TResult}(Func{TResult}, Func{T, TResult},
        /// Func{TResult})"/> and <see
        /// cref="SingleResultOpt.ReplaceIfMoreThanOne{TSource}(ISingleResultOpt{TSource},
        /// IOpt{TSource})"/> can be used to handle the more-than-one case without exceptions.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source sequence.</param>
        /// <returns>
        /// An option containing the only element of <paramref name="source"/>, or an empty option if
        /// <paramref name="source"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="source"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">
        /// Returned single result was resolved as an ordinary option, but <paramref name="source"/>
        /// contained more than one element.
        /// </exception>
        public static ISingleResultOpt<TSource> WhereSingle<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return SingleResultOpt.Defer(() => source.WhereSingleImmediate());
        }

        /// <summary>
        /// Returns an option that contains the only element of a sequence that satisfies an exception.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is an option-returning counterpart to <see
        /// cref="Enumerable.SingleOrDefault{TSource}(IEnumerable{TSource}, Func{TSource, bool})"/>.
        /// </para>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// <para>
        /// This method returns a single result option ( <see cref="ISingleResultOpt{T}"/>). If
        /// <paramref name="source"/> contains zero elements or one element that satisfies <paramref
        /// name="predicate"/>, this option can be used as an ordinary option ( <see
        /// cref="IOpt{T}"/>). If <paramref name="source"/> contains more than one element that
        /// satisfies <paramref name="predicate"/>, enumerating or resolving this option as an
        /// ordinary option will result in an <see cref="InvalidOperationException"/> being thrown.
        /// Methods such as <see cref="ISingleResultOpt{T}.Match{TResult}(Func{TResult}, Func{T,
        /// TResult}, Func{TResult})"/> and <see
        /// cref="SingleResultOpt.ReplaceIfMoreThanOne{TSource}(ISingleResultOpt{TSource},
        /// IOpt{TSource})"/> can be used to handle the more-than-one case without exceptions.
        /// </para>
        /// </remarks>
        /// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source sequence.</param>
        /// <param name="predicate">A function to test elements of <paramref name="source"/>.</param>
        /// <returns>
        /// An option containing the only element of <paramref name="source"/> that satisfies
        /// <paramref name="predicate"/>, or an empty option if there is no such element.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="predicate"/> is <see langword="null"/>.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Returned single result was resolved as an ordinary option, but <paramref name="source"/>
        /// contained more than one element that satisfies <paramref name="predicate"/>.
        /// </exception>
        public static ISingleResultOpt<TSource> WhereSingle<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(source));
            return SingleResultOpt.Defer(() => source.WhereSingleImmediate(predicate));
        }

        private static FixedSingleResultOpt<TSource> EnumeratorSingleToFixedOpt<TSource>(IEnumerator<TSource> source, bool usingPredicate)
        {
            if (source.MoveNext())
            {
                TSource value = source.Current;

                if (source.MoveNext())
                {
                    // More than one element
                    return SingleResultOpt.GetFixedMoreThanOne<TSource>(usingPredicate);
                }
                else
                {
                    // Exactly one element
                    return SingleResultOpt.GetFixedOne(usingPredicate, value);
                }
            }
            else
            {
                // No elements
                return SingleResultOpt.GetFixedZero<TSource>(usingPredicate);
            }
        }

        private static Opt<TSource> EnumeratorWhereElementAtImmediate<TSource>(IEnumerator<TSource> sourceEnumerator, int index)
        {
            if (index >= 0)
            {
                while (sourceEnumerator.MoveNext())
                {
                    if (index == 0)
                    {
                        return Opt.Full(sourceEnumerator.Current);
                    }
                    else
                    {
                        index--;
                    }
                }
            }
            return Opt.Empty<TSource>();
        }

        private static Opt<TSource> EnumeratorWhereFirstImmediate<TSource>(IEnumerator<TSource> sourceEnumerator)
        {
            return sourceEnumerator.MoveNext() ? Opt.Full(sourceEnumerator.Current) : Opt.Empty<TSource>();
        }

        private static Opt<TSource> EnumeratorWhereLastImmediate<TSource>(IEnumerator<TSource> sourceEnumerator)
        {
            if (sourceEnumerator.MoveNext())
            {
                TSource value = sourceEnumerator.Current;

                while (sourceEnumerator.MoveNext())
                {
                    value = sourceEnumerator.Current;
                }

                return Opt.Full(value);
            }
            else
            {
                return Opt.Empty<TSource>();
            }
        }

        private static Opt<TSource> WhereElementAtImmediate<TSource>(this IEnumerable<TSource> source, int index)
        {
            if (index < 0)
            {
                return Opt.Empty<TSource>();
            }
            else if (source is IOpt<TSource> sourceOpt)
            {
                return (index == 0) ? sourceOpt.ToFixed() : Opt.Empty<TSource>();
            }
            else if (source is IList<TSource> sourceList)
            {
                return (index < sourceList.Count) ? Opt.Full(sourceList[index]) : Opt.Empty<TSource>();
            }
            else
            {
                using (var sourceEnumerator = source.GetEnumerator())
                {
                    return EnumeratorWhereElementAtImmediate(sourceEnumerator, index);
                }
            }
        }

        private static Opt<TSource> WhereFirstImmediate<TSource>(this IEnumerable<TSource> source)
        {
            if (source is IOpt<TSource> sourceOpt)
            {
                return sourceOpt.ToFixed();
            }
            else if (source is IList<TSource> sourceList)
            {
                return sourceList.Count >= 1 ? Opt.Full(sourceList[0]) : Opt.Empty<TSource>();
            }
            else
            {
                using (var sourceEnumerator = source.GetEnumerator())
                {
                    return EnumeratorWhereFirstImmediate(sourceEnumerator);
                }
            }
        }

        private static Opt<TSource> WhereFirstImmediate<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source is IOpt<TSource> sourceOpt)
            {
                return sourceOpt.ToFixed().WhereRaw(predicate);
            }
            else
            {
                foreach (var element in source)
                {
                    if (predicate(element))
                    {
                        return Opt.Full(element);
                    }
                }
                return Opt.Empty<TSource>();
            }
        }

        private static Opt<TSource> WhereLastImmediate<TSource>(this IEnumerable<TSource> source)
        {
            if (source is IOpt<TSource> sourceOpt)
            {
                return sourceOpt.ToFixed();
            }
            else if (source is IList<TSource> sourceList)
            {
                return sourceList.Count >= 1 ? Opt.Full(sourceList[sourceList.Count - 1]) : Opt.Empty<TSource>();
            }
            else
            {
                using (var sourceEnumerator = source.GetEnumerator())
                {
                    return EnumeratorWhereLastImmediate(sourceEnumerator);
                }
            }
        }

        private static Opt<TSource> WhereLastImmediate<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source is IOpt<TSource> sourceOpt)
            {
                return sourceOpt.ToFixed().WhereRaw(predicate);
            }
            else
            {
                bool hasValue = false;
                TSource value = default(TSource);

                foreach (var element in source)
                {
                    if (predicate(element))
                    {
                        value = element;
                        hasValue = true;
                    }
                }

                return Opt.Create(hasValue, value);
            }
        }

        private static FixedSingleResultOpt<TSource> WhereSingleImmediate<TSource>(this IEnumerable<TSource> source)
        {
            const bool usingPredicate = false;

            if (source is IOpt<TSource> sourceOpt)
            {
                return SingleResultOpt.GetFixedFromOpt(sourceOpt.ToFixed(), usingPredicate);
            }
            else if (source is IList<TSource> sourceList)
            {
                if (sourceList.Count > 1)
                {
                    return SingleResultOpt.GetFixedMoreThanOne<TSource>(usingPredicate);
                }
                else if (sourceList.Count == 0)
                {
                    return SingleResultOpt.GetFixedZero<TSource>(usingPredicate);
                }
                else
                {
                    return SingleResultOpt.GetFixedOne(usingPredicate, sourceList[0]);
                }
            }
            else
            {
                using (var sourceEnumerator = source.GetEnumerator())
                {
                    return EnumeratorSingleToFixedOpt(sourceEnumerator, usingPredicate);
                }
            }
        }

        private static FixedSingleResultOpt<TSource> WhereSingleImmediate<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            const bool usingPredicate = true;

            if (source is IOpt<TSource> sourceOpt)
            {
                return SingleResultOpt.GetFixedFromOpt(sourceOpt.ToFixed().WhereRaw(predicate), usingPredicate);
            }
            else
            {
                bool hasValue = false;
                TSource value = default(TSource);

                foreach (var element in source)
                {
                    if (predicate(element))
                    {
                        if (hasValue)
                        {
                            return SingleResultOpt.GetFixedMoreThanOne<TSource>(usingPredicate);
                        }
                        else
                        {
                            value = element;
                            hasValue = true;
                        }
                    }
                }

                return SingleResultOpt.GetFixedFromValue(hasValue, value, usingPredicate);
            }
        }
    }
}