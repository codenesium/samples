using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Contracts
{
        public abstract class AbstractApiBadgesModelMapper
        {
                public virtual ApiBadgesResponseModel MapRequestToResponse(
                        int id,
                        ApiBadgesRequestModel request)
                {
                        var response = new ApiBadgesResponseModel();
                        response.SetProperties(id,
                                               request.Date,
                                               request.Name,
                                               request.UserId);
                        return response;
                }

                public virtual ApiBadgesRequestModel MapResponseToRequest(
                        ApiBadgesResponseModel response)
                {
                        var request = new ApiBadgesRequestModel();
                        request.SetProperties(
                                response.Date,
                                response.Name,
                                response.UserId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>c0e30d3d010d90a1c43feec59d769ca5</Hash>
</Codenesium>*/