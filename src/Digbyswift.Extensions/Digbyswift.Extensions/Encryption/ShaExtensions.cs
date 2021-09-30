using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Digbyswift.Extensions.Encryption
{
    public static class ShaExtensions
    {
        public static string ToSHA1Hash(this string text)
        {
            using (var algorithm = new SHA1Managed())
            {
                return algorithm.GenerateHashString(text);
            }
        }

        public static string ToSHA256Hash(this string text)
        {
            using (var algorithm = new SHA256Managed())
            {
                return algorithm.GenerateHashString(text);
            }
        }

        private static string GenerateHashString(this HashAlgorithm algorithm, string text)
        {
            algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
            var result = algorithm.Hash;
            return String.Join(String.Empty, result.Select(x => x.ToString("x2")));
        }
        
    }
}