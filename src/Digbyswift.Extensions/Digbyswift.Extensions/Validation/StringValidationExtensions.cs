using System;
using Digbyswift.Core.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Digbyswift.Extensions.Validation
{
    public static class StringValidationExtensions
	{

        public static bool IsEmail(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsEmail.Value.IsMatch(value);
        }

        public static bool ContainsEmail(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsEmail.Value.IsMatch(value);
        }

        public static bool IsUrl(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsUrl.Value.IsMatch(value);
        }

        public static bool ContainsUrl(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsUrl.Value.IsMatch(value);
        }

        public static bool IsIPv4(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsIPv4.Value.IsMatch(value);
        }

        public static bool ContainsIPv4(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsIPv4.Value.IsMatch(value);
        }

        public static bool IsIPv6(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsIPv6.Value.IsMatch(value);
        }

        public static bool ContainsIPv6(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsIPv6.Value.IsMatch(value);
        }

        public static bool IsWholeNumber(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsWholeNumber.Value.IsMatch(value);
        }

        public static bool IsAlphaNumeric(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsAlphaNumeric.Value.IsMatch(value);
        }

        public static bool IsNumeric(this string value, NumericMatchType matchType = NumericMatchType.Any)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            switch (matchType)
            {
                case NumericMatchType.Any:
                    return Regex.IsNumeric.Value.IsMatch(value);
                
                case NumericMatchType.Integer:
                    return Regex.IsWholeNumber.Value.IsMatch(value);
            }

            throw new ArgumentOutOfRangeException(nameof(matchType));
        }

        public static bool IsUkTelephone(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsUkPhoneNumber.Value.IsMatch(value);
        }

        public static bool ContainsUkTelephone(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsUkPhoneNumber.Value.IsMatch(value);
        }

        public static bool IsMarkup(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.IsMarkup.Value.IsMatch(value);
        }

        public static bool ContainsMarkup(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return Regex.ContainsMarkup.Value.IsMatch(value);
        }

        public static bool HasExtension(this string value)
        {
            return Regex.HasFileExtension.Value.IsMatch(value);
        }

        public static bool IsJson(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            var workingValue = value.Trim();

            if (!(workingValue.StartsWith("{") && workingValue.EndsWith("}")) ||
                !(workingValue.StartsWith("[") && !workingValue.EndsWith("]")))
            {
                return false;
            }

            try
            {
                JToken.Parse(workingValue);
                return true;
            }
            catch
            {
                return false;
            }
        } 

	}
}