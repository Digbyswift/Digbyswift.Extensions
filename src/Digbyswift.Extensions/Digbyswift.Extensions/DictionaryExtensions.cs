using System;
using System.Collections.Generic;

namespace Digbyswift.Extensions
{
    public static class DictionaryExtensions
    {
        public static void Set<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        public static bool ContainsKeyAndValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (!dictionary.ContainsKey(key))
                return false;

            return dictionary[key].Equals(value);
        }

        public static bool ContainsKeyAndValue(this IDictionary<string, string> dictionary, string key, string value, StringComparison stringComparison = StringComparison.CurrentCulture)
        {
            if (!dictionary.ContainsKey(key))
                return false;

            return dictionary[key].Equals(value, stringComparison);
        }

        public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            if (!dictionary.ContainsKey(key))
                return defaultValue;

            return dictionary[key];
        }

        public static TValue GetOrNull<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key) where TValue : class
        {
            if (!dictionary.ContainsKey(key))
                return null;

            return dictionary[key];
        }
    }
}