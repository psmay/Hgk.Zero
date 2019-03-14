using System;

namespace Hgk.Zero.Options.Try
{
    /// <summary>
    /// Facilities for adapting typical try functions to produce options.
    /// </summary>
    /// <remarks>
    /// <para>
    /// For the purposes of this class, a "try function" is a bool-returning function that accepts
    /// zero or more arbitrary parameters followed by a result <see langword="out"/> parameter. If
    /// the operation succeeds, the function sets the result parameter to a valid value and then
    /// returns <see langword="true"/>. If the operation fails (in a non-exceptional way), the
    /// function sets the result parameter to the default value for its type and returns <see langword="false"/>.
    /// </para>
    /// <para>
    /// Try functions are often used to handle common, expected failures without throwing exceptions.
    /// For example, several types in the standard library have TryParse methods that produce a value
    /// and return true if successful, or set the value to default and return false otherwise.
    /// </para>
    /// <para>
    /// The same information can be expressed in an option; an option might contain the result value
    /// if the operation succeeds or be empty if the operation fails.
    /// </para>
    /// <para>
    /// The type parameters available for the delegates allow simple access to try functions with
    /// several parameters.
    /// </para>
    /// <example>
    /// <para>
    /// This sample shows how to wrap a call to <see cref="TimeSpan.TryParseExact(string, string[],
    /// IFormatProvider, System.Globalization.TimeSpanStyles, out TimeSpan)"/> to produce an option.
    /// (Note that this is already done for you in the Hgk.Zero.Options.Convert package.)
    /// </para>
    /// <code>
    /// <![CDATA[
    /// // Replaces a call to TimeSpan.TryParseExact(input, formats, formatProvider, styles, out TimeSpan result)
    /// public static Opt<TimeSpan> ParseTimeSpanExactOpt(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles) =>
    ///     TryToOpt<TimeSpan>.Call(TimeSpan.TryParseExact, input, formats, formatProvider, styles);
    /// ]]>
    /// </code>
    /// </example>
    /// </remarks>
    /// <typeparam name="TResult">The type of the result parameter of a try function.</typeparam>
    public static class TryToOpt<TResult>
    {
        /// <summary>
        /// Calls the specified try function and returns an option containing the result.
        /// </summary>
        /// <param name="tryFunction">The try function to call.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call(TryFunction<TResult> tryFunction)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameter and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1>(TryFunction<T1, TResult> tryFunction, T1 arg1)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2>(TryFunction<T1, T2, TResult> tryFunction, T1 arg1, T2 arg2)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3>(TryFunction<T1, T2, T3, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4>(TryFunction<T1, T2, T3, T4, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5>(TryFunction<T1, T2, T3, T4, T5, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5, T6>(TryFunction<T1, T2, T3, T4, T5, T6, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, arg6, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
        /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
        /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5, T6, T7>(TryFunction<T1, T2, T3, T4, T5, T6, T7, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
        /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
        /// <typeparam name="T8">The type of <paramref name="arg8"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
        /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
        /// <param name="arg8">The eighth parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5, T6, T7, T8>(TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
        /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
        /// <typeparam name="T8">The type of <paramref name="arg8"/>.</typeparam>
        /// <typeparam name="T9">The type of <paramref name="arg9"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
        /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
        /// <param name="arg8">The eighth parameter to be passed to the try function.</param>
        /// <param name="arg9">The ninth parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5, T6, T7, T8, T9>(TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
        /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
        /// <typeparam name="T8">The type of <paramref name="arg8"/>.</typeparam>
        /// <typeparam name="T9">The type of <paramref name="arg9"/>.</typeparam>
        /// <typeparam name="T10">The type of <paramref name="arg10"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
        /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
        /// <param name="arg8">The eighth parameter to be passed to the try function.</param>
        /// <param name="arg9">The ninth parameter to be passed to the try function.</param>
        /// <param name="arg10">The tenth parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
        /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
        /// <typeparam name="T8">The type of <paramref name="arg8"/>.</typeparam>
        /// <typeparam name="T9">The type of <paramref name="arg9"/>.</typeparam>
        /// <typeparam name="T10">The type of <paramref name="arg10"/>.</typeparam>
        /// <typeparam name="T11">The type of <paramref name="arg11"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
        /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
        /// <param name="arg8">The eighth parameter to be passed to the try function.</param>
        /// <param name="arg9">The ninth parameter to be passed to the try function.</param>
        /// <param name="arg10">The tenth parameter to be passed to the try function.</param>
        /// <param name="arg11">The eleventh parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
        /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
        /// <typeparam name="T8">The type of <paramref name="arg8"/>.</typeparam>
        /// <typeparam name="T9">The type of <paramref name="arg9"/>.</typeparam>
        /// <typeparam name="T10">The type of <paramref name="arg10"/>.</typeparam>
        /// <typeparam name="T11">The type of <paramref name="arg11"/>.</typeparam>
        /// <typeparam name="T12">The type of <paramref name="arg12"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
        /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
        /// <param name="arg8">The eighth parameter to be passed to the try function.</param>
        /// <param name="arg9">The ninth parameter to be passed to the try function.</param>
        /// <param name="arg10">The tenth parameter to be passed to the try function.</param>
        /// <param name="arg11">The eleventh parameter to be passed to the try function.</param>
        /// <param name="arg12">The twelfth parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
        /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
        /// <typeparam name="T8">The type of <paramref name="arg8"/>.</typeparam>
        /// <typeparam name="T9">The type of <paramref name="arg9"/>.</typeparam>
        /// <typeparam name="T10">The type of <paramref name="arg10"/>.</typeparam>
        /// <typeparam name="T11">The type of <paramref name="arg11"/>.</typeparam>
        /// <typeparam name="T12">The type of <paramref name="arg12"/>.</typeparam>
        /// <typeparam name="T13">The type of <paramref name="arg13"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
        /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
        /// <param name="arg8">The eighth parameter to be passed to the try function.</param>
        /// <param name="arg9">The ninth parameter to be passed to the try function.</param>
        /// <param name="arg10">The tenth parameter to be passed to the try function.</param>
        /// <param name="arg11">The eleventh parameter to be passed to the try function.</param>
        /// <param name="arg12">The twelfth parameter to be passed to the try function.</param>
        /// <param name="arg13">The thirteenth parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
        /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
        /// <typeparam name="T8">The type of <paramref name="arg8"/>.</typeparam>
        /// <typeparam name="T9">The type of <paramref name="arg9"/>.</typeparam>
        /// <typeparam name="T10">The type of <paramref name="arg10"/>.</typeparam>
        /// <typeparam name="T11">The type of <paramref name="arg11"/>.</typeparam>
        /// <typeparam name="T12">The type of <paramref name="arg12"/>.</typeparam>
        /// <typeparam name="T13">The type of <paramref name="arg13"/>.</typeparam>
        /// <typeparam name="T14">The type of <paramref name="arg14"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
        /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
        /// <param name="arg8">The eighth parameter to be passed to the try function.</param>
        /// <param name="arg9">The ninth parameter to be passed to the try function.</param>
        /// <param name="arg10">The tenth parameter to be passed to the try function.</param>
        /// <param name="arg11">The eleventh parameter to be passed to the try function.</param>
        /// <param name="arg12">The twelfth parameter to be passed to the try function.</param>
        /// <param name="arg13">The thirteenth parameter to be passed to the try function.</param>
        /// <param name="arg14">The fourteenth parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
        /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
        /// <typeparam name="T8">The type of <paramref name="arg8"/>.</typeparam>
        /// <typeparam name="T9">The type of <paramref name="arg9"/>.</typeparam>
        /// <typeparam name="T10">The type of <paramref name="arg10"/>.</typeparam>
        /// <typeparam name="T11">The type of <paramref name="arg11"/>.</typeparam>
        /// <typeparam name="T12">The type of <paramref name="arg12"/>.</typeparam>
        /// <typeparam name="T13">The type of <paramref name="arg13"/>.</typeparam>
        /// <typeparam name="T14">The type of <paramref name="arg14"/>.</typeparam>
        /// <typeparam name="T15">The type of <paramref name="arg15"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
        /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
        /// <param name="arg8">The eighth parameter to be passed to the try function.</param>
        /// <param name="arg9">The ninth parameter to be passed to the try function.</param>
        /// <param name="arg10">The tenth parameter to be passed to the try function.</param>
        /// <param name="arg11">The eleventh parameter to be passed to the try function.</param>
        /// <param name="arg12">The twelfth parameter to be passed to the try function.</param>
        /// <param name="arg13">The thirteenth parameter to be passed to the try function.</param>
        /// <param name="arg14">The fourteenth parameter to be passed to the try function.</param>
        /// <param name="arg15">The fifteenth parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, out TResult result);
            return Opt.Create(hasValue, result);
        }

