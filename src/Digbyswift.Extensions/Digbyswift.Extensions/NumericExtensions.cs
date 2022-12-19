using System;
using Digbyswift.Core.Constants;

namespace Digbyswift.Extensions
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Since a Double cannot reliably be exactly zero, this determines
        /// whether the value passed is greater or equal to zero, and less than
        /// Double.Epsilon. If so, then the value can be treated as zero.
        /// </summary>
        public static bool IsZero(this double value)
        {
            return NumericConstants.Zero <= Math.Abs(value) && Math.Abs(value) < Double.Epsilon;
        }

        public static bool IsEven(this int value)
        {
            if (value == NumericConstants.Zero)
                return true;

            return value % 2 == NumericConstants.Zero;
        }

        public static float AsPercentageOf(this int proportion, int total)
        {
            if(proportion == NumericConstants.Zero || total == NumericConstants.Zero)
                return NumericConstants.Zero;

            return (proportion / (float)total) * NumericConstants.Hundred;
        }

        public static decimal AsPercentageOf(this decimal proportion, decimal total)
        {
            if (proportion == Decimal.Zero || total == Decimal.Zero)
                return NumericConstants.Zero;

            return (proportion / total) * NumericConstants.Hundred;
        }

        public static double AsPercentageOf(this double proportion, double total)
        {
            if (Math.Abs(proportion) < Double.Epsilon || Math.Abs(total) < Double.Epsilon)
                return NumericConstants.Zero;

            return (proportion / total) * NumericConstants.Hundred;
        }

    }
}