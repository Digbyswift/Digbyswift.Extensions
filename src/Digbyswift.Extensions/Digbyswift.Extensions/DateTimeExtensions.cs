using System;
using Digbyswift.Core.Constants;
using Digbyswift.Core.Models;

namespace Digbyswift.Extensions
{
    public static class DateTimeExtensions
    {
        public static int GetDaysUntil(this DateTime dateTime)
        {
            return (dateTime - SystemTime.LocalToday()).Days;
        }
        
        public static int GetAgeNextBirthday(this DateTime dob)
        {
            var today = SystemTime.LocalToday();
            var ageNextBirthday = today.Year - dob.Year;

            if (dob.AddYears(ageNextBirthday) < today)
            {
                ageNextBirthday++;
            }

            return ageNextBirthday;
        }

        public static int GetAge(this DateTime dob)
        {
            if (dob.Date == SystemTime.LocalToday())
                return NumericConstants.Zero;

            if (dob > SystemTime.LocalToday())
                return GetAgeNextBirthday(dob);
            
            return GetAgeNextBirthday(dob) - NumericConstants.One;
        }
    }
}