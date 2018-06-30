using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiDestinationModelMapper
        {
                ApiDestinationResponseModel MapRequestToResponse(
                        int id,
                        ApiDestinationRequestModel request);

                ApiDestinationRequestModel MapResponseToRequest(
                        ApiDestinationResponseModel response);
        }
}

/*<Codenesium>
    <Hash>1be87de2eb27c419866dab8da7a79802</Hash>
</Codenesium>*/