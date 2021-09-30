using System;

namespace Digbyswift.Extensions
{
    public static class NumericExtensions
    {
        private const int HundredPercent = 100;

        /// <summary>
        /// Since a Double cannot reliably be exactly zero, this determines
        /// whether the value passed is greater or equal to zero, and less than
        /// Double.Epsilon. If so, then the value can be treated as zero.
        /// </summary>
        public static bool IsZero(this double value)
        {
            return 0 <= Math.Abs(value) && Math.Abs(value) < Double.Epsilon;
        }

        public static bool IsEven(this int value)
        {
            if (value == 0)
                return true;

            return value % 2 == 0;
        }

        public static float AsPercentageOf(this int proportion, int total)
        {
            if(proportion == 0 || total == 0)
                return 0;

            return (proportion / (float)total) * HundredPercent;
        }

        public static decimal AsPercentageOf(this decimal proportion, decimal total)
        {
            if (proportion == Decimal.Zero || total == Decimal.Zero)
                return 0;

            return (proportion / total) * HundredPercent;
        }

        public static double AsPercentageOf(this double proportion, double total)
        {
            if (Math.Abs(proportion) < Double.Epsilon || Math.Abs(total) < Double.Epsilon)
                return 0;

            return (proportion / total) * HundredPercent;
        }

    }
}