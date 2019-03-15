using System.Linq;

namespace Hgk.Zero.Options.Linq
{
    /// <summary>
    /// Represents a zero-item or single-item grouping of objects with a common key.
    /// </summary>
    /// <typeparam name="TKey">The type of the key for the grouping.</typeparam>
    /// <typeparam name="TElement">The type of values in the grouping.</typeparam>

    public interface IOptGrouping<out TKey, out TElement> : IGrouping<TKey, TElement>, IOpt<TElement>
    {
    }
}