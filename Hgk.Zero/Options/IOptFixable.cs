namespace Hgk.Zero.Options
{
    /// <summary>
    /// Type that can be directly fixed to an <see cref="object"/>-valued instance of <see cref="Opt{T}"/>.
    /// </summary>
    internal interface IOptFixable
    {
        Opt<object> ToFixed();
    }

    /// <summary>
    /// Type that can be directly fixed to an instance of <see cref="Opt{T}"/>.
    /// </summary>
    internal interface IOptFixable<T> : IOptFixable
    {
        new Opt<T> ToFixed();
    }
}