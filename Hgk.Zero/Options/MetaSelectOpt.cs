using System;

namespace Hgk.Zero.Options
{
    /// <summary>
    /// A complete deferred option based on the result of transforming an <see cref="Opt{T}"/> to a
    /// new <see cref="Opt{T}"/> (use <see cref="Opt.MetaSelect{TSource, TResult}(IOpt{TSource},
    /// Func{Opt{TSource}, Opt{TResult}})"/> to instantiate).
    /// </summary>
    internal class MetaSelectOpt<TSource, T> : AbstractOpt<T>
    {
        private readonly Func<Opt<TSource>, Opt<T>> metaselector;
        private readonly IOpt<TSource> source;

        public MetaSelectOpt(IOpt<TSource> source, Func<Opt<TSource>, Opt<T>> metaselector)
        {
            this.source = source;
            this.metaselector = metaselector;
        }

        public override Opt<T> ToFixed() => metaselector(source.ToFixed());
    }
}