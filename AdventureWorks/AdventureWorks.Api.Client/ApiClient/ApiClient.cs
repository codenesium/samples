using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.Client
{

    public class ApiClient : AbstractApiClient
    {
        public ApiClient(string apiUrl) 
			: base(apiUrl,"1.0")
        {

        }

        public ApiClient(HttpClient client) 
			: base(client)
        {

        }
    }
}

/*<Codenesium>
    <Hash>b30830231be7f656db36d04c342052fb</Hash>
</Codenesium>*/