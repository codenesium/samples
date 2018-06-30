using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiStateModelMapper
        {
                public virtual ApiStateResponseModel MapRequestToResponse(
                        int id,
                        ApiStateRequestModel request)
                {
                        var response = new ApiStateResponseModel();
                        response.SetProperties(id,
                                               request.Name);
                        return response;
                }

                public virtual ApiStateRequestModel MapResponseToRequest(
                        ApiStateResponseModel response)
                {
                        var request = new ApiStateRequestModel();
                        request.SetProperties(
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>d112a3e17fe93e2df537de4816e35335</Hash>
</Codenesium>*/