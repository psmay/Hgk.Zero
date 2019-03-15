namespace Hgk.Zero.Options
{
    internal static class OptEquality
    {
        /// <summary>
        /// Implements equality for an IOpt that is not also an ISingleResultOpt.
        /// </summary>
        internal static bool PlainOptEqualsObject(IOpt _this, object obj)
        {
            if (_this == obj)
                return true;
            else if (_this == null || obj == null)
                return false;
            else
                return PlainOptEqualsObjectRaw(_this, obj);
        }

        /// <summary>
        /// Implements equality for an ISingleResultOpt.
        /// </summary>
        internal static bool SingleResultOptEqualsObject(ISingleResultOpt _this, object obj)
        {
            if (_this == obj)
                return true;
            else if (_this == null || obj == null)
                return false;
            else
                return SingleResultOptEqualsObjectRaw(_this, obj);
        }

        private static bool FixedEquals<T>(this FixedSingleResultOpt<T> fixedA, FixedSingleResultOpt<T> fixedB)
        {
            if (fixedA.IsValidOption && fixedB.IsValidOption)
            {
                if (fixedA.HasValue)
                    return fixedB.HasValue && Equals(fixedA.ValueOrDefault, fixedB.ValueOrDefault);
                else
                    return !fixedB.HasValue;
            }
            else
            {
                // Only valid options can equal other options
                return false;
            }
        }

        private static bool FixedEquals<T>(Opt<T> fixedA, Opt<T> fixedB)
        {
            if (fixedA.HasValue)
                return fixedB.HasValue && Equals(fixedA.ValueOrDefault, fixedB.ValueOrDefault);
            else
                return !fixedB.HasValue;
        }

        private static bool PlainOptEqualsObjectRaw(IOpt a, object b)
        {
            if (b is ISingleResultOpt sb)
                return PlainOptEqualsSingleResultOpt(a, sb);
            else if (b is IOpt pb)
                return PlainOptEqualsPlainOpt(a, pb);
            else
                return false;
        }

        private static bool PlainOptEqualsPlainOpt(IOpt a, IOpt b) =>
            FixedEquals(Opt.FixUntyped(a), Opt.FixUntyped(b));

        private static bool PlainOptEqualsSingleResultOpt(IOpt a, ISingleResultOpt b) =>
            FixedEquals(a.ToFixedSingleResultOpt(), b.ToFixedSingleResultOpt());

        private static bool SingleResultOptEqualsObjectRaw(ISingleResultOpt a, object b)
        {
            if (b is ISingleResultOpt sb)
                return SingleResultOptEqualsSingleResultOpt(a, sb);
            else if (b is IOpt pb)
                return SingleResultOptEqualsPlainOpt(a, pb);
            else
                return false;
        }

        private static bool SingleResultOptEqualsPlainOpt(ISingleResultOpt a, IOpt b) =>
            FixedEquals(a.ToFixedSingleResultOpt(), b.ToFixedSingleResultOpt());

        private static bool SingleResultOptEqualsSingleResultOpt(ISingleResultOpt a, ISingleResultOpt b) =>
            FixedEquals(a.ToFixedSingleResultOpt(), b.ToFixedSingleResultOpt());
    }
}