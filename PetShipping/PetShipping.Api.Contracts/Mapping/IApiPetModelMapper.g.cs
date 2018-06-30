using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public interface IApiPetModelMapper
        {
                ApiPetResponseModel MapRequestToResponse(
                        int id,
                        ApiPetRequestModel request);

                ApiPetRequestModel MapResponseToRequest(
                        ApiPetResponseModel response);
        }
}

/*<Codenesium>
    <Hash>c37c91a21e4a2b0f2e0d3e61bc550bd2</Hash>
</Codenesium>*/