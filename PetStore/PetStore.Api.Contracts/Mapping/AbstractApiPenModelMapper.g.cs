using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Contracts
{
        public abstract class AbstractApiPenModelMapper
        {
                public virtual ApiPenResponseModel MapRequestToResponse(
                        int id,
                        ApiPenRequestModel request)
                {
                        var response = new ApiPenResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiPenRequestModel MapResponseToRequest(
                        ApiPenResponseModel response)
                {
                        var request = new ApiPenRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>492f8105e08591dcff5ccbcce51bbf97</Hash>
</Codenesium>*/