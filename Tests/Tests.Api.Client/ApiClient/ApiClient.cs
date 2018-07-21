using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;

namespace TestsNS.Api.Client
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
    <Hash>037e8443268505a86a4d5ff3bfa316d2</Hash>
</Codenesium>*/