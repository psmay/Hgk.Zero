namespace Hgk.Zero.Options.Try
{
    /// <summary>
    /// Delegate type for a basic try function with no additional parameters.
    /// </summary>
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<TResult>(out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 1 additional parameter.
    /// </summary>
    /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
    /// <param name="arg1">The first parameter to be passed to the try function.</param>
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, TResult>(T1 arg1, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 2 additional parameters.
    /// </summary>
    /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
    /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
    /// <param name="arg1">The first parameter to be passed to the try function.</param>
    /// <param name="arg2">The second parameter to be passed to the try function.</param>
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, TResult>(T1 arg1, T2 arg2, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 3 additional parameters.
    /// </summary>
    /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
    /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
    /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
    /// <param name="arg1">The first parameter to be passed to the try function.</param>
    /// <param name="arg2">The second parameter to be passed to the try function.</param>
    /// <param name="arg3">The third parameter to be passed to the try function.</param>
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, TResult>(T1 arg1, T2 arg2, T3 arg3, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 4 additional parameters.
    /// </summary>
    /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
    /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
    /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
    /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
    /// <param name="arg1">The first parameter to be passed to the try function.</param>
    /// <param name="arg2">The second parameter to be passed to the try function.</param>
    /// <param name="arg3">The third parameter to be passed to the try function.</param>
    /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 5 additional parameters.
    /// </summary>
    /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
    /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
    /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
    /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
    /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
    /// <param name="arg1">The first parameter to be passed to the try function.</param>
    /// <param name="arg2">The second parameter to be passed to the try function.</param>
    /// <param name="arg3">The third parameter to be passed to the try function.</param>
    /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
    /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 6 additional parameters.
    /// </summary>
    /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
    /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
    /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
    /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
    /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
    /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
    /// <param name="arg1">The first parameter to be passed to the try function.</param>
    /// <param name="arg2">The second parameter to be passed to the try function.</param>
    /// <param name="arg3">The third parameter to be passed to the try function.</param>
    /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
    /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
    /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, T6, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 7 additional parameters.
    /// </summary>
    /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
    /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
    /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
    /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
    /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
    /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
    /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
    /// <param name="arg1">The first parameter to be passed to the try function.</param>
    /// <param name="arg2">The second parameter to be passed to the try function.</param>
    /// <param name="arg3">The third parameter to be passed to the try function.</param>
    /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
    /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
    /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
    /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 8 additional parameters.
    /// </summary>
    /// <typeparam name="T1">The type of <paramref name="arg1"/>.</typeparam>
    /// <typeparam name="T2">The type of <paramref name="arg2"/>.</typeparam>
    /// <typeparam name="T3">The type of <paramref name="arg3"/>.</typeparam>
    /// <typeparam name="T4">The type of <paramref name="arg4"/>.</typeparam>
    /// <typeparam name="T5">The type of <paramref name="arg5"/>.</typeparam>
    /// <typeparam name="T6">The type of <paramref name="arg6"/>.</typeparam>
    /// <typeparam name="T7">The type of <paramref name="arg7"/>.</typeparam>
    /// <typeparam name="T8">The type of <paramref name="arg8"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
    /// <param name="arg1">The first parameter to be passed to the try function.</param>
    /// <param name="arg2">The second parameter to be passed to the try function.</param>
    /// <param name="arg3">The third parameter to be passed to the try function.</param>
    /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
    /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
    /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
    /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
    /// <param name="arg8">The eighth parameter to be passed to the try function.</param>
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 9 additional parameters.
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
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
    /// <param name="arg1">The first parameter to be passed to the try function.</param>
    /// <param name="arg2">The second parameter to be passed to the try function.</param>
    /// <param name="arg3">The third parameter to be passed to the try function.</param>
    /// <param name="arg4">The fourth parameter to be passed to the try function.</param>
    /// <param name="arg5">The fifth parameter to be passed to the try function.</param>
    /// <param name="arg6">The sixth parameter to be passed to the try function.</param>
    /// <param name="arg7">The seventh parameter to be passed to the try function.</param>
    /// <param name="arg8">The eighth parameter to be passed to the try function.</param>
    /// <param name="arg9">The ninth parameter to be passed to the try function.</param>
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 10 additional parameters.
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
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
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
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 11 additional parameters.
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
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
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
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 12 additional parameters.
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
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
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
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 13 additional parameters.
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
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
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
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 14 additional parameters.
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
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
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
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 15 additional parameters.
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
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
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
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, out TResult result);

    /// <summary>
    /// Delegate type for a basic try function with 16 additional parameters.
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
    /// <typeparam name="TResult">The type of the result parameter.</typeparam>
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
    /// <param name="result">
    /// When this method returns, the result of the operation, if it succeeded;
    /// otherwise, the default value of <typeparamref name="TResult"/>. This parameter
    /// is passed uninitialized.
    /// </param>
    /// <returns>
    /// <see langword="true"/> if the operation completed successfully; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public delegate bool TryFunction<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9, T10 arg10, T11 arg11, T12 arg12, T13 arg13, T14 arg14, T15 arg15, T16 arg16, out TResult result);
}