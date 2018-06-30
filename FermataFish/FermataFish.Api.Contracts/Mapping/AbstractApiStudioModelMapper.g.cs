using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Contracts
{
        public abstract class AbstractApiStudioModelMapper
        {
                public virtual ApiStudioResponseModel MapRequestToResponse(
                        int id,
                        ApiStudioRequestModel request)
                {
                        var response = new ApiStudioResponseModel();
                        response.SetProperties(id,
                                               request.Address1,
                                               request.Address2,
                                               request.City,
                                               request.Name,
                                               request.StateId,
                                               request.Website,
                                               request.Zip);
                        return response;
                }

                public virtual ApiStudioRequestModel MapResponseToRequest(
                        ApiStudioResponseModel response)
                {
                        var request = new ApiStudioRequestModel();
                        request.SetProperties(
                                response.Address1,
                                response.Address2,
                                response.City,
                                response.Name,
                                response.StateId,
                                response.Website,
                                response.Zip);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>b36b165944cb33ffa6110d0b0037deaf</Hash>
</Codenesium>*/