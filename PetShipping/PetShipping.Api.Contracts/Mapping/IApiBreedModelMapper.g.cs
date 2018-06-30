using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiBreedModelMapper
        {
                ApiBreedResponseModel MapRequestToResponse(
                        int id,
                        ApiBreedRequestModel request);

                ApiBreedRequestModel MapResponseToRequest(
                        ApiBreedResponseModel response);
        }
}

/*<Codenesium>
    <Hash>3c8096c08e879934c4b58abea0a061d0</Hash>
</Codenesium>*/