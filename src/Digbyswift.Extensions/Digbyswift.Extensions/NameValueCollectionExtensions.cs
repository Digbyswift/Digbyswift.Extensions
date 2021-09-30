using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Digbyswift.Core.Constants;

namespace Digbyswift.Extensions
{
	public static class NameValueCollectionExtensions
	{
		public static IDictionary<string, string> ToDictionary(this NameValueCollection nvc)
		{
			if (nvc == null)
				throw new ArgumentNullException(nameof(nvc));

			return nvc.Count > 0
				? nvc.AllKeys.Where(k => k != null).ToDictionary(k => k, k => nvc[k])
				: new Dictionary<string, string>();
		}

		public static void CopyTo(this NameValueCollection nvc, IDictionary<string, string> dict)
		{
			if (nvc == null)
				throw new ArgumentNullException(nameof(nvc));

			if (nvc.Count == 0)
				return;

			foreach (var k in nvc.AllKeys)
			{
				dict.Add(k, nvc[k]);
			}
		}

		public static string ToQueryString(this NameValueCollection nvc)
		{
			if (nvc == null)
				throw new ArgumentNullException(nameof(nvc));

			return nvc.Count > 0
				? String.Join(StringConstants.Ampersand, nvc.AllKeys.Select(x => $"{x}={nvc[x]}"))
				: null;
		}

	}
}