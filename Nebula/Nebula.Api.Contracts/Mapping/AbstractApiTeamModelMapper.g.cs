using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Contracts
{
        public abstract class AbstractApiTeamModelMapper
        {
                public virtual ApiTeamResponseModel MapRequestToResponse(
                        int id,
                        ApiTeamRequestModel request)
                {
                        var response = new ApiTeamResponseModel();
                        response.SetProperties(id,
                                               request.Name,
                                               request.OrganizationId);
                        return response;
                }

                public virtual ApiTeamRequestModel MapResponseToRequest(
                        ApiTeamResponseModel response)
                {
                        var request = new ApiTeamRequestModel();
                        request.SetProperties(
                                response.Name,
                                response.OrganizationId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>10202b6882832a1356059c77b09df8dd</Hash>
</Codenesium>*/