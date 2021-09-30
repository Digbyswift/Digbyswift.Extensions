using System;
using Digbyswift.Core.RegularExpressions;

namespace Digbyswift.Extensions.Validation
{
	public static class StringValidationExtensions
	{

        public static bool IsEmail(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return RegexPatterns.EmailRegex.IsMatch(value);
        }

        public static bool IsUkTelephone(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return RegexPatterns.UkPhoneNumberRegex.IsMatch(value);
        }

        public static bool ContainsMarkup(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return false;

            return RegexPatterns.MarkupRegex.IsMatch(value);
        }

        public static bool HasExtension(this string value)
        {
            return RegexPatterns.FileExtensionRegex.IsMatch(value);
        }



	}
}