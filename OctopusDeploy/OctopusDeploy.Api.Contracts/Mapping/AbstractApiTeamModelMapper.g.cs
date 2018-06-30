using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiTeamModelMapper
        {
                public virtual ApiTeamResponseModel MapRequestToResponse(
                        string id,
                        ApiTeamRequestModel request)
                {
                        var response = new ApiTeamResponseModel();
                        response.SetProperties(id,
                                               request.EnvironmentIds,
                                               request.JSON,
                                               request.MemberUserIds,
                                               request.Name,
                                               request.ProjectGroupIds,
                                               request.ProjectIds,
                                               request.TenantIds,
                                               request.TenantTags);
                        return response;
                }

                public virtual ApiTeamRequestModel MapResponseToRequest(
                        ApiTeamResponseModel response)
                {
                        var request = new ApiTeamRequestModel();
                        request.SetProperties(
                                response.EnvironmentIds,
                                response.JSON,
                                response.MemberUserIds,
                                response.Name,
                                response.ProjectGroupIds,
                                response.ProjectIds,
                                response.TenantIds,
                                response.TenantTags);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>e3f75454839d4dc87f27ad45356f7633</Hash>
</Codenesium>*/