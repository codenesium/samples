using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.Client
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
    <Hash>2de02d846c1d993826d3ffab1192bd76</Hash>
</Codenesium>*/