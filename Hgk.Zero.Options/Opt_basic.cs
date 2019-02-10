using System;
using System.Collections.Generic;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// Facilities to create and manipulate options.
    /// </summary>
    public static partial class Opt
    {
        /// <summary>
        /// Creates a fixed option with the same contents as the specified <see cref="Nullable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The non-nullable basis type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value to be contained in the new option, if not <see langword="null"/>.</param>
        /// <returns>
        /// An option that contains the <see cref="Nullable{T}.Value"/> of <paramref name="value"/>,
        /// if present; otherwise, an empty option.
        /// </returns>
        /// <seealso cref="Create{T}(T)"/>
        /// <seealso cref="Empty{T}"/>
        /// <seealso cref="Full{T}(T)"/>
        /// <seealso cref="Create{T}(bool, T)"/>
        public static Opt<T> Create<T>(T? value) where T : struct => value.HasValue ? Full(value.Value) : Empty<T>();

        /// <summary>
        /// Creates a fixed option which contains the specified value, if it is not <see langword="null"/>.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value to be contained in the new option, if not <see langword="null"/>.</param>
        /// <returns>
        /// An option that contains <paramref name="value"/> if it is not <see langword="null"/>;
        /// otherwise, an empty option.
        /// </returns>
        /// <seealso cref="Create{T}(T?)"/>
        /// <seealso cref="Empty{T}"/>
        /// <seealso cref="Full{T}(T)"/>
        /// <seealso cref="Create{T}(bool, T)"/>
        public static Opt<T> Create<T>(T value) where T : class => new Opt<T>(value != null, value);

        /// <summary>
        /// Creates a fixed option which contains the specified value, if a flag is set.
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="hasValue">A flag to determine whether to produce a full option.</param>
        /// <param name="value">
        /// The value to be contained in the new option, if <paramref name="hasValue"/> is <see langword="true"/>.
        /// </param>
        /// <returns>
        /// An option that contains <paramref name="value"/>, if <paramref name="hasValue"/> is <see
        /// langword="true"/>; otherwise, an empty option.
        /// </returns>
        /// <seealso cref="Create{T}(T)"/>
        /// <seealso cref="Create{T}(T?)"/>
        /// <seealso cref="Empty{T}"/>
        /// <seealso cref="Full{T}(T)"/>
        public static Opt<T> Create<T>(bool hasValue, T value) => new Opt<T>(hasValue, value);

        /// <summary>
        /// Creates a fixed, empty option.
        /// </summary>
        /// <typeparam name="T">The element type of the new option.</typeparam>
        /// <returns>An empty option.</returns>
        /// <seealso cref="Full{T}(T)"/>
        /// <seealso cref="Create{T}(T)"/>
        /// <seealso cref="Create{T}(T?)"/>
        /// <seealso cref="Create{T}(bool, T)"/>
        public static Opt<T> Empty<T>() => new Opt<T>();

        /// <summary>
        /// Returns a fixed option reflecting the current state of an option.
        /// </summary>
        /// <typeparam name="TSource">The element type of <paramref name="source"/>.</typeparam>
        /// <param name="source">A source option.</param>
        /// <returns>A fixed option reflecting the current state of <paramref name="source"/>.</returns>
        public static Opt<TSource> Fix<TSource>(IOpt<TSource> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            else if (source is Opt<TSource> alreadyFixedSource)
            {
                return alreadyFixedSource;
            }
            else if (source is IOptFixable<TSource> fixableSource)
            {
                return fixableSource.ToFixed();
            }
            else
            {
                using (var se = source.GetEnumerator())
                {
                    return Fix(se);
                }
            }
        }

        /// <summary>
        /// Returns a fixed option reflecting the current state of an option.
        /// </summary>
        /// <param name="source">A source option.</param>
        /// <returns>A fixed option reflecting the current state of <paramref name="source"/>.</returns>
        public static Opt<object> FixUntyped(IOpt source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            else if (source is Opt<object> alreadyFixedSource)
            {
                return alreadyFixedSource;
            }
            else if (source is IOptFixable fixableSource)
            {
                return fixableSource.ToFixed();
            }
            else
            {
                return FixUntyped(source.GetEnumerator());
            }
        }

        /// <summary>
        /// Creates a fixed option that contains the specified value (even if the value is <see langword="null"/>).
        /// </summary>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="value">The value to be contained in the new option.</param>
        /// <returns>An option that contains <paramref name="value"/>.</returns>
        /// <seealso cref="Empty{T}"/>
        /// <seealso cref="Create{T}(T)"/>
        /// <seealso cref="Create{T}(T?)"/>
        /// <seealso cref="Create{T}(bool, T)"/>
        public static Opt<T> Full<T>(T value) => new Opt<T>(true, value);

        internal static DeferredOpt<TSource> DeferRaw<TSource>(this Func<Opt<TSource>> toFixedFunction)
        {
            return new DeferredOpt<TSource>(toFixedFunction);
        }

        internal static bool EqualsObject(IOpt a, object b)
        {
            if (a == null)
            {
                return b == null;
            }
            else if (b is IOpt otherOpt)
            {
                return EqualsOpt(a, otherOpt);
            }
            else
            {
                return false;
            }
        }

        internal static bool EqualsOpt(IOpt a, IOpt b)
        {
            if (a == b)
            {
                return true;
            }
            else if (a == null || b == null)
            {
                return false;
            }
            else if (a is ISingleResultOpt singleResultA)
            {
                return SingleResultOpt.EqualsOpt(singleResultA, b);
            }
            else if (b is ISingleResultOpt singleResultB)
            {
                return SingleResultOpt.EqualsSingleResultOpt(a.ToFixedSingleResultOpt(), singleResultB);
            }
            else
            {
                var fixedA = FixUntyped(a);
                var fixedB = FixUntyped(b);
                if (fixedA.HasValue)
                {
                    return fixedB.HasValue && Equals(fixedA.ValueOrDefault, fixedB.ValueOrDefault);
                }
                else
                {
                    return !fixedB.HasValue;
                }
            }
        }

        internal static MetaSelectOpt<TSource, TResult> MetaSelect<TSource, TResult>(this IOpt<TSource> source, Func<Opt<TSource>, Opt<TResult>> metaselector)
        {
            return new MetaSelectOpt<TSource, TResult>(source, metaselector);
        }

        private static Opt<TSource> Fix<TSource>(IEnumerator<TSource> source)
        {
            if (source.MoveNext())
            {
                TSource value = source.Current;
                if (source.MoveNext())
                {
                    throw Error.OptionEnumeratorMoreThanOneElement();
                }
                else
                {
                    return Full(value);
                }
            }
            else
            {
                return Empty<TSource>();
            }
        }

        private static Opt<object> FixUntyped(System.Collections.IEnumerator source)
        {
            if (source.MoveNext())
            {
                object value = source.Current;
                if (source.MoveNext())
                {
                    throw Error.OptionEnumeratorMoreThanOneElement();
                }
                else
                {
                    return Full(value);
                }
            }
            else
            {
                return Empty<object>();
            }
        }
    }
}