using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Contracts
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
    <Hash>fe27ca78b2b99c1fa82222e752f607c4</Hash>
</Codenesium>*/