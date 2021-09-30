using System;
using Digbyswift.Core.Models;

namespace Digbyswift.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetDaysUntil(this DateTime dateTime)
        {
            return (dateTime - SystemTime.LocalToday()).Days;
        }
    }
}