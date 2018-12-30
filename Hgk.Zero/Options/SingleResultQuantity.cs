namespace Hgk.Zero.Options
{
    /// <summary>
    /// Indicates the number of elements found while performing a SingleToOpt operation ( <see
    /// cref="Zero"/>, <see cref="One"/>, or <see cref="MoreThanOne"/>).
    /// </summary>
    internal enum SingleResultQuantity : byte
    {
        Zero = 0,
        One = 1,
        MoreThanOne
    }
}