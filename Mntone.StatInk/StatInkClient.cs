using Mntone.StatInk.Entities;
using Mntone.StatInk.Internal;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

#if WINDOWS_APP
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;
#else
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
#endif

namespace Mntone.StatInk
{
	public sealed class StatInkClient : IDisposable
	{
		private bool _disposed = false;

#if WINDOWS_APP
		internal HttpClient _client = null;
#else
		internal HttpClient _client = null;
#endif

		public string AdditionalUserAgent
		{
			get { return this._AdditionalUserAgent; }
			set
			{
				if (this._AdditionalUserAgent == value) return;

				this._AdditionalUserAgent = value;
				this.InitializeUserAgent();
			}
		}
		private string _AdditionalUserAgent = null;

		public StatInkClient()
		{
#if WINDOWS_APP
			var filter = new HttpBaseProtocolFilter()
			{
				AllowAutoRedirect = false,
				AllowUI = false,
				AutomaticDecompression = true,
			};

			this._client = new HttpClient(filter);
			this._client.DefaultRequestHeaders.AcceptEncoding.Add(new HttpContentCodingWithQualityHeaderValue("gzip"));
			this._client.DefaultRequestHeaders.AcceptEncoding.Add(new HttpContentCodingWithQualityHeaderValue("deflate"));
#else
			var handler = new HttpClientHandler()
			{
				AllowAutoRedirect = false,
				AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
			};
			this._client = new HttpClient(handler);
#endif

			this.InitializeUserAgent();
		}

		private void InitializeUserAgent()
		{
			this._client.DefaultRequestHeaders.UserAgent.Clear();
#if WINDOWS_APP
			this._client.DefaultRequestHeaders.UserAgent.Add(new HttpProductInfoHeaderValue(AssemblyInfo.QualifiedName, AssemblyInfo.Version));
			if (!string.IsNullOrEmpty(this.AdditionalUserAgent)) this._client.DefaultRequestHeaders.UserAgent.Add(new HttpProductInfoHeaderValue(this.AdditionalUserAgent));
#else
			this._client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(AssemblyInfo.QualifiedName, AssemblyInfo.Version));
			if (!string.IsNullOrEmpty(this.AdditionalUserAgent)) this._client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(this.AdditionalUserAgent));
#endif
		}

		private void AccessCheck()
		{
			if (this._disposed) throw new StatInkClientException(Messages.DISPOSED_OBJECT);
		}

		public void Dispose() => this.Dispose(true);
		private void Dispose(bool disposing)
		{
			if (this._disposed) return;
			if (disposing) this._client.Dispose();
			this._disposed = true;
		}

		public Task<Battle> GetBattleAsync(ulong id) => this.GetBattleAsync(id, CancellationToken.None);
		public Task<Battle> GetBattleAsync(ulong id, CancellationToken cancellationToken)
		{
			this.AccessCheck();
			return this.GetJsonAsync<Battle[]>(Urls.BATTLE_URI_TEXT, new Dictionary<string, object>() { ["id"] = id }, cancellationToken)
				.ContinueWith(prevTask => prevTask.Result[0], TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion);
		}

		public Task<Battle[]> GetBattlesAsync(string screenName, ulong newerThan = 0, ulong olderThan = ulong.MaxValue, ulong count = 10)
			=> this.GetBattlesAsync(screenName, newerThan, olderThan, count, CancellationToken.None);
		private Task<Battle[]> GetBattlesAsync(string screenName, ulong newerThan, ulong olderThan, ulong count, CancellationToken cancellationToken)
		{
			this.AccessCheck();
			if (count < 0 || count > 100)
			{
				throw new ArgumentOutOfRangeException(nameof(count));
			}

			var parameters = new Dictionary<string, object>() { ["screen_name"] = screenName };
			if (newerThan != 0) parameters.Add("newer_than", newerThan);
			if (olderThan != ulong.MaxValue) parameters.Add("older_than", olderThan);
			if (count != 10) parameters.Add("count", count);
			return this.GetJsonAsync<Battle[]>(Urls.BATTLE_URI_TEXT, parameters, cancellationToken);
		}
	}
}