        /// <summary>
        /// Calls the specified try function with the specified parameters and returns an option containing the result.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
        /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
        /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
        /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
        /// <typeparam name="T8">The type of <paramref name="arg8"/>.</typeparam>
        /// <typeparam name="T9">The type of <paramref name="arg9"/>.</typeparam>
        /// <typeparam name="T10">The type of <paramref name="arg10"/>.</typeparam>
        /// <typeparam name="T11">The type of <paramref name="arg11"/>.</typeparam>
        /// <typeparam name="T12">The type of <paramref name="arg12"/>.</typeparam>
        /// <typeparam name="T13">The type of <paramref name="arg13"/>.</typeparam>
        /// <typeparam name="T14">The type of <paramref name="arg14"/>.</typeparam>
        /// <typeparam name="T15">The type of <paramref name="arg15"/>.</typeparam>
        /// <typeparam name="T16">The type of <paramref name="arg16"/>.</typeparam>
        /// <param name="tryFunction">The try function to call.</param>
        /// <param name="arg1">The first parameter to be passed to the try function.</param>
        /// <param name="arg2">The second parameter to be passed to the try function.</param>
        /// <param name="arg3">The third parameter to be passed to the try function.</param>
        /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
        /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
        /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
        /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
        /// <param name="arg8">The eighth parameter to be passed to the try function.</param>
        /// <param name="arg9">The ninth parameter to be passed to the try function.</param>
        /// <param name="arg10">The tenth parameter to be passed to the try function.</param>
        /// <param name="arg11">The eleventh parameter to be passed to the try function.</param>
        /// <param name="arg12">The twelfth parameter to be passed to the try function.</param>
        /// <param name="arg13">The thirteenth parameter to be passed to the try function.</param>
        /// <param name="arg14">The fourteenth parameter to be passed to the try function.</param>
        /// <param name="arg15">The fifteenth parameter to be passed to the try function.</param>
        /// <param name="arg16">The sixteenth parameter to be passed to the try function.</param>
        /// <returns>
        /// An option containing the result parameter produced by calling <paramref name="tryFunction"/>,
        /// if the operation completed successfully; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="tryFunction"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TResult> Call<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> tryFunction, T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16)
        {
            if (tryFunction == null) throw new ArgumentNullException(nameof(tryFunction));
            bool hasValue = tryFunction(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9, arg10, arg11, arg12, arg13, arg14, arg15, arg16, out TResult result);
            return Opt.Create(hasValue, result);
        }
    }
}
