using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiSpaceModelMapper
        {
                public virtual ApiSpaceResponseModel MapRequestToResponse(
                        int id,
                        ApiSpaceRequestModel request)
                {
                        var response = new ApiSpaceResponseModel();
                        response.SetProperties(id,
                                               request.Description,
                                               request.Name,
                                               request.StudioId);
                        return response;
                }

                public virtual ApiSpaceRequestModel MapResponseToRequest(
                        ApiSpaceResponseModel response)
                {
                        var request = new ApiSpaceRequestModel();
                        request.SetProperties(
                                response.Description,
                                response.Name,
                                response.StudioId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>c554f95a11e5b407b8f21bf937f9075d</Hash>
</Codenesium>*/