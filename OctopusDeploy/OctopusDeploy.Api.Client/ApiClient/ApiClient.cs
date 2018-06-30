using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Client
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
    <Hash>2f3eb84420ae707a04ad969aeb4b9d7c</Hash>
</Codenesium>*/