using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ESPIOTNS.Api.Contracts;
namespace ESPIOTNS.Api.Client
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
    <Hash>baa16a9182072cb41805ffe4e9c82d5e</Hash>
</Codenesium>*/