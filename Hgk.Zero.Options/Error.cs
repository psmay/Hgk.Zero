using System;

namespace Hgk.Zero.Options
{
    internal static class Error
    {
        internal static ArgumentException ArrayPlusOffTooSmall() => new ArgumentException(ErrorMessages.ArrayPlusOffTooSmall);

        internal static InvalidOperationException MatchCaseFailed() => new InvalidOperationException(ErrorMessages.MatchCaseFailed);

        internal static InvalidOperationException MoreThanOneElement() => new InvalidOperationException(ErrorMessages.MoreThanOneElement);

        internal static InvalidOperationException MoreThanOneMatch() => new InvalidOperationException(ErrorMessages.MoreThanOneMatch);

        internal static InvalidOperationException MoreThanOneResult(bool usingPredicate) => usingPredicate ? MoreThanOneMatch() : MoreThanOneElement();

        internal static InvalidOperationException NoElements() => new InvalidOperationException(ErrorMessages.NoElements);

        internal static InvalidOperationException NoMatch() => new InvalidOperationException(ErrorMessages.NoMatches);

        internal static InvalidOperationException NoOptionValue() => new InvalidOperationException(ErrorMessages.NoOptionValue);

        internal static InvalidOperationException OptionEnumeratorMoreThanOneElement() => new InvalidOperationException("Implementation error - Option enumeration yielded more than one element");
    }
}