using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
namespace NebulaNS.Api.Client
{
	public abstract partial class AbstractApiClient
	{
		private HttpClient client;
		protected string ApiUrl { get; set; }
		public AbstractApiClient(string apiUri)
		{
			if (String.IsNullOrWhiteSpace(apiUri))
			{
				throw new ArgumentException("apiUrl is not set");
			}
			if (apiUri[apiUri.Length - 1] != '/')
			{
				throw new ArgumentException("The apiUrl must end in a / for httpClient to work correctly");
			}

			this.ApiUrl = apiUri;
			this.client = new HttpClient();

			this.client.BaseAddress = new Uri(apiUri);

			this.client.DefaultRequestHeaders.Accept.Clear();
			this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
	}
}

/*<Codenesium>
    <Hash>14bd98c299ca423c2a6ff3fe9f600284</Hash>
</Codenesium>*/