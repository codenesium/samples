using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDeploymentModelMapper
        {
                public virtual ApiDeploymentResponseModel MapRequestToResponse(
                        string id,
                        ApiDeploymentRequestModel request)
                {
                        var response = new ApiDeploymentResponseModel();
                        response.SetProperties(id,
                                               request.ChannelId,
                                               request.Created,
                                               request.DeployedBy,
                                               request.DeployedToMachineIds,
                                               request.EnvironmentId,
                                               request.JSON,
                                               request.Name,
                                               request.ProjectGroupId,
                                               request.ProjectId,
                                               request.ReleaseId,
                                               request.TaskId,
                                               request.TenantId);
                        return response;
                }

                public virtual ApiDeploymentRequestModel MapResponseToRequest(
                        ApiDeploymentResponseModel response)
                {
                        var request = new ApiDeploymentRequestModel();
                        request.SetProperties(
                                response.ChannelId,
                                response.Created,
                                response.DeployedBy,
                                response.DeployedToMachineIds,
                                response.EnvironmentId,
                                response.JSON,
                                response.Name,
                                response.ProjectGroupId,
                                response.ProjectId,
                                response.ReleaseId,
                                response.TaskId,
                                response.TenantId);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>4e7376d672a91aaec280893e083cbc2e</Hash>
</Codenesium>*/