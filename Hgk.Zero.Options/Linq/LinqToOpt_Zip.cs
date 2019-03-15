using System;
using System.Collections.Generic;

namespace Hgk.Zero.Options.Linq
{
    public static partial class LinqToOpt
    {
        /// <summary>
        /// Produces a new option by combining the value from an option with the value from another
        /// source using the specified result selector.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is implemented using deferred execution; the query represented by this method
        /// is not performed until the contents of the returned option are resolved, such as by enumeration.
        /// </para>
        /// </remarks>
        /// <typeparam name="TFirst">The type of the elements of <paramref name="first"/>.</typeparam>
        /// <typeparam name="TSecond">The type of the elements of <paramref name="second"/>.</typeparam>
        /// <typeparam name="TResult">The type of the elements of the result option.</typeparam>
        /// <param name="first">The first source.</param>
        /// <param name="second">The second source.</param>
        /// <param name="resultSelector">
        /// A function that specifies how to combine an element from <paramref name="first"/> with
        /// the corresponding element of <paramref name="second"/>.
        /// </param>
        /// <returns>
        /// An option containing the result of calling <paramref name="resultSelector"/> on the
        /// element of <paramref name="first"/> and the first element of <paramref name="second"/>,
        /// or an empty option if either <paramref name="first"/> or <paramref name="second"/> is empty.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="first"/> or <paramref name="second"/> is <see langword="null"/>.
        /// </exception>
        public static IOpt<TResult> Zip<TFirst, TSecond, TResult>(this IOpt<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));

            return first.MetaSelect(opt =>
            {
                if (opt.HasValue)
                {
                    foreach (var secondValue in second)
                    {
                        return Opt.Full(resultSelector(opt.ValueOrDefault, secondValue));
                    }
                }
                return Opt.Empty<TResult>();
            });
        }
    }
}