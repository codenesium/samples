using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
{
        public abstract class AbstractApiSpeciesModelMapper
        {
                public virtual ApiSpeciesResponseModel MapRequestToResponse(
                        int id,
                        ApiSpeciesRequestModel request)
                {
                        var response = new ApiSpeciesResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiSpeciesRequestModel MapResponseToRequest(
                        ApiSpeciesResponseModel response)
                {
                        var request = new ApiSpeciesRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>ab7769b755b0c94537da0150fbcdf624</Hash>
</Codenesium>*/