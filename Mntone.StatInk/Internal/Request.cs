using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mntone.StatInk.Internal
{
	internal static class Request
	{
		public static string BulidUri(string uri, IEnumerable<KeyValuePair<string, object>> parameters)
		{
			var result = new StringBuilder(uri);
			if (parameters.Count() != 0)
			{
				{
					var p = parameters.First();
					result.AppendFormat("?{0}={1}", p.Key, Uri.EscapeDataString(p.Value.ToString()));
				}
				foreach (var p in parameters.Skip(1))
				{
					result.AppendFormat("&{0}={1}", p.Key, Uri.EscapeDataString(p.Value.ToString()));
				}
			}
			return result.ToString();
		}

		public static Task<string> GetStringAsync(this StatInkClient context, string baseUri, IEnumerable<KeyValuePair<string, object>> parameters, CancellationToken cancellationToken)
		{
			var requestUri = BulidUri(baseUri, parameters);
#if WINDOWS_UWP
			return context._client.GetStringAsync(new Uri(requestUri)).AsTask(cancellationToken);
#else
			return context._client.GetStringAsync(requestUri, cancellationToken);
#endif
		}

		public static Task<T> GetJsonAsync<T>(this StatInkClient context, string baseUri, IEnumerable<KeyValuePair<string, object>> parameters, CancellationToken cancellationToken)
		{
			return context.GetStringAsync(baseUri, parameters, cancellationToken).ContinueWith(
				prevTask => JsonSerializerExtensions.Load<T>(prevTask.Result),
				TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);
		}
	}
}