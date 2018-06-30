using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiClientModelMapper
        {
                ApiClientResponseModel MapRequestToResponse(
                        int id,
                        ApiClientRequestModel request);

                ApiClientRequestModel MapResponseToRequest(
                        ApiClientResponseModel response);
        }
}

/*<Codenesium>
    <Hash>e4b8d58f580190f200447289fa9b8186</Hash>
</Codenesium>*/