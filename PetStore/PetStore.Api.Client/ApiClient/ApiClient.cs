using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using PetStoreNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
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
    <Hash>0f5eebcb7008ff56afe1a44c60978263</Hash>
</Codenesium>*/