using System;
using System.Collections.Generic;
using System.Linq;
using Digbyswift.Core.Constants;

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
        
        public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T> value)
        {
            return value.Where(x => x != null);
        }
        
        public static bool None<T>(this IEnumerable<T> value, Func<T, bool> func)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (func == null)
                throw new ArgumentNullException(nameof(func));

            return !value.Any(func);
        }
        
        public static T? MinOrDefault<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            return sequence.Any() ? sequence.Min() : default(T);
        }

        public static T? MaxOrDefault<T>(this IEnumerable<T> sequence)
        {
            if (sequence == null)
                throw new ArgumentNullException(nameof(sequence));

            return sequence.Any() ? sequence.Max() : default(T);
        }
        
        public static bool CountIs<T>(this IEnumerable<T> value, int count)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

            return value.Count() == count;
        }

        public static bool CountIsLt<T>(this IEnumerable<T> value, int count)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (count < NumericConstants.One)
                throw new ArgumentOutOfRangeException(nameof(count), "Must be one or greater");

            return value.Count() < count;
        }

        public static bool CountIsLe<T>(this IEnumerable<T> value, int count)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (count < NumericConstants.Zero)
                throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

            return value.Count() <= count;
        }

        public static bool CountIsGt<T>(this IEnumerable<T> value, int count)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (count < NumericConstants.Zero)
                throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

            return value.Count() > count;
        }

        public static bool CountIsGe<T>(this IEnumerable<T> value, int count)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (count < NumericConstants.Zero)
                throw new ArgumentOutOfRangeException(nameof(count), "Must be zero or greater");

            return value.Count() >= count;
        }

    }
}
