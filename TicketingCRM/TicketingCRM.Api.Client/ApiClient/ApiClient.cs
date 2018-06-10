using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
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
    <Hash>b249b01aefe5b7f9ff9b499c6bfdc3a7</Hash>
</Codenesium>*/