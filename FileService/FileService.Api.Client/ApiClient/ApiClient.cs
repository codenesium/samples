using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Client
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
    <Hash>dbefbba16b2135d3c2246d23d1c03d93</Hash>
</Codenesium>*/