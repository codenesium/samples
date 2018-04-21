using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
namespace FermataFishNS.Api.Client
{
	public class ApiClient: AbstractApiClient
	{
		public ApiClient(string apiUrl) : base(apiUrl,"1.0")
		{}

		public ApiClient(HttpClient client) : base(client)
		{}
	}
}

/*<Codenesium>
    <Hash>cf46efdbded799aac8de1f21cdc95bc8</Hash>
</Codenesium>*/