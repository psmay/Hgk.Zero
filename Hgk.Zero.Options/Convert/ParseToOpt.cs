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
        /// <summary>
        /// Tries to convert the specified string representation of a logical value to its <see
        /// cref="T:System.Boolean"/> equivalent. The result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="bool.TryParse(string, out
        /// bool)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains true if <paramref name="value"/> is equivalent to <see
        /// cref="F:System.Boolean.TrueString"/> or false if <paramref name="value"/> is equivalent
        /// to <see cref="F:System.Boolean.FalseString"/>, if the conversion succeeded; otherwise, an
        /// empty option. The conversion fails if <paramref name="value"/> is null or is not
        /// equivalent to the value of either the <see cref="F:System.Boolean.TrueString"/> or <see
        /// cref="F:System.Boolean.FalseString"/> field.
        /// </returns>
        /// <param name="value">A string containing the value to convert.</param>
        public static Opt<bool> ParseBoolean(string value) => TryToOpt<bool>.Call(bool.TryParse, value);

        /// <summary>
        /// Tries to convert the string representation of a number to its <see cref="T:System.Byte"/>
        /// equivalent, and returns an option containing the result of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="byte.TryParse(string, out byte)"/>
        /// as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the <see cref="T:System.Byte"/> value equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty option.
        /// </returns>
        /// <param name="s">
        /// A string that contains a number to convert. The string is interpreted using the <see
        /// cref="F:System.Globalization.NumberStyles.Integer"/> style.
        /// </param>
        public static Opt<byte> ParseByte(string s) => TryToOpt<byte>.Call(byte.TryParse, s);

        /// <summary>
        /// Converts the string representation of a number in a specified style and culture-specific
        /// format to its <see cref="T:System.Byte"/> equivalent. The result of the conversion is
        /// returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="byte.TryParse(string, NumberStyles,
        /// IFormatProvider, out byte)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 8-bit unsigned integer value equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="s"/> parameter is null, is not of the
        /// correct format, or represents a number less than <see cref="F:System.Byte.MinValue"/> or
        /// greater than <see cref="F:System.Byte.MaxValue"/>.
        /// </returns>
        /// <param name="s">
        /// A string containing a number to convert. The string is interpreted using the style
        /// specified by <paramref name="style"/>.
        /// </param>
        /// <param name="style">
        /// A bitwise combination of enumeration values that indicates the style elements that can be
        /// present in <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref
        /// name="s"/>. If <paramref name="provider"/> is null, the thread current culture is used.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a combination of <see
        /// cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> and <see
        /// cref="F:System.Globalization.NumberStyles.HexNumber"/> values.
        /// </exception>
        public static Opt<byte> ParseByte(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<byte>.Call(byte.TryParse, s, style, provider);

        /// <summary>
        /// Converts the value of the specified string to its equivalent Unicode character. The
        /// result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="char.TryParse(string, out char)"/>
        /// as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains a Unicode character equivalent to the sole character in <paramref
        /// name="s"/>, if the conversion succeeded; otherwise, an empty option. The conversion fails
        /// if the <paramref name="s"/> parameter is null or the length of <paramref name="s"/> is
        /// not 1.
        /// </returns>
        /// <param name="s">A string that contains a single character, or null.</param>
        public static Opt<char> ParseChar(string s) => TryToOpt<char>.Call(char.TryParse, s);

        /// <summary>
        /// Converts the specified string representation of a date and time to its <see
        /// cref="T:System.DateTime"/> equivalent and returns an option containing the result of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTime.TryParse(string, out
        /// DateTime)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the <see cref="T:System.DateTime"/> value equivalent to the date
        /// and time contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an
        /// empty option. The conversion fails if the <paramref name="s"/> parameter is null, is an
        /// empty string (""), or does not contain a valid string representation of a date and time.
        /// </returns>
        /// <param name="s">A string containing a date and time to convert.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The date is in Japanese Emperor Year (Wareki) format and the year is out of range.
        /// </exception>
        public static Opt<DateTime> ParseDateTime(string s) => TryToOpt<DateTime>.Call(DateTime.TryParse, s);

        /// <summary>
        /// Converts the specified string representation of a date and time to its <see
        /// cref="T:System.DateTime"/> equivalent using the specified culture-specific format
        /// information and formatting style, and returns an option containing the result of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTime.TryParse(string,
        /// IFormatProvider, DateTimeStyles, out DateTime)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the <see cref="T:System.DateTime"/> value equivalent to the date
        /// and time contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an
        /// empty option. The conversion fails if the <paramref name="s"/> parameter is null, is an
        /// empty string (""), or does not contain a valid string representation of a date and time.
        /// </returns>
        /// <param name="s">A string containing a date and time to convert.</param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="s"/>.
        /// </param>
        /// <param name="styles">
        /// A bitwise combination of enumeration values that defines how to interpret the parsed date
        /// in relation to the current time zone or the current date. A typical value to specify is
        /// <see cref="F:System.Globalization.DateTimeStyles.None"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="styles"/> is not a valid <see
        /// cref="T:System.Globalization.DateTimeStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="styles"/> contains an invalid combination of <see
        /// cref="T:System.Globalization.DateTimeStyles"/> values (for example, both <see
        /// cref="F:System.Globalization.DateTimeStyles.AssumeLocal"/> and <see cref="F:System.Globalization.DateTimeStyles.AssumeUniversal"/>).
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The date is in Japanese Emperor Year (Wareki) format and the year is out of range.
        /// </exception>
        /// <exception cref="T:System.NotSupportedException">
        /// <paramref name="provider"/> is a neutral culture and cannot be used in a parsing operation.
        /// </exception>
        public static Opt<DateTime> ParseDateTime(string s, IFormatProvider provider, DateTimeStyles styles) => TryToOpt<DateTime>.Call(DateTime.TryParse, s, provider, styles);

        /// <summary>
        /// Converts the specified string representation of a date and time to its <see
        /// cref="T:System.DateTime"/> equivalent using the specified format, culture-specific format
        /// information, and style. The format of the string representation must match the specified
        /// format exactly. The method returns an option containing the result of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTime.TryParseExact(string,
        /// string, IFormatProvider, DateTimeStyles, out DateTime)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the <see cref="T:System.DateTime"/> value equivalent to the date
        /// and time contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an
        /// empty option. The conversion fails if either the <paramref name="s"/> or <paramref
        /// name="format"/> parameter is null, is an empty string, or does not contain a date and
        /// time that correspond to the pattern specified in <paramref name="format"/>.
        /// </returns>
        /// <param name="s">A string containing a date and time to convert.</param>
        /// <param name="format">The required format of <paramref name="s"/>.</param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="s"/>.
        /// </param>
        /// <param name="style">
        /// A bitwise combination of one or more enumeration values that indicate the permitted
        /// format of <paramref name="s"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a valid <see
        /// cref="T:System.Globalization.DateTimeStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> contains an invalid combination of <see
        /// cref="T:System.Globalization.DateTimeStyles"/> values (for example, both <see
        /// cref="F:System.Globalization.DateTimeStyles.AssumeLocal"/> and <see cref="F:System.Globalization.DateTimeStyles.AssumeUniversal"/>).
        /// </exception>
        public static Opt<DateTime> ParseDateTimeExact(string s, string format, IFormatProvider provider, DateTimeStyles style) => TryToOpt<DateTime>.Call(DateTime.TryParseExact, s, format, provider, style);

        /// <summary>
        /// Converts the specified string representation of a date and time to its <see
        /// cref="T:System.DateTime"/> equivalent using the specified array of formats,
        /// culture-specific format information, and style. The format of the string representation
        /// must match at least one of the specified formats exactly. The method returns an option
        /// containing the result of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTime.TryParseExact(string,
        /// string[], IFormatProvider, DateTimeStyles, out DateTime)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the <see cref="T:System.DateTime"/> value equivalent to the date
        /// and time contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an
        /// empty option. The conversion fails if <paramref name="s"/> or <paramref name="formats"/>
        /// is null, <paramref name="s"/> or an element of <paramref name="formats"/> is an empty
        /// string, or the format of <paramref name="s"/> is not exactly as specified by at least one
        /// of the format patterns in <paramref name="formats"/>.
        /// </returns>
        /// <param name="s">A string containing one or more dates and times to convert.</param>
        /// <param name="formats">An array of allowable formats of <paramref name="s"/>.</param>
        /// <param name="provider">
        /// An object that supplies culture-specific format information about <paramref name="s"/>.
        /// </param>
        /// <param name="style">
        /// A bitwise combination of enumeration values that indicates the permitted format of
        /// <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.DateTimeStyles.None"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a valid <see
        /// cref="T:System.Globalization.DateTimeStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> contains an invalid combination of <see
        /// cref="T:System.Globalization.DateTimeStyles"/> values (for example, both <see
        /// cref="F:System.Globalization.DateTimeStyles.AssumeLocal"/> and <see cref="F:System.Globalization.DateTimeStyles.AssumeUniversal"/>).
        /// </exception>
        public static Opt<DateTime> ParseDateTimeExact(string s, string[] formats, IFormatProvider provider, DateTimeStyles style) => TryToOpt<DateTime>.Call(DateTime.TryParseExact, s, formats, provider, style);

        /// <summary>
        /// Tries to converts a specified string representation of a date and time to its <see
        /// cref="T:System.DateTimeOffset"/> equivalent, and returns an option containing the result
        /// of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTimeOffset.TryParse(string, out
        /// DateTimeOffset)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the <see cref="T:System.DateTimeOffset"/> equivalent to the date
        /// and time of <paramref name="input"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="input"/> parameter is null or does
        /// not contain a valid string representation of a date and time.
        /// </returns>
        /// <param name="input">A string that contains a date and time to convert.</param>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The date is in Japanese Emperor Year (Wareki) format and the year is out of range.
        /// </exception>
        public static Opt<DateTimeOffset> ParseDateTimeOffset(string input) => TryToOpt<DateTimeOffset>.Call(DateTimeOffset.TryParse, input);

        /// <summary>
        /// Tries to convert a specified string representation of a date and time to its <see
        /// cref="T:System.DateTimeOffset"/> equivalent, and returns an option containing the result
        /// of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="DateTimeOffset.TryParse(string,
        /// IFormatProvider, DateTimeStyles, out DateTimeOffset)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the <see cref="T:System.DateTimeOffset"/> value equivalent to the
        /// date and time of <paramref name="input"/>, if the conversion succeeded; otherwise, an
        /// empty option. The conversion fails if the <paramref name="input"/> parameter is null or
        /// does not contain a valid string representation of a date and time.
        /// </returns>
        /// <param name="input">A string that contains a date and time to convert.</param>
        /// <param name="formatProvider">
        /// An object that provides culture-specific formatting information about <paramref name="input"/>.
        /// </param>
        /// <param name="styles">
        /// A bitwise combination of enumeration values that indicates the permitted format of
        /// <paramref name="input"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="styles"/> includes an undefined <see
        /// cref="T:System.Globalization.DateTimeStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <see cref="F:System.Globalization.DateTimeStyles.NoCurrentDateDefault"/> is not supported.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="styles"/> includes mutually exclusive <see
        /// cref="T:System.Globalization.DateTimeStyles"/> values.
        /// </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">
        /// The date is in Japanese Emperor Year (Wareki) format and the year is out of range.
        /// </exception>
        public static Opt<DateTimeOffset> ParseDateTimeOffset(string input, IFormatProvider formatProvider, DateTimeStyles styles) => TryToOpt<DateTimeOffset>.Call(DateTimeOffset.TryParse, input, formatProvider, styles);

        /// <summary>
        /// Converts the specified string representation of a date and time to its <see
        /// cref="T:System.DateTimeOffset"/> equivalent using the specified format, culture-specific
        /// format information, and style and returns the result as an option. The format of the
        /// string representation must match the specified format exactly.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see
        /// cref="DateTimeOffset.TryParseExact(string, string, IFormatProvider, DateTimeStyles, out
        /// DateTimeOffset)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the <see cref="T:System.DateTimeOffset"/> equivalent to the date
        /// and time of <paramref name="input"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="input"/> parameter is null, or does
        /// not contain a valid string representation of a date and time in the expected format
        /// defined by <paramref name="format"/> and <paramref name="formatProvider"/>.
        /// </returns>
        /// <param name="input">A string that contains a date and time to convert.</param>
        /// <param name="format">
        /// A format specifier that defines the required format of <paramref name="input"/>.
        /// </param>
        /// <param name="formatProvider">
        /// An object that supplies culture-specific formatting information about <paramref name="input"/>.
        /// </param>
        /// <param name="styles">
        /// A bitwise combination of enumeration values that indicates the permitted format of input.
        /// A typical value to specify is None.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="styles"/> includes an undefined <see
        /// cref="T:System.Globalization.DateTimeStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <see cref="F:System.Globalization.DateTimeStyles.NoCurrentDateDefault"/> is not supported.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="styles"/> includes mutually exclusive <see
        /// cref="T:System.Globalization.DateTimeStyles"/> values.
        /// </exception>
        public static Opt<DateTimeOffset> ParseDateTimeOffsetExact(string input, string format, IFormatProvider formatProvider, DateTimeStyles styles) => TryToOpt<DateTimeOffset>.Call(DateTimeOffset.TryParseExact, input, format, formatProvider, styles);

        /// <summary>
        /// Converts the string representation of a number to its <see cref="T:System.Decimal"/>
        /// equivalent. The result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="decimal.TryParse(string, out
        /// decimal)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the <see cref="T:System.Decimal"/> number that is equivalent to
        /// the numeric value contained in <paramref name="s"/>, if the conversion succeeded;
        /// otherwise, an empty option. The conversion fails if the <paramref name="s"/> parameter is
        /// null, is not a number in a valid format, or represents a number less than <see
        /// cref="F:System.Decimal.MinValue"/> or greater than <see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        /// <param name="s">The string representation of the number to convert.</param>
        public static Opt<decimal> ParseDecimal(string s) => TryToOpt<decimal>.Call(decimal.TryParse, s);

        /// <summary>
        /// Converts the string representation of a number to its <see cref="T:System.Decimal"/>
        /// equivalent using the specified style and culture-specific format. The result of the
        /// conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="decimal.TryParse(string,
        /// NumberStyles, IFormatProvider, out decimal)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the <see cref="T:System.Decimal"/> number that is equivalent to
        /// the numeric value contained in <paramref name="s"/>, if the conversion succeeded;
        /// otherwise, an empty option. The conversion fails if the <paramref name="s"/> parameter is
        /// null, is not in a format compliant with <paramref name="style"/>, or represents a number
        /// less than <see cref="F:System.Decimal.MinValue"/> or greater than <see cref="F:System.Decimal.MaxValue"/>.
        /// </returns>
        /// <param name="s">The string representation of the number to convert.</param>
        /// <param name="style">
        /// A bitwise combination of enumeration values that indicates the permitted format of
        /// <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Number"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific parsing information about <paramref name="s"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is the <see
        /// cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> value.
        /// </exception>
        public static Opt<decimal> ParseDecimal(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<decimal>.Call(decimal.TryParse, s, style, provider);

        /// <summary>
        /// Converts the string representation of a number to its double-precision floating-point
        /// number equivalent. The result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="double.TryParse(string, out
        /// double)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the double-precision floating-point number equivalent to the
        /// <paramref name="s"/> parameter, if the conversion succeeded; otherwise, an empty option.
        /// The conversion fails if the <paramref name="s"/> parameter is null, is not a number in a
        /// valid format, or represents a number less than <see cref="F:System.Double.MinValue"/> or
        /// greater than <see cref="F:System.Double.MaxValue"/>.
        /// </returns>
        /// <param name="s">A string containing a number to convert.</param>
        public static Opt<double> ParseDouble(string s) => TryToOpt<double>.Call(double.TryParse, s);

        /// <summary>
        /// Converts the string representation of a number in a specified style and culture-specific
        /// format to its double-precision floating-point number equivalent. The result of the
        /// conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="double.TryParse(string,
        /// NumberStyles, IFormatProvider, out double)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains a double-precision floating-point number equivalent to the
        /// numeric value or symbol contained in <paramref name="s"/>, if the conversion succeeded;
        /// otherwise, an empty option. The conversion fails if the <paramref name="s"/> parameter is
        /// null, is not in a format compliant with <paramref name="style"/>, represents a number
        /// less than <see cref="F:System.SByte.MinValue"/> or greater than <see
        /// cref="F:System.SByte.MaxValue"/>, or if <paramref name="style"/> is not a valid
        /// combination of <see cref="T:System.Globalization.NumberStyles"/> enumerated constants.
        /// </returns>
        /// <param name="s">A string containing a number to convert.</param>
        /// <param name="style">
        /// A bitwise combination of <see cref="T:System.Globalization.NumberStyles"/> values that
        /// indicates the permitted format of <paramref name="s"/>. A typical value to specify is
        /// <see cref="F:System.Globalization.NumberStyles.Float"/> combined with <see cref="F:System.Globalization.NumberStyles.AllowThousands"/>.
        /// </param>
        /// <param name="provider">
        /// An <see cref="T:System.IFormatProvider"/> that supplies culture-specific formatting
        /// information about <paramref name="s"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> includes the <see
        /// cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> value.
        /// </exception>
        public static Opt<double> ParseDouble(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<double>.Call(double.TryParse, s, style, provider);

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated
        /// constants to an equivalent enumerated object. The result of the conversion is returned as
        /// an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="Enum.TryParse{TEnum}(string, out
        /// TEnum)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains an object of type <typeparamref name="TEnum"/> whose value is
        /// represented by <paramref name="value"/>, if the conversion succeeded; otherwise, an empty option.
        /// </returns>
        /// <param name="value">
        /// The string representation of the enumeration name or underlying value to convert.
        /// </param>
        /// <typeparam name="TEnum">The enumeration type to which to convert <paramref name="value"/>.</typeparam>
        /// <exception cref="T:System.ArgumentException">
        /// <typeparamref name="TEnum"/> is not an enumeration type.
        /// </exception>
        public static Opt<TEnum> ParseEnum<TEnum>(string value) where TEnum : struct => TryToOpt<TEnum>.Call(Enum.TryParse, value);

        /// <summary>
        /// Converts the string representation of the name or numeric value of one or more enumerated
        /// constants to an equivalent enumerated object. A parameter specifies whether the operation
        /// is case-sensitive. The result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="Enum.TryParse{TEnum}(string, bool,
        /// out TEnum)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains an object of type <typeparamref name="TEnum"/> whose value is
        /// represented by <paramref name="value"/>, if the conversion succeeded; otherwise, an empty option.
        /// </returns>
        /// <param name="value">
        /// The string representation of the enumeration name or underlying value to convert.
        /// </param>
        /// <param name="ignoreCase">true to ignore case; false to consider case.</param>
        /// <typeparam name="TEnum">The enumeration type to which to convert <paramref name="value"/>.</typeparam>
        /// <exception cref="T:System.ArgumentException">
        /// <typeparamref name="TEnum"/> is not an enumeration type.
        /// </exception>
        public static Opt<TEnum> ParseEnum<TEnum>(string value, bool ignoreCase) where TEnum : struct => TryToOpt<TEnum>.Call(Enum.TryParse, value, ignoreCase);

        /// <summary>
        /// Converts the string representation of a GUID to the equivalent <see
        /// cref="T:System.Guid"/> structure and returns the result as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="Guid.TryParse(string, out Guid)"/>
        /// as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the parsed value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <param name="input">The GUID to convert.</param>
        public static Opt<Guid> ParseGuid(string input) => TryToOpt<Guid>.Call(Guid.TryParse, input);

        /// <summary>
        /// Converts the string representation of a GUID to the equivalent <see
        /// cref="T:System.Guid"/> structure and returns the result as an option. provided that the
        /// string is in the specified format.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="Guid.TryParseExact(string, string,
        /// out Guid)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the parsed value, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <param name="input">The GUID to convert.</param>
        /// <param name="format">
        /// One of the following specifiers that indicates the exact format to use when interpreting
        /// <paramref name="input"/>: "N", "D", "B", "P", or "X".
        /// </param>
        public static Opt<Guid> ParseGuidExact(string input, string format) => TryToOpt<Guid>.Call(Guid.TryParseExact, input, format);

        /// <summary>
        /// Converts the string representation of a number to its 16-bit signed integer equivalent.
        /// The result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="short.TryParse(string, out
        /// short)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 16-bit signed integer value equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="s"/> parameter is null, is not of the
        /// correct format, or represents a number less than <see cref="F:System.Int16.MinValue"/> or
        /// greater than <see cref="F:System.Int16.MaxValue"/>.
        /// </returns>
        /// <param name="s">A string containing a number to convert.</param>
        public static Opt<short> ParseInt16(string s) => TryToOpt<short>.Call(short.TryParse, s);

        /// <summary>
        /// Converts the string representation of a number in a specified style and culture-specific
        /// format to its 16-bit signed integer equivalent. The result of the conversion is returned
        /// as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="short.TryParse(string,
        /// NumberStyles, IFormatProvider, out short)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 16-bit signed integer value equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="s"/> parameter is null, is not in a
        /// format compliant with <paramref name="style"/>, or represents a number less than <see
        /// cref="F:System.Int16.MinValue"/> or greater than <see cref="F:System.Int16.MaxValue"/>.
        /// </returns>
        /// <param name="s">
        /// A string containing a number to convert. The string is interpreted using the style
        /// specified by <paramref name="style"/>.
        /// </param>
        /// <param name="style">
        /// A bitwise combination of enumeration values that indicates the style elements that can be
        /// present in <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="s"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a combination of <see
        /// cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> and <see
        /// cref="F:System.Globalization.NumberStyles.HexNumber"/> values.
        /// </exception>
        public static Opt<short> ParseInt16(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<short>.Call(short.TryParse, s, style, provider);

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent.
        /// The result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="int.TryParse(string, out int)"/>
        /// as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 32-bit signed integer value equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="s"/> parameter is null, is not of the
        /// correct format, or represents a number less than <see cref="F:System.Int32.MinValue"/> or
        /// greater than <see cref="F:System.Int32.MaxValue"/>.
        /// </returns>
        /// <param name="s">A string containing a number to convert.</param>
        public static Opt<int> ParseInt32(string s) => TryToOpt<int>.Call(int.TryParse, s);

        /// <summary>
        /// Converts the string representation of a number in a specified style and culture-specific
        /// format to its 32-bit signed integer equivalent. The result of the conversion is returned
        /// as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="int.TryParse(string,
        /// NumberStyles, IFormatProvider, out int)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 32-bit signed integer value equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="s"/> parameter is null, is not in a
        /// format compliant with <paramref name="style"/>, or represents a number less than <see
        /// cref="F:System.Int32.MinValue"/> or greater than <see cref="F:System.Int32.MaxValue"/>.
        /// </returns>
        /// <param name="s">
        /// A string containing a number to convert. The string is interpreted using the style
        /// specified by <paramref name="style"/>.
        /// </param>
        /// <param name="style">
        /// A bitwise combination of enumeration values that indicates the style elements that can be
        /// present in <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="s"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a combination of <see
        /// cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> and <see
        /// cref="F:System.Globalization.NumberStyles.HexNumber"/> values.
        /// </exception>
        public static Opt<int> ParseInt32(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<int>.Call(int.TryParse, s, style, provider);

        /// <summary>
        /// Converts the string representation of a number to its 64-bit signed integer equivalent.
        /// The result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="long.TryParse(string, out long)"/>
        /// as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 64-bit signed integer value equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="s"/> parameter is null, is not of the
        /// correct format, or represents a number less than <see cref="F:System.Int64.MinValue"/> or
        /// greater than <see cref="F:System.Int64.MaxValue"/>.
        /// </returns>
        /// <param name="s">A string containing a number to convert.</param>
        public static Opt<long> ParseInt64(string s) => TryToOpt<long>.Call(long.TryParse, s);

        /// <summary>
        /// Converts the string representation of a number in a specified style and culture-specific
        /// format to its 64-bit signed integer equivalent. The result of the conversion is returned
        /// as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="long.TryParse(string,
        /// NumberStyles, IFormatProvider, out long)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 64-bit signed integer value equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="s"/> parameter is null, is not in a
        /// format compliant with <paramref name="style"/>, or represents a number less than <see
        /// cref="F:System.Int64.MinValue"/> or greater than <see cref="F:System.Int64.MaxValue"/>.
        /// </returns>
        /// <param name="s">
        /// A string containing a number to convert. The string is interpreted using the style
        /// specified by <paramref name="style"/>.
        /// </param>
        /// <param name="style">
        /// A bitwise combination of enumeration values that indicates the style elements that can be
        /// present in <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="s"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a combination of <see
        /// cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> and <see
        /// cref="F:System.Globalization.NumberStyles.HexNumber"/> values.
        /// </exception>
        public static Opt<long> ParseInt64(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<long>.Call(long.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert the string representation of a number to its <see
        /// cref="T:System.SByte"/> equivalent, and returns an option containing the result of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="sbyte.TryParse(string, out
        /// sbyte)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 8-bit signed integer value that is equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="s"/> parameter is null, is not in the
        /// correct format, or represents a number that is less than <see
        /// cref="F:System.SByte.MinValue"/> or greater than <see cref="F:System.SByte.MaxValue"/>.
        /// </returns>
        /// <param name="s">A string that contains a number to convert.</param>
        public static Opt<sbyte> ParseSByte(string s) => TryToOpt<sbyte>.Call(sbyte.TryParse, s);

        /// <summary>
        /// Tries to convert the string representation of a number in a specified style and
        /// culture-specific format to its <see cref="T:System.SByte"/> equivalent, and returns an
        /// option containing the result of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="sbyte.TryParse(string,
        /// NumberStyles, IFormatProvider, out sbyte)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 8-bit signed integer value equivalent to the number contained
        /// in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty option. The
        /// conversion fails if the <paramref name="s"/> parameter is null, is not in a format
        /// compliant with <paramref name="style"/>, or represents a number less than <see
        /// cref="F:System.SByte.MinValue"/> or greater than <see cref="F:System.SByte.MaxValue"/>.
        /// </returns>
        /// <param name="s">A string representing a number to convert.</param>
        /// <param name="style">
        /// A bitwise combination of enumeration values that indicates the permitted format of
        /// <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="s"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a combination of <see
        /// cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> and <see
        /// cref="F:System.Globalization.NumberStyles.HexNumber"/> values.
        /// </exception>
        public static Opt<sbyte> ParseSByte(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<sbyte>.Call(sbyte.TryParse, s, style, provider);

        /// <summary>
        /// Converts the string representation of a number to its single-precision floating-point
        /// number equivalent. The result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="float.TryParse(string, out
        /// float)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains single-precision floating-point number equivalent to the numeric
        /// value or symbol contained in <paramref name="s"/>, if the conversion succeeded;
        /// otherwise, an empty option. The conversion fails if the <paramref name="s"/> parameter is
        /// null, is not a number in a valid format, or represents a number less than <see
        /// cref="F:System.Single.MinValue"/> or greater than <see cref="F:System.Single.MaxValue"/>.
        /// </returns>
        /// <param name="s">A string representing a number to convert.</param>
        public static Opt<float> ParseSingle(string s) => TryToOpt<float>.Call(float.TryParse, s);

        /// <summary>
        /// Converts the string representation of a number in a specified style and culture-specific
        /// format to its single-precision floating-point number equivalent. The result of the
        /// conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="float.TryParse(string,
        /// NumberStyles, IFormatProvider, out float)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the single-precision floating-point number equivalent to the
        /// numeric value or symbol contained in <paramref name="s"/>, if the conversion succeeded;
        /// otherwise, an empty option. The conversion fails if the <paramref name="s"/> parameter is
        /// null, is not in a format compliant with <paramref name="style"/>, represents a number
        /// less than <see cref="F:System.Single.MinValue"/> or greater than <see
        /// cref="F:System.Single.MaxValue"/>, or if <paramref name="style"/> is not a valid
        /// combination of <see cref="T:System.Globalization.NumberStyles"/> enumerated constants.
        /// </returns>
        /// <param name="s">A string representing a number to convert.</param>
        /// <param name="style">
        /// A bitwise combination of enumeration values that indicates the permitted format of
        /// <paramref name="s"/>. A typical value to specify is <see
        /// cref="F:System.Globalization.NumberStyles.Float"/> combined with <see cref="F:System.Globalization.NumberStyles.AllowThousands"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="s"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is the <see
        /// cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> value.
        /// </exception>
        public static Opt<float> ParseSingle(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<float>.Call(float.TryParse, s, style, provider);

        /// <summary>
        /// Converts the string representation of a time interval to its <see
        /// cref="T:System.TimeSpan"/> equivalent and returns an option containing the result of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParse(string, out
        /// TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains an object that represents the time interval specified by
        /// <paramref name="s"/>, if the conversion succeeded; otherwise, an empty option.
        /// </returns>
        /// <param name="s">A string that specifies the time interval to convert.</param>
        public static Opt<TimeSpan> ParseTimeSpan(string s) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParse, s);

        /// <summary>
        /// Converts the string representation of a time interval to its <see
        /// cref="T:System.TimeSpan"/> equivalent by using the specified culture-specific formatting
        /// information, and returns an option containing the result of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParse(string,
        /// IFormatProvider, out TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains an object that represents the time interval specified by
        /// <paramref name="input"/>, if the conversion succeeded; otherwise, an empty option.
        /// </returns>
        /// <param name="input">A string that specifies the time interval to convert.</param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        public static Opt<TimeSpan> ParseTimeSpan(string input, IFormatProvider formatProvider) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParse, input, formatProvider);

        /// <summary>
        /// Converts the string representation of a time interval to its <see
        /// cref="T:System.TimeSpan"/> equivalent by using the specified format and culture-specific
        /// format information, and returns an option containing the result of the conversion. The
        /// format of the string representation must match the specified format exactly.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParseExact(string,
        /// string, IFormatProvider, out TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains an object that represents the time interval specified by
        /// <paramref name="input"/>, if the conversion succeeded; otherwise, an empty option.
        /// </returns>
        /// <param name="input">A string that specifies the time interval to convert.</param>
        /// <param name="format">
        /// A standard or custom format string that defines the required format of <paramref name="input"/>.
        /// </param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        public static Opt<TimeSpan> ParseTimeSpanExact(string input, string format, IFormatProvider formatProvider) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParseExact, input, format, formatProvider);

        /// <summary>
        /// Converts the specified string representation of a time interval to its <see
        /// cref="T:System.TimeSpan"/> equivalent by using the specified formats and culture-specific
        /// format information, and returns an option containing the result of the conversion. The
        /// format of the string representation must match one of the specified formats exactly.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParseExact(string,
        /// string[], IFormatProvider, out TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains an object that represents the time interval specified by
        /// <paramref name="input"/>, if the conversion succeeded; otherwise, an empty option.
        /// </returns>
        /// <param name="input">A string that specifies the time interval to convert.</param>
        /// <param name="formats">
        /// A array of standard or custom format strings that define the acceptable formats of
        /// <paramref name="input"/>.
        /// </param>
        /// <param name="formatProvider">An object that provides culture-specific formatting information.</param>
        public static Opt<TimeSpan> ParseTimeSpanExact(string input, string[] formats, IFormatProvider formatProvider) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParseExact, input, formats, formatProvider);

        /// <summary>
        /// Converts the string representation of a time interval to its <see
        /// cref="T:System.TimeSpan"/> equivalent by using the specified format, culture-specific
        /// format information, and styles, and returns an option containing the result of the
        /// conversion. The format of the string representation must match the specified format exactly.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParseExact(string,
        /// string, IFormatProvider, TimeSpanStyles, out TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains an object that represents the time interval specified by
        /// <paramref name="input"/>, if the conversion succeeded; otherwise, an empty option.
        /// </returns>
        /// <param name="input">A string that specifies the time interval to convert.</param>
        /// <param name="format">
        /// A standard or custom format string that defines the required format of <paramref name="input"/>.
        /// </param>
        /// <param name="formatProvider">An object that provides culture-specific formatting information.</param>
        /// <param name="styles">
        /// One or more enumeration values that indicate the style of <paramref name="input"/>.
        /// </param>
        public static Opt<TimeSpan> ParseTimeSpanExact(string input, string format, IFormatProvider formatProvider, TimeSpanStyles styles) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParseExact, input, format, formatProvider, styles);

        /// <summary>
        /// Converts the specified string representation of a time interval to its <see
        /// cref="T:System.TimeSpan"/> equivalent by using the specified formats, culture-specific
        /// format information, and styles, and returns an option containing the result of the
        /// conversion. The format of the string representation must match one of the specified
        /// formats exactly.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="TimeSpan.TryParseExact(string,
        /// string[], IFormatProvider, TimeSpanStyles, out TimeSpan)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains an object that represents the time interval specified by
        /// <paramref name="input"/>, if the conversion succeeded; otherwise, an empty option.
        /// </returns>
        /// <param name="input">A string that specifies the time interval to convert.</param>
        /// <param name="formats">
        /// A array of standard or custom format strings that define the acceptable formats of
        /// <paramref name="input"/>.
        /// </param>
        /// <param name="formatProvider">An object that supplies culture-specific formatting information.</param>
        /// <param name="styles">
        /// One or more enumeration values that indicate the style of <paramref name="input"/>.
        /// </param>
        public static Opt<TimeSpan> ParseTimeSpanExact(string input, string[] formats, IFormatProvider formatProvider, TimeSpanStyles styles) => TryToOpt<TimeSpan>.Call(TimeSpan.TryParseExact, input, formats, formatProvider, styles);

        /// <summary>
        /// Tries to convert the string representation of a number to its 16-bit unsigned integer
        /// equivalent. The result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="ushort.TryParse(string, out
        /// ushort)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 16-bit unsigned integer value that is equivalent to the
        /// number contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an
        /// empty option. The conversion fails if the <paramref name="s"/> parameter is null, is not
        /// in the correct format. , or represents a number less than <see
        /// cref="F:System.UInt16.MinValue"/> or greater than <see cref="F:System.UInt16.MaxValue"/>.
        /// </returns>
        /// <param name="s">A string that represents the number to convert.</param>
        public static Opt<ushort> ParseUInt16(string s) => TryToOpt<ushort>.Call(ushort.TryParse, s);

        /// <summary>
        /// Tries to convert the string representation of a number in a specified style and
        /// culture-specific format to its 16-bit unsigned integer equivalent. The result of the
        /// conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="ushort.TryParse(string,
        /// NumberStyles, IFormatProvider, out ushort)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 16-bit unsigned integer value equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="s"/> parameter is null, is not in a
        /// format compliant with <paramref name="style"/>, or represents a number less than <see
        /// cref="F:System.UInt16.MinValue"/> or greater than <see cref="F:System.UInt16.MaxValue"/>.
        /// </returns>
        /// <param name="s">
        /// A string that represents the number to convert. The string is interpreted by using the
        /// style specified by the <paramref name="style"/> parameter.
        /// </param>
        /// <param name="style">
        /// A bitwise combination of enumeration values that indicates the permitted format of
        /// <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="s"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a combination of <see
        /// cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> and <see
        /// cref="F:System.Globalization.NumberStyles.HexNumber"/> values.
        /// </exception>
        public static Opt<ushort> ParseUInt16(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<ushort>.Call(ushort.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert the string representation of a number to its 32-bit unsigned integer
        /// equivalent. The result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="uint.TryParse(string, out
        /// uint)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 32-bit unsigned integer value that is equivalent to the
        /// number contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an
        /// empty option. The conversion fails if the <paramref name="s"/> parameter is null, is not
        /// of the correct format, or represents a number that is less than <see
        /// cref="F:System.UInt32.MinValue"/> or greater than <see cref="F:System.UInt32.MaxValue"/>.
        /// </returns>
        /// <param name="s">A string that represents the number to convert.</param>
        public static Opt<uint> ParseUInt32(string s) => TryToOpt<uint>.Call(uint.TryParse, s);

        /// <summary>
        /// Tries to convert the string representation of a number in a specified style and
        /// culture-specific format to its 32-bit unsigned integer equivalent. The result of the
        /// conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="uint.TryParse(string,
        /// NumberStyles, IFormatProvider, out uint)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 32-bit unsigned integer value equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="s"/> parameter is null, is not in a
        /// format compliant with <paramref name="style"/>, or represents a number that is less than
        /// <see cref="F:System.UInt32.MinValue"/> or greater than <see cref="F:System.UInt32.MaxValue"/>.
        /// </returns>
        /// <param name="s">
        /// A string that represents the number to convert. The string is interpreted by using the
        /// style specified by the <paramref name="style"/> parameter.
        /// </param>
        /// <param name="style">
        /// A bitwise combination of enumeration values that indicates the permitted format of
        /// <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="s"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a combination of <see
        /// cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> and <see
        /// cref="F:System.Globalization.NumberStyles.HexNumber"/> values.
        /// </exception>
        public static Opt<uint> ParseUInt32(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<uint>.Call(uint.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert the string representation of a number to its 64-bit unsigned integer
        /// equivalent. The result of the conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="ulong.TryParse(string, out
        /// ulong)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 64-bit unsigned integer value that is equivalent to the
        /// number contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an
        /// empty option. The conversion fails if the <paramref name="s"/> parameter is null, is not
        /// of the correct format, or represents a number less than <see
        /// cref="F:System.UInt64.MinValue"/> or greater than <see cref="F:System.UInt64.MaxValue"/>.
        /// </returns>
        /// <param name="s">A string that represents the number to convert.</param>
        public static Opt<ulong> ParseUInt64(string s) => TryToOpt<ulong>.Call(ulong.TryParse, s);

        /// <summary>
        /// Tries to convert the string representation of a number in a specified style and
        /// culture-specific format to its 64-bit unsigned integer equivalent. The result of the
        /// conversion is returned as an option.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="ulong.TryParse(string,
        /// NumberStyles, IFormatProvider, out ulong)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the 64-bit unsigned integer value equivalent to the number
        /// contained in <paramref name="s"/>, if the conversion succeeded; otherwise, an empty
        /// option. The conversion fails if the <paramref name="s"/> parameter is null, is not in a
        /// format compliant with <paramref name="style"/>, or represents a number less than <see
        /// cref="F:System.UInt64.MinValue"/> or greater than <see cref="F:System.UInt64.MaxValue"/>.
        /// </returns>
        /// <param name="s">
        /// A string that represents the number to convert. The string is interpreted by using the
        /// style specified by the <paramref name="style"/> parameter.
        /// </param>
        /// <param name="style">
        /// A bitwise combination of enumeration values that indicates the permitted format of
        /// <paramref name="s"/>. A typical value to specify is <see cref="F:System.Globalization.NumberStyles.Integer"/>.
        /// </param>
        /// <param name="provider">
        /// An object that supplies culture-specific formatting information about <paramref name="s"/>.
        /// </param>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a <see cref="T:System.Globalization.NumberStyles"/> value.
        /// </exception>
        /// <exception cref="T:System.ArgumentException">
        /// <paramref name="style"/> is not a combination of <see
        /// cref="F:System.Globalization.NumberStyles.AllowHexSpecifier"/> and <see
        /// cref="F:System.Globalization.NumberStyles.HexNumber"/> values.
        /// </exception>
        public static Opt<ulong> ParseUInt64(string s, NumberStyles style, IFormatProvider provider) => TryToOpt<ulong>.Call(ulong.TryParse, s, style, provider);

        /// <summary>
        /// Tries to convert the string representation of a version number to an equivalent <see
        /// cref="T:System.Version"/> object, and returns an option containing the result of the conversion.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method returns the result produced by <see cref="Version.TryParse(string, out
        /// Version)"/> as an option.
        /// </para>
        /// </remarks>
        /// <returns>
        /// An option that contains the <see cref="T:System.Version"/> equivalent of the number that
        /// is contained in <paramref name="input"/>, if the conversion succeeded; otherwise, an
        /// empty option.
        /// </returns>
        /// <param name="input">A string that contains a version number to convert.</param>
        public static Opt<Version> ParseVersion(string input) => TryToOpt<Version>.Call(Version.TryParse, input);
    }
}