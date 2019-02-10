using Hgk.Zero.Options.Try;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace Hgk.Zero.Options.Query
{
    /// <summary>
    /// Facility for retrieving a value from a dictionary as an option.
    /// </summary>
    public static class DictionaryToOpt
    {
        /// <summary>
        /// Gets the value associated with a specified key as an option.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/>.</typeparam>
        /// <param name="source">A source dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// An option containing the value associated with <paramref name="key"/> in <paramref
        /// name="source"/>, if it is found; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TValue> GetValueOpt<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return TryToOpt<TValue>.Call(source.TryGetValue, key);
        }

        /// <summary>
        /// Gets the value associated with a specified key as an option.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/>.</typeparam>
        /// <param name="source">A source dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// An option containing the value associated with <paramref name="key"/> in <paramref
        /// name="source"/>, if it is found; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TValue> GetValueOpt<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source, TKey key)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return TryToOpt<TValue>.Call(source.TryGetValue, key);
        }

        /// <summary>
        /// Gets the value associated with a specified key as an option.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/>.</typeparam>
        /// <param name="source">A source dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// An option containing the value associated with <paramref name="key"/> in <paramref
        /// name="source"/>, if it is found; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TValue> GetValueOpt<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> source, TKey key) =>
            source.AsReadOnlyDictionary().GetValueOpt(key);

        /// <summary>
        /// Gets the value associated with a specified key as an option.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/>.</typeparam>
        /// <param name="source">A source dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// An option containing the value associated with <paramref name="key"/> in <paramref
        /// name="source"/>, if it is found; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TValue> GetValueOpt<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey key) =>
            source.AsReadOnlyDictionary().GetValueOpt(key);

        /// <summary>
        /// Gets the value associated with a specified key as an option.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/>.</typeparam>
        /// <param name="source">A source dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// An option containing the value associated with <paramref name="key"/> in <paramref
        /// name="source"/>, if it is found; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TValue> GetValueOpt<TKey, TValue>(this SortedDictionary<TKey, TValue> source, TKey key) =>
            source.AsReadOnlyDictionary().GetValueOpt(key);

        /// <summary>
        /// Gets the value associated with a specified key as an option.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/>.</typeparam>
        /// <param name="source">A source dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// An option containing the value associated with <paramref name="key"/> in <paramref
        /// name="source"/>, if it is found; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TValue> GetValueOpt<TKey, TValue>(this SortedList<TKey, TValue> source, TKey key) =>
            source.AsReadOnlyDictionary().GetValueOpt(key);

        /// <summary>
        /// Gets the value associated with a specified key as an option.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/>.</typeparam>
        /// <param name="source">A source dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// An option containing the value associated with <paramref name="key"/> in <paramref
        /// name="source"/>, if it is found; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TValue> GetValueOpt<TKey, TValue>(this ImmutableDictionary<TKey, TValue> source, TKey key) =>
            source.AsReadOnlyDictionary().GetValueOpt(key);

        /// <summary>
        /// Gets the value associated with a specified key as an option.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/>.</typeparam>
        /// <param name="source">A source dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// An option containing the value associated with <paramref name="key"/> in <paramref
        /// name="source"/>, if it is found; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TValue> GetValueOpt<TKey, TValue>(this ImmutableDictionary<TKey, TValue>.Builder source, TKey key) =>
            source.AsReadOnlyDictionary().GetValueOpt(key);

        /// <summary>
        /// Gets the value associated with a specified key as an option.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/>.</typeparam>
        /// <param name="source">A source dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// An option containing the value associated with <paramref name="key"/> in <paramref
        /// name="source"/>, if it is found; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TValue> GetValueOpt<TKey, TValue>(this ImmutableSortedDictionary<TKey, TValue>.Builder source, TKey key) =>
            source.AsReadOnlyDictionary().GetValueOpt(key);

        /// <summary>
        /// Gets the value associated with a specified key as an option.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/>.</typeparam>
        /// <param name="source">A source dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// An option containing the value associated with <paramref name="key"/> in <paramref
        /// name="source"/>, if it is found; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TValue> GetValueOpt<TKey, TValue>(this ImmutableSortedDictionary<TKey, TValue> source, TKey key) =>
            source.AsReadOnlyDictionary().GetValueOpt(key);

        /// <summary>
        /// Gets the value associated with a specified key as an option.
        /// </summary>
        /// <typeparam name="TKey">The type of the keys in <paramref name="source"/>.</typeparam>
        /// <typeparam name="TValue">The type of the values in <paramref name="source"/>.</typeparam>
        /// <param name="source">A source dictionary.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <returns>
        /// An option containing the value associated with <paramref name="key"/> in <paramref
        /// name="source"/>, if it is found; otherwise, an empty option.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="source"/> or <paramref name="key"/> is <see langword="null"/>.
        /// </exception>
        public static Opt<TValue> GetValueOpt<TKey, TValue>(this ReadOnlyDictionary<TKey, TValue> source, TKey key) =>
            source.AsReadOnlyDictionary().GetValueOpt(key);

        private static IReadOnlyDictionary<TKey, TValue> AsReadOnlyDictionary<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> source) => source;
    }
}