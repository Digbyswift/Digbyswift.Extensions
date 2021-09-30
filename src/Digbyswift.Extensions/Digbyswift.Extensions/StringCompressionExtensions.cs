using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Digbyswift.Extensions
{
    public static class StringCompressionExtensions
    {
        // /// <summary>
        // /// Compresses a string using Deflate compression
        // /// </summary>
        public static string Compress(this string uncompressedString)
        {
            byte[] compressedBytes;

            using (var uncompressedStream = new MemoryStream(Encoding.UTF8.GetBytes(uncompressedString)))
            using (var compressedStream = new MemoryStream())
            { 
                // setting the leaveOpen parameter to true to ensure that compressedStream will not be closed when compressorStream is disposed
                // this allows compressorStream to close and flush its buffers to compressedStream and guarantees that compressedStream.ToArray() can be called afterward
                // although MSDN documentation states that ToArray() can be called on a closed MemoryStream, I don't want to rely on that very odd behavior should it ever change
                using (var compressorStream = new GZipStream(compressedStream, CompressionLevel.Fastest, true))
                {
                    uncompressedStream.CopyTo(compressorStream);
                }

                compressedBytes = compressedStream.ToArray();
            }

            return Convert.ToBase64String(compressedBytes);
        }

        /// <summary>
        /// Decompresses a deflate compressed, Base64 encoded string and returns an uncompressed string.
        /// </summary>
        public static string Decompress(this string compressedString)
        {
            using (var compressedStream = new MemoryStream(Convert.FromBase64String(compressedString)))
            {
                byte[] decompressedBytes;

                using (var decompressorStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                using (var decompressedStream = new MemoryStream())
                {
                    decompressorStream.CopyTo(decompressedStream);
                    decompressedBytes = decompressedStream.ToArray();
                }

                return Encoding.UTF8.GetString(decompressedBytes);
            }
        }
    }
}

