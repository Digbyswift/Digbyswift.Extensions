using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Digbyswift.Extensions.ThirdParty
{
    public static class YouTubeStringExtensions
    {
        private static readonly Regex YouTubeUrl = new Regex(@".*(?:(?:youtu\.be\/|v\/|vi\/|u\/\w\/|embed\/)|(?:(?:watch)?\?v(?:i)?=|\&v(?:i)?=))([^#\&\?]*).*", RegexOptions.IgnoreCase);

        public static bool IsYouTubeUrl(this string fullYouTubeVideoUrl)
        {
            return YouTubeUrl.IsMatch(fullYouTubeVideoUrl);
        }

        public static string ExtractYouTubeVideoId(this string fullYouTubeVideoUrl)
        {
            var matches = YouTubeUrl.Matches(fullYouTubeVideoUrl);
            if (matches.Count == 0)
                return String.Empty;

            var match = matches[0];
            return match.Groups.Count > 0 ? match.Groups[1].Value : String.Empty;
        }

        public static string ToYouTubeThumbnailUrl(this string fullYouTubeVideoUrl)
        {
            var videoId = fullYouTubeVideoUrl.ExtractYouTubeVideoId();
            return $"https://i.ytimg.com/vi/{videoId}/0.jpg";
        }

        /// <summary>
        /// If the given URL is a valid YouTube video URL it is parsed to a YT embed URL. Otherwise it is returned as-is.
        /// </summary>
        /// <param name="fullYouTubeVideoUrl"></param>
        /// <returns></returns>
        public static string ToYouTubeEmbedUrl(this string fullYouTubeVideoUrl)
        {
            if (fullYouTubeVideoUrl.IsYouTubeUrl())
            {
                var videoId = fullYouTubeVideoUrl.ExtractYouTubeVideoId();
                var query = ParseYoutubeQueryString(fullYouTubeVideoUrl);
                query.Set("rel", "0");
                query.Set("modestbranding", "1");
                query.Set("controls", "0");
                return $"https://www.youtube-nocookie.com/embed/{videoId}/?{query}";
            }

            return fullYouTubeVideoUrl;
        }

        private static NameValueCollection ParseYoutubeQueryString(string fullYouTubeVideoUrl)
        {
            Uri.TryCreate(fullYouTubeVideoUrl, UriKind.RelativeOrAbsolute, out var youtubeUri);
            if (!youtubeUri.IsAbsoluteUri)
            {
                Uri.TryCreate($"https://{fullYouTubeVideoUrl}", UriKind.RelativeOrAbsolute, out youtubeUri);
            }

            var nvc = new NameValueCollection();

            if (String.IsNullOrWhiteSpace(youtubeUri.Query))
                return nvc;
            
            foreach (var item in youtubeUri.Query.Replace("?", "").SplitAndTrim('&'))
            {
                var itemParts = item.SplitAndTrim('=');
                if (itemParts.Count != 2)
                    continue;
                
                nvc.Add(itemParts[0], itemParts[1]);
            }
            
            return nvc;
        }
    }
}
