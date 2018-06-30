using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiTenantModelMapper
        {
                public virtual ApiTenantResponseModel MapRequestToResponse(
                        string id,
                        ApiTenantRequestModel request)
                {
                        var response = new ApiTenantResponseModel();
                        response.SetProperties(id,
                                               request.DataVersion,
                                               request.JSON,
                                               request.Name,
                                               request.ProjectIds,
                                               request.TenantTags);
                        return response;
                }

                public virtual ApiTenantRequestModel MapResponseToRequest(
                        ApiTenantResponseModel response)
                {
                        var request = new ApiTenantRequestModel();
                        request.SetProperties(
                                response.DataVersion,
                                response.JSON,
                                response.Name,
                                response.ProjectIds,
                                response.TenantTags);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>cb426826add9767b8f76f79fa73fc68a</Hash>
</Codenesium>*/