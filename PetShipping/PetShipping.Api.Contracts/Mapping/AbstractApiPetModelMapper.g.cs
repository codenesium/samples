using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiPetModelMapper
        {
                public virtual ApiPetResponseModel MapRequestToResponse(
                        int id,
                        ApiPetRequestModel request)
                {
                        var response = new ApiPetResponseModel();
                        response.SetProperties(id,
                                               request.BreedId,
                                               request.ClientId,
                                               request.Name,
                                               request.Weight);
                        return response;
                }

                public virtual ApiPetRequestModel MapResponseToRequest(
                        ApiPetResponseModel response)
                {
                        var request = new ApiPetRequestModel();
                        request.SetProperties(
                                response.BreedId,
                                response.ClientId,
                                response.Name,
                                response.Weight);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>cd4b23f09216bd64a905056347d9f833</Hash>
</Codenesium>*/