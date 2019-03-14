using Hgk.Zero.Options.Try;
using System;
using System.Globalization;

namespace Hgk.Zero.Options.Convert
{
    /// <summary>
    /// Common parse methods adapted to return options.
    /// </summary>
    public static class ParseToOpt
    {
        #region Non-numeric primitive types

        /// <summary>
        /// Tries to convert a boolean value from a <see cref="string"/> representation to its <see
        /// cref="bool"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="bool.TryParse(string, out bool)"/>
        /// as an option.
        /// </para>
        /// </remarks>
        /// <param name="value">A <see cref="string"/> containing the value to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<bool> ParseBoolean(string value) => TryToOpt<bool>.Call(bool.TryParse, value);

        /// <summary>
        /// Tries to convert a character from a <see cref="string"/> representation to its <see
        /// cref="char"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="char.TryParse(string, out char)"/>
        /// as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a character to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<char> ParseChar(string s) => TryToOpt<char>.Call(char.TryParse, s);

        #endregion Non-numeric primitive types

        #region Integer types

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="sbyte"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="sbyte.TryParse(string, out
        /// sbyte)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<sbyte> ParseSByte(string s) => TryToOpt<sbyte>.Call(sbyte.TryParse, s);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="sbyte"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="sbyte.TryParse(string,
        /// NumberStyles, IFormatProvider, out sbyte)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the style elements of <paramref
        /// name="s"/>, such as <see cref="NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="NumberStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> contains <see cref="NumberStyles.AllowHexSpecifier"/> combined
        /// with settings that do not form a subset of <see cref="NumberStyles.HexNumber"/>.
        /// </exception>
        public static Opt<sbyte> ParseSByte(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<sbyte>.Call(sbyte.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="short"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="short.TryParse(string, out
        /// short)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<short> ParseInt16(string s) => TryToOpt<short>.Call(short.TryParse, s);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="short"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="short.TryParse(string,
        /// NumberStyles, IFormatProvider, out short)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the style elements of <paramref
        /// name="s"/>, such as <see cref="NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="NumberStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> contains <see cref="NumberStyles.AllowHexSpecifier"/> combined
        /// with settings that do not form a subset of <see cref="NumberStyles.HexNumber"/>.
        /// </exception>
        public static Opt<short> ParseInt16(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<short>.Call(short.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="int"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="int.TryParse(string, out int)"/> as
        /// an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<int> ParseInt32(string s) => TryToOpt<int>.Call(int.TryParse, s);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="int"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="int.TryParse(string, NumberStyles,
        /// IFormatProvider, out int)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the style elements of <paramref
        /// name="s"/>, such as <see cref="NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="NumberStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> contains <see cref="NumberStyles.AllowHexSpecifier"/> combined
        /// with settings that do not form a subset of <see cref="NumberStyles.HexNumber"/>.
        /// </exception>
        public static Opt<int> ParseInt32(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<int>.Call(int.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="long"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="long.TryParse(string, out long)"/>
        /// as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<long> ParseInt64(string s) => TryToOpt<long>.Call(long.TryParse, s);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="long"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="long.TryParse(string, NumberStyles,
        /// IFormatProvider, out long)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the style elements of <paramref
        /// name="s"/>, such as <see cref="NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="NumberStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> contains <see cref="NumberStyles.AllowHexSpecifier"/> combined
        /// with settings that do not form a subset of <see cref="NumberStyles.HexNumber"/>.
        /// </exception>
        public static Opt<long> ParseInt64(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<long>.Call(long.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="byte"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="byte.TryParse(string, out byte)"/>
        /// as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<byte> ParseByte(string s) => TryToOpt<byte>.Call(byte.TryParse, s);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="byte"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="byte.TryParse(string, NumberStyles,
        /// IFormatProvider, out byte)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the style elements of <paramref
        /// name="s"/>, such as <see cref="NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="NumberStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> contains <see cref="NumberStyles.AllowHexSpecifier"/> combined
        /// with settings that do not form a subset of <see cref="NumberStyles.HexNumber"/>.
        /// </exception>
        public static Opt<byte> ParseByte(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<byte>.Call(byte.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="ushort"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="ushort.TryParse(string, out
        /// ushort)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<ushort> ParseUInt16(string s) => TryToOpt<ushort>.Call(ushort.TryParse, s);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="ushort"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="ushort.TryParse(string,
        /// NumberStyles, IFormatProvider, out ushort)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the style elements of <paramref
        /// name="s"/>, such as <see cref="NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="NumberStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> contains <see cref="NumberStyles.AllowHexSpecifier"/> combined
        /// with settings that do not form a subset of <see cref="NumberStyles.HexNumber"/>.
        /// </exception>
        public static Opt<ushort> ParseUInt16(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<ushort>.Call(ushort.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="uint"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="uint.TryParse(string, out uint)"/>
        /// as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<uint> ParseUInt32(string s) => TryToOpt<uint>.Call(uint.TryParse, s);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="uint"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="uint.TryParse(string, NumberStyles,
        /// IFormatProvider, out uint)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the style elements of <paramref
        /// name="s"/>, such as <see cref="NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="NumberStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> contains <see cref="NumberStyles.AllowHexSpecifier"/> combined
        /// with settings that do not form a subset of <see cref="NumberStyles.HexNumber"/>.
        /// </exception>
        public static Opt<uint> ParseUInt32(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<uint>.Call(uint.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="ulong"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="ulong.TryParse(string, out
        /// ulong)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<ulong> ParseUInt64(string s) => TryToOpt<ulong>.Call(ulong.TryParse, s);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="ulong"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="ulong.TryParse(string,
        /// NumberStyles, IFormatProvider, out ulong)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the style elements of <paramref
        /// name="s"/>, such as <see cref="NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="NumberStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> contains <see cref="NumberStyles.AllowHexSpecifier"/> combined
        /// with settings that do not form a subset of <see cref="NumberStyles.HexNumber"/>.
        /// </exception>
        public static Opt<ulong> ParseUInt64(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<ulong>.Call(ulong.TryParse, s, style, provider);

        #endregion Integer types

        #region Floating-point types

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="float"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="float.TryParse(string, out
        /// float)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<float> ParseSingle(string s) => TryToOpt<float>.Call(float.TryParse, s);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="float"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="float.TryParse(string,
        /// NumberStyles, IFormatProvider, out float)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the style elements of <paramref
        /// name="s"/>, such as <see cref="NumberStyles.Float"/>.
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="NumberStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> includes <see cref="NumberStyles.AllowHexSpecifier"/>, which is
        /// not supported for this type.
        /// </exception>
        public static Opt<float> ParseSingle(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<float>.Call(float.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="double"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="double.TryParse(string, out
        /// double)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<double> ParseDouble(string s) => TryToOpt<double>.Call(double.TryParse, s);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="double"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="double.TryParse(string,
        /// NumberStyles, IFormatProvider, out double)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the style elements of <paramref
        /// name="s"/>, such as <see cref="NumberStyles.Float"/>.
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="NumberStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> includes <see cref="NumberStyles.AllowHexSpecifier"/>, which is
        /// not supported for this type.
        /// </exception>
        public static Opt<double> ParseDouble(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<double>.Call(double.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="decimal"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="decimal.TryParse(string, out
        /// decimal)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<decimal> ParseDecimal(string s) => TryToOpt<decimal>.Call(decimal.TryParse, s);

        /// <summary>
        /// Tries to convert a number from a <see cref="string"/> representation to its <see
        /// cref="decimal"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="decimal.TryParse(string,
        /// NumberStyles, IFormatProvider, out decimal)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a number to convert.</param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the style elements of <paramref
        /// name="s"/>, such as <see cref="NumberStyles.Number"/>.
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="NumberStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> includes <see cref="NumberStyles.AllowHexSpecifier"/>, which is
        /// not supported for this type.
        /// </exception>
        public static Opt<decimal> ParseDecimal(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<decimal>.Call(decimal.TryParse, s, style, provider);

        #endregion Floating-point types

        #region Date and time types

        /// <summary>
        /// Tries to convert a date and time from a <see cref="string"/> representation to its <see
        /// cref="DateTime"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTime.TryParse(string, out
        /// DateTime)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a date and time to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The date and/or time is out of range for this format.
        /// </exception>
        public static Opt<DateTime> ParseDateTime(string s) => TryToOpt<DateTime>.Call(DateTime.TryParse, s);

        /// <summary>
        /// Tries to convert a date and time from a <see cref="string"/> representation to its <see
        /// cref="DateTime"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTime.TryParse(string,
        /// IFormatProvider, DateTimeStyles, out DateTime)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a date and time to convert.</param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <param name="styles">
        /// A combination of <see langword="enum"/> values indicating the format and interpretation
        /// options for parsing <paramref name="s"/>, such as <see cref="DateTimeStyles.None"/>.
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="styles"/> is not a valid <see cref="DateTimeStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="styles"/> contains conflicting <see cref="DateTimeStyles"/> values.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The date and/or time is out of range for this format.
        /// </exception>
        public static Opt<DateTime> ParseDateTime(string s, IFormatProvider provider, DateTimeStyles styles) => TryToOpt<DateTime>.Call(DateTime.TryParse, s, provider, styles);

        /// <summary>
        /// Tries to convert a date and time from a <see cref="string"/> representation in a specific
        /// format to its <see cref="DateTime"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTime.TryParseExact(string,
        /// string, IFormatProvider, DateTimeStyles, out DateTime)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a date and time to convert.</param>
        /// <param name="format">
        /// A format specifier to use while parsing input (see <see
        /// cref="DateTime.TryParseExact(string, string, IFormatProvider, DateTimeStyles, out DateTime)"/>).
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the format and interpretation
        /// options for parsing <paramref name="s"/>, such as <see cref="DateTimeStyles.None"/>.
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="DateTimeStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> contains conflicting <see cref="DateTimeStyles"/> values.
        /// </exception>
        public static Opt<DateTime> ParseDateTimeExact(string s, string format, IFormatProvider provider, DateTimeStyles style) => TryToOpt<DateTime>.Call(DateTime.TryParseExact, s, format, provider, style);

        /// <summary>
        /// Tries to convert a date and time from a <see cref="string"/> representation in any of a
        /// set of specific formats to its <see cref="DateTime"/> equivalent, returning the result as
        /// an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTime.TryParseExact(string,
        /// string[], IFormatProvider, DateTimeStyles, out DateTime)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a date and time to convert.</param>
        /// <param name="formats">
        /// An array of format specifiers, any of which to use while parsing input (see <see
        /// cref="DateTime.TryParseExact(string, string[], IFormatProvider, DateTimeStyles, out DateTime)"/>).
        /// </param>
        /// <param name="provider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <param name="style">
        /// A combination of <see langword="enum"/> values indicating the format and interpretation
        /// options for parsing <paramref name="s"/>, such as <see cref="DateTimeStyles.None"/>.
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> is not a valid <see cref="DateTimeStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="style"/> contains conflicting <see cref="DateTimeStyles"/> values.
        /// </exception>
        public static Opt<DateTime> ParseDateTimeExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style) => TryToOpt<DateTime>.Call(DateTime.TryParseExact, s, formats, provider, style);

        /// <summary>
        /// Tries to convert a date and time from a <see cref="string"/> representation to its <see
        /// cref="DateTimeOffset"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTimeOffset.TryParse(string, out
        /// DateTimeOffset)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="input">A <see cref="string"/> containing a date and time to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The date and/or time is out of range for this format.
        /// </exception>
        public static Opt<DateTimeOffset> ParseDateTimeOffset(string input) => TryToOpt<DateTimeOffset>.Call(DateTimeOffset.TryParse, input);

        /// <summary>
        /// Tries to convert a date and time from a <see cref="string"/> representation to its <see
        /// cref="DateTimeOffset"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTimeOffset.TryParse(string,
        /// IFormatProvider, DateTimeStyles, out DateTimeOffset)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="input">A <see cref="string"/> containing a date and time to convert.</param>
        /// <param name="formatProvider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <param name="styles">
        /// A combination of <see langword="enum"/> values indicating the format and interpretation
        /// options for parsing <paramref name="input"/>, such as <see cref="DateTimeStyles.None"/>.
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="styles"/> is not a valid <see cref="DateTimeStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="styles"/> contains conflicting <see cref="DateTimeStyles"/> values.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="styles"/> contains <see cref="DateTimeStyles.NoCurrentDateDefault"/>,
        /// which is not supported.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The date and/or time is out of range for this format.
        /// </exception>
        public static Opt<DateTimeOffset> ParseDateTimeOffset(string input, IFormatProvider formatProvider, DateTimeStyles styles) => TryToOpt<DateTimeOffset>.Call(DateTimeOffset.TryParse, input, formatProvider, styles);

        /// <summary>
        /// Tries to convert a date and time from a <see cref="string"/> representation in a specific
        /// format to its <see cref="DateTimeOffset"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see
        /// cref="DateTimeOffset.TryParseExact(string, string, IFormatProvider, DateTimeStyles, out
        /// DateTimeOffset)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="input">A <see cref="string"/> containing a date and time to convert.</param>
        /// <param name="format">
        /// A format specifier to use while parsing input (see <see
        /// cref="DateTimeOffset.TryParseExact(string, string, IFormatProvider, DateTimeStyles, out DateTimeOffset)"/>).
        /// </param>
        /// <param name="formatProvider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <param name="styles">
        /// A combination of <see langword="enum"/> values indicating the format and interpretation
        /// options for parsing <paramref name="input"/>, such as <see cref="DateTimeStyles.None"/>.
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="styles"/> is not a valid <see cref="DateTimeStyles"/> value.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="styles"/> contains conflicting <see cref="DateTimeStyles"/> values.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="styles"/> contains <see cref="DateTimeStyles.NoCurrentDateDefault"/>,
        /// which is not supported.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The date and/or time is out of range for this format.
        /// </exception>
        public static Opt<DateTimeOffset> ParseDateTimeOffsetExact(string input, string format, IFormatProvider formatProvider, DateTimeStyles styles) => TryToOpt<DateTimeOffset>.Call(DateTimeOffset.TryParseExact, input, format, formatProvider, styles);

        /// <summary>
        /// Tries to convert a time interval from a <see cref="string"/> representation to its <see
        /// cref="TimeSpan"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParse(string, out
        /// TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="s">A <see cref="string"/> containing a time interval to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<TimeSpan> ParseTimeSpan(string s) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParse, s);

        /// <summary>
        /// Tries to convert a time interval from a <see cref="string"/> representation to its <see
        /// cref="TimeSpan"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParse(string, out
        /// TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="input">A <see cref="string"/> containing a time interval to convert.</param>
        /// <param name="formatProvider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<TimeSpan> ParseTimeSpan(string input, IFormatProvider formatProvider) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParse, input, formatProvider);

        /// <summary>
        /// Tries to convert a time interval from a <see cref="string"/> representation in a specific
        /// format to its <see cref="TimeSpan"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParseExact(string,
        /// string, IFormatProvider, out TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="input">A <see cref="string"/> containing a time interval to convert.</param>
        /// <param name="format">
        /// A format specifier to use while parsing input (see <see
        /// cref="TimeSpan.TryParseExact(string, string, IFormatProvider, out TimeSpan)"/>).
        /// </param>
        /// <param name="formatProvider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<TimeSpan> ParseTimeSpanExact(string input, string format, IFormatProvider formatProvider) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParseExact, input, format, formatProvider);

        /// <summary>
        /// Tries to convert a time interval from a <see cref="string"/> representation in any of a
        /// set of specific formats to its <see cref="TimeSpan"/> equivalent, returning the result as
        /// an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParseExact(string,
        /// string[], IFormatProvider, out TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="input">A <see cref="string"/> containing a time interval to convert.</param>
        /// <param name="formats">
        /// An array of format specifiers, any of which to use while parsing input (see <see
        /// cref="TimeSpan.TryParseExact(string, string[], IFormatProvider, out TimeSpan)"/>).
        /// </param>
        /// <param name="formatProvider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<TimeSpan> ParseTimeSpanExact(string input, string[] formats, IFormatProvider formatProvider) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParseExact, input, formats, formatProvider);

        /// <summary>
        /// Tries to convert a time interval from a <see cref="string"/> representation in a specific
        /// format to its <see cref="TimeSpan"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParseExact(string,
        /// string, IFormatProvider, TimeSpanStyles, out TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="input">A <see cref="string"/> containing a time interval to convert.</param>
        /// <param name="format">
        /// A format specifier to use while parsing input (see <see
        /// cref="TimeSpan.TryParseExact(string, string, IFormatProvider, out TimeSpan)"/>).
        /// </param>
        /// <param name="formatProvider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <param name="styles">
        /// A combination of <see langword="enum"/> values indicating the interpretation options for
        /// parsing <paramref name="input"/>, such as <see cref="TimeSpanStyles.None"/>.
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<TimeSpan> ParseTimeSpanExact(string input, string format, IFormatProvider formatProvider, TimeSpanStyles styles) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParseExact, input, format, formatProvider, styles);

        /// <summary>
        /// Tries to convert a time interval from a <see cref="string"/> representation in any of a
        /// set of specific formats to its <see cref="TimeSpan"/> equivalent, returning the result as
        /// an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParseExact(string,
        /// string[], IFormatProvider, TimeSpanStyles, out TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="input">A <see cref="string"/> containing a time interval to convert.</param>
        /// <param name="formats">
        /// An array of format specifiers, any of which to use while parsing input (see <see
        /// cref="TimeSpan.TryParseExact(string, string[], IFormatProvider, TimeSpanStyles, out TimeSpan)"/>).
        /// </param>
        /// <param name="formatProvider">
        /// A culture-specific formatting information provider. (If <see langword="null"/>, the value
        /// for the current thread is used.)
        /// </param>
        /// <param name="styles">
        /// A combination of <see langword="enum"/> values indicating the interpretation options for
        /// parsing <paramref name="input"/>, such as <see cref="TimeSpanStyles.None"/>.
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<TimeSpan> ParseTimeSpanExact(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParseExact, input, formats, formatProvider, styles);

        #endregion Date and time types

        #region Enumerated types

        /// <summary>
        /// Tries to convert one or more enumerated constants from a <see cref="string"/>
        /// representation to the equivalent <see langword="enum"/> values, returning the result as
        /// an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="Enum.TryParse{TEnum}(string, out
        /// TEnum)"/> as an option.
        /// </para>
        /// </remarks>
        /// <typeparam name="TEnum">
        /// The <see langword="enum"/> type to which to convert <paramref name="value"/>.
        /// </typeparam>
        /// <param name="value">
        /// A <see cref="string"/> containing a numeric value, a case-sensitive constant name, or a
        /// comma-separated list of case-sensitive constant names to convert to a <typeparamref
        /// name="TEnum"/> value.
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <typeparamref name="TEnum"/> is not an <see langword="enum"/> type.
        /// </exception>
        public static Opt<TEnum> ParseEnum<TEnum>(string value) where TEnum : struct => TryToOpt<TEnum>.Call(Enum.TryParse, value);

        /// <summary>
        /// Tries to convert one or more enumerated constants from a <see cref="string"/>
        /// representation to the equivalent <see langword="enum"/> values, returning the result as
        /// an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="Enum.TryParse{TEnum}(string, bool,
        /// out TEnum)"/> as an option.
        /// </para>
        /// </remarks>
        /// <typeparam name="TEnum">
        /// The <see langword="enum"/> type to which to convert <paramref name="value"/>.
        /// </typeparam>
        /// <param name="value">
        /// A <see cref="string"/> containing a numeric value, a constant name, or a comma-separated
        /// list of constant names to convert to a <typeparamref name="TEnum"/> value.
        /// </param>
        /// <param name="ignoreCase">
        /// If <see langword="true"/>, constant names in <paramref name="value"/> are matched
        /// case-insensitively; otherwise, constant names in <paramref name="value"/> are matched case-sensitively.
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <typeparamref name="TEnum"/> is not an <see langword="enum"/> type.
        /// </exception>
        public static Opt<TEnum> ParseEnum<TEnum>(string value, bool ignoreCase) where TEnum : struct => TryToOpt<TEnum>.Call(Enum.TryParse, value, ignoreCase);

        #endregion Enumerated types

        #region Guid type

        /// <summary>
        /// Tries to convert a GUID from a <see cref="string"/> representation to its <see
        /// cref="Guid"/> equivalent, returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="Guid.TryParse(string, out Guid)"/>
        /// as an option.
        /// </para>
        /// </remarks>
        /// <param name="input">A <see cref="string"/> containing a GUID to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<Guid> ParseGuid(string input) => TryToOpt<Guid>.Call(Guid.TryParse, input);

        /// <summary>
        /// Tries to convert a GUID from a <see cref="string"/> representation in the specified
        /// format to its <see cref="Guid"/> equivalent, returning the result as an option.
        /// </summary>
        /// <param name="input">A <see cref="string"/> containing a GUID to convert.</param>
        /// <param name="format">
        /// A format specifier to use while parsing input; one of "N", "D", "B", "P", or "X" (see
        /// <see cref="Guid.TryParseExact(string, string, out Guid)"/>).
        /// </param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<Guid> ParseGuidExact(string input, string format) => TryToOpt<Guid>.Call(Guid.TryParseExact, input, format);

        #endregion Guid type

        #region Version type

        /// <summary>
        /// Tries to convert a version number from a string representation to its Version equivalent,
        /// returning the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="Version.TryParse(string, out
        /// Version)"/> as an option.
        /// </para>
        /// </remarks>
        /// <param name="input">A <see cref="string"/> containing a version number to convert.</param>
        /// <returns>
        /// A full option containing the converted value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        public static Opt<Version> ParseVersion(string input) => TryToOpt<Version>.Call(Version.TryParse, input);

        #endregion Version type
    }
}