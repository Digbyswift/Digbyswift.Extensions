using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Digbyswift.Extensions.Encryption
{
    public static class ShaExtensions
    {
        // ReSharper disable once InconsistentNaming
        public static string ToSHA1Hash(this string text)
        {
            using (var algorithm = SHA1.Create())
            {
                return algorithm.GenerateHashString(text);
            }
        }

        // ReSharper disable once InconsistentNaming
        public static string ToSHA256Hash(this string text)
        {
            using (var algorithm = SHA256.Create())
            {
                return algorithm.GenerateHashString(text);
            }
        }

        private static string GenerateHashString(this HashAlgorithm algorithm, string text)
        {
            algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
            var result = algorithm.Hash;
            if (result == null)
                throw new ArgumentException("Unable to create hash", nameof(text));
            
            return String.Join(String.Empty, result.Select(x => x.ToString("x2")));
        }
        
    }
}