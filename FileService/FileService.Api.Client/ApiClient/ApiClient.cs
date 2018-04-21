using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
namespace FileServiceNS.Api.Client
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
    <Hash>27106d58752ba84208ad2f658e280177</Hash>
</Codenesium>*/