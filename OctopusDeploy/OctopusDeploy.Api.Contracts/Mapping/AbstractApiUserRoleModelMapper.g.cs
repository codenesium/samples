using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiUserRoleModelMapper
        {
                public virtual ApiUserRoleResponseModel MapRequestToResponse(
                        string id,
                        ApiUserRoleRequestModel request)
                {
                        var response = new ApiUserRoleResponseModel();
                        response.SetProperties(id,
                                               request.JSON,
                                               request.Name);
                        return response;
                }

                public virtual ApiUserRoleRequestModel MapResponseToRequest(
                        ApiUserRoleResponseModel response)
                {
                        var request = new ApiUserRoleRequestModel();
                        request.SetProperties(
                                response.JSON,
                                response.Name);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>2d1625e60d881331b78c7f3259f1c3e5</Hash>
</Codenesium>*/