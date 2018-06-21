using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>8228d962da5ebe466a7e3ff7faebf66f</Hash>
</Codenesium>*/