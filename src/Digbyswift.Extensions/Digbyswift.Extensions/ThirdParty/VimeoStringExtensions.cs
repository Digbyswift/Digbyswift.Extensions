using System;
using System.Text.RegularExpressions;
using System.Web;

namespace Digbyswift.Extensions.ThirdParty
{
    public static class VimeoStringExtensions
    {
        private static readonly Regex VimeoUrlRegex = new Regex(@"vimeo\.com/(?:.*#|.*(videos|event)/)?([0-9]+)", RegexOptions.IgnoreCase);

        public static bool IsVimeoUrl(this string videoUrl)
        {
            return VimeoUrlRegex.IsMatch(videoUrl);
        }

        public static string ExtractVimeoVideoId(this string videoUrl)
        {
            var matches = VimeoUrlRegex.Matches(videoUrl);
            if (matches.Count == 0)
                return string.Empty;

            var match = matches[0];

            return match.Groups.Count > 0 ? match.Groups[1].Value : string.Empty;
        }

        /// <summary>
        /// If the given URL is a valid Vimeo video URL it is parsed to a Vimeo embed URL. Otherwise it is returned as-is.
        /// </summary>
        /// <param name="videoUrl"></param>
        /// <returns></returns>
        public static string ToVimeoEmbedUrl(this string videoUrl)
        {
            if (!videoUrl.IsVimeoUrl()) 
                return videoUrl;

            var videoId = videoUrl.ExtractVimeoVideoId();
            var query = new Uri(videoUrl).Query;

            return $"https://player.vimeo.com/video/{videoId}/?{query}";
        }
    }
}
