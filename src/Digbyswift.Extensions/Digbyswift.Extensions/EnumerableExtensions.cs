using System;
using System.Collections.Generic;
using System.Linq;

namespace Digbyswift.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool NotContains<T>(this IEnumerable<T> value, T item)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return !value.Contains(item);
        }

        public static bool IsEmpty<T>(this IEnumerable<T> value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return !value.Any();
        }
        
        public static bool None<T>(this IEnumerable<T> value, Func<T, bool> func)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return !value.Any(func);
        }
        
        public static T MinOrDefault<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            return sequence.Any() ? sequence.Min() : default(T);
        }

        public static T MaxOrDefault<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            return sequence.Any() ? sequence.Max() : default(T);
        }

    }
}
