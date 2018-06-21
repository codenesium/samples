using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using PetShippingNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
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
    <Hash>ef8c5132e191ce2e564422d82e4e7c0b</Hash>
</Codenesium>*/