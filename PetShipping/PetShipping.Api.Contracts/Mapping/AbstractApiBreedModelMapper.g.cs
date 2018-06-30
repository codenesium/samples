using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiBreedModelMapper
        {
                public virtual ApiBreedResponseModel MapRequestToResponse(
                        int id,
                        ApiBreedRequestModel request)
                {
                        var response = new ApiBreedResponseModel();
                        response.SetProperties(id,
                                               request.Name,
                                               request.SpeciesId);
                        return response;
                }

                public virtual ApiBreedRequestModel MapResponseToRequest(
                        ApiBreedResponseModel response)
                {
                        var request = new ApiBreedRequestModel();
                        request.SetProperties(
                                response.Name,
                                response.SpeciesId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>84824bf47af9c6e0c6216bf33b30c8b4</Hash>
</Codenesium>*/