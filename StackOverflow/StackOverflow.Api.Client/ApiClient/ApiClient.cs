using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using StackOverflowNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiClient : AbstractApiClient
	{
		public ApiClient(string apiUrl)
			: base(apiUrl, "1.0")
		{
		}

		public ApiClient(HttpClient client)
			: base(client)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5178e592eccf73924187dc8b206477b1</Hash>
</Codenesium>*/