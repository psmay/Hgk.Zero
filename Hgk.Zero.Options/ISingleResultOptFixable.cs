namespace Hgk.Zero.Options
{
    /// <summary>
    /// Type that can be directly fixed to an <see cref="object"/>-valued instance of <see cref="FixedSingleResultOpt{T}"/>.
    /// </summary>
    internal interface ISingleResultOptFixable
    {
        FixedSingleResultOpt<object> ToFixedSingleResultOpt();
    }

    /// <summary>
    /// Type that can be directly fixed to an instance of <see cref="FixedSingleResultOpt{T}"/>.
    /// </summary>
    internal interface ISingleResultOptFixable<T> : ISingleResultOptFixable
    {
        new FixedSingleResultOpt<T> ToFixedSingleResultOpt();
    }
}