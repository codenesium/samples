using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

                public JsonPatchDocument<ApiUserRoleRequestModel> CreatePatch(ApiUserRoleRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiUserRoleRequestModel>();
                        patch.Replace(x => x.JSON, model.JSON);
                        patch.Replace(x => x.Name, model.Name);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>d05842e5b11af8a0f3d79817898b72a9</Hash>
</Codenesium>*/