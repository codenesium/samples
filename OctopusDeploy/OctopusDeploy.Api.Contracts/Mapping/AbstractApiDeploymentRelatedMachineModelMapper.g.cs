using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDeploymentRelatedMachineModelMapper
        {
                public virtual ApiDeploymentRelatedMachineResponseModel MapRequestToResponse(
                        int id,
                        ApiDeploymentRelatedMachineRequestModel request)
                {
                        var response = new ApiDeploymentRelatedMachineResponseModel();
                        response.SetProperties(id,
                                               request.DeploymentId,
                                               request.MachineId);
                        return response;
                }

                public virtual ApiDeploymentRelatedMachineRequestModel MapResponseToRequest(
                        ApiDeploymentRelatedMachineResponseModel response)
                {
                        var request = new ApiDeploymentRelatedMachineRequestModel();
                        request.SetProperties(
                                response.DeploymentId,
                                response.MachineId);
                        return request;
                }

                public JsonPatchDocument<ApiDeploymentRelatedMachineRequestModel> CreatePatch(ApiDeploymentRelatedMachineRequestModel model)
                {
                        var patch = new JsonPatchDocument<ApiDeploymentRelatedMachineRequestModel>();
                        patch.Replace(x => x.DeploymentId, model.DeploymentId);
                        patch.Replace(x => x.MachineId, model.MachineId);
                        return patch;
                }
        }
}

/*<Codenesium>
    <Hash>48d30ffb2370cb56440eb87741f9f5f0</Hash>
</Codenesium>*/