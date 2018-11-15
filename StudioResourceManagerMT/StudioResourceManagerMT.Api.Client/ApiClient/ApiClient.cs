using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using StudioResourceManagerMTNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Client
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
    <Hash>80b2cdbe90f5ef33cbbd566be5415ace</Hash>
</Codenesium>*/