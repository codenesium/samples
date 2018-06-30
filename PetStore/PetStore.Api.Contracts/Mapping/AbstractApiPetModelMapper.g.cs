using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
{
        public abstract class AbstractApiPetModelMapper
        {
                public virtual ApiPetResponseModel MapRequestToResponse(
                        int id,
                        ApiPetRequestModel request)
                {
                        var response = new ApiPetResponseModel();
                        response.SetProperties(id,
                                               request.AcquiredDate,
                                               request.BreedId,
                                               request.Description,
                                               request.PenId,
                                               request.Price,
                                               request.SpeciesId);
                        return response;
                }

                public virtual ApiPetRequestModel MapResponseToRequest(
                        ApiPetResponseModel response)
                {
                        var request = new ApiPetRequestModel();
                        request.SetProperties(
                                response.AcquiredDate,
                                response.BreedId,
                                response.Description,
                                response.PenId,
                                response.Price,
                                response.SpeciesId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>645c63efbc87bbc0f3b527632aa24a76</Hash>
</Codenesium>*/