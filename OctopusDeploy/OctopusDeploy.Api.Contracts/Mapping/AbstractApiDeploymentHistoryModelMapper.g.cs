using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

		public JsonPatchDocument<ApiDeploymentHistoryRequestModel> CreatePatch(ApiDeploymentHistoryRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDeploymentHistoryRequestModel>();
			patch.Replace(x => x.ChannelId, model.ChannelId);
			patch.Replace(x => x.ChannelName, model.ChannelName);
			patch.Replace(x => x.CompletedTime, model.CompletedTime);
			patch.Replace(x => x.Created, model.Created);
			patch.Replace(x => x.DeployedBy, model.DeployedBy);
			patch.Replace(x => x.DeploymentName, model.DeploymentName);
			patch.Replace(x => x.DurationSeconds, model.DurationSeconds);
			patch.Replace(x => x.EnvironmentId, model.EnvironmentId);
			patch.Replace(x => x.EnvironmentName, model.EnvironmentName);
			patch.Replace(x => x.ProjectId, model.ProjectId);
			patch.Replace(x => x.ProjectName, model.ProjectName);
			patch.Replace(x => x.ProjectSlug, model.ProjectSlug);
			patch.Replace(x => x.QueueTime, model.QueueTime);
			patch.Replace(x => x.ReleaseId, model.ReleaseId);
			patch.Replace(x => x.ReleaseVersion, model.ReleaseVersion);
			patch.Replace(x => x.StartTime, model.StartTime);
			patch.Replace(x => x.TaskId, model.TaskId);
			patch.Replace(x => x.TaskState, model.TaskState);
			patch.Replace(x => x.TenantId, model.TenantId);
			patch.Replace(x => x.TenantName, model.TenantName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>50f9892ce430a9ad3ed727a7eb06eb81</Hash>
</Codenesium>*/