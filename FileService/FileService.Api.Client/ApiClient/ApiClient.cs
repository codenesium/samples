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
                public ApiClient(string apiUrl) : base(apiUrl, "1.0")
                {
                }

                public ApiClient(HttpClient client) : base(client)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d39d6bc3263b9c74e0e4a4c7159c9769</Hash>
</Codenesium>*/