using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Contracts
{
        public abstract class AbstractApiDeploymentHistoryModelMapper
        {
                public virtual ApiDeploymentHistoryResponseModel MapRequestToResponse(
                        string deploymentId,
                        ApiDeploymentHistoryRequestModel request)
                {
                        var response = new ApiDeploymentHistoryResponseModel();
                        response.SetProperties(deploymentId,
                                               request.ChannelId,
                                               request.ChannelName,
                                               request.CompletedTime,
                                               request.Created,
                                               request.DeployedBy,
                                               request.DeploymentName,
                                               request.DurationSeconds,
                                               request.EnvironmentId,
                                               request.EnvironmentName,
                                               request.ProjectId,
                                               request.ProjectName,
                                               request.ProjectSlug,
                                               request.QueueTime,
                                               request.ReleaseId,
                                               request.ReleaseVersion,
                                               request.StartTime,
                                               request.TaskId,
                                               request.TaskState,
                                               request.TenantId,
                                               request.TenantName);
                        return response;
                }

                public virtual ApiDeploymentHistoryRequestModel MapResponseToRequest(
                        ApiDeploymentHistoryResponseModel response)
                {
                        var request = new ApiDeploymentHistoryRequestModel();
                        request.SetProperties(
                                response.ChannelId,
                                response.ChannelName,
                                response.CompletedTime,
                                response.Created,
                                response.DeployedBy,
                                response.DeploymentName,
                                response.DurationSeconds,
                                response.EnvironmentId,
                                response.EnvironmentName,
                                response.ProjectId,
                                response.ProjectName,
                                response.ProjectSlug,
                                response.QueueTime,
                                response.ReleaseId,
                                response.ReleaseVersion,
                                response.StartTime,
                                response.TaskId,
                                response.TaskState,
                                response.TenantId,
                                response.TenantName);
                        return request;
                }
        }
}

/*<Codenesium>
    <Hash>60f2062b9d4288ccea1a379cc7535979</Hash>
</Codenesium>*/