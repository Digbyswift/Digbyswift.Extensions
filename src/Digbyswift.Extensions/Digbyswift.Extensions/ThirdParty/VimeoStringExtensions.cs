using System;
using System.Text.RegularExpressions;

namespace Digbyswift.Extensions.ThirdParty
{
    public static class VimeoStringExtensions
    {
        private static readonly Regex VimeoUrlRegex =
            new Regex(@"vimeo\.com/(?:.*#|.*(videos|event)/)?([0-9]+)", RegexOptions.IgnoreCase);

        public static bool IsVimeoUrl(this string videoUrl)
        {
            if (String.IsNullOrWhiteSpace(videoUrl))
                return false;

            return VimeoUrlRegex.IsMatch(videoUrl);
        }

        public static bool IsVimeoEventUrl(this string videoUrl)
        {
            if (String.IsNullOrWhiteSpace(videoUrl))
                return false;

            var matches = VimeoUrlRegex.Matches(videoUrl);
            if (matches.Count == 0 || matches[0].Groups.Count != 3)
                return false;

            return matches[0].Groups[1].Value.Equals("event", StringComparison.OrdinalIgnoreCase);
        }

        public static string ExtractVimeoVideoId(this string videoUrl)
        {
            if (String.IsNullOrWhiteSpace(videoUrl))
                return String.Empty;

            var matches = VimeoUrlRegex.Matches(videoUrl);
            if (matches.Count == 0 || matches[0].Groups.Count != 3)
                return string.Empty;

            return matches[0].Groups[2].Value;
        }

        /// <summary>
        /// If the given URL is a valid Vimeo video URL it is parsed to a Vimeo embed URL. Otherwise it is returned as-is.
        /// </summary>
        public static string ToVimeoEmbedUrl(this string videoUrl)
        {
            if (!videoUrl.IsVimeoUrl())
                return videoUrl;

            var videoId = videoUrl.ExtractVimeoVideoId();
            var query = new Uri(videoUrl).Query;
            var workingUrl = videoUrl.IsVimeoEventUrl()
                ? $"https://vimeo.com/event/{videoId}/embed/"
                : $"https://player.vimeo.com/video/{videoId}/";

            return !String.IsNullOrWhiteSpace(query)
                ? $"{workingUrl}?{query}"
                : workingUrl;
        }
    }
}