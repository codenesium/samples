using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

		public JsonPatchDocument<ApiDeploymentRequestModel> CreatePatch(ApiDeploymentRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDeploymentRequestModel>();
			patch.Replace(x => x.ChannelId, model.ChannelId);
			patch.Replace(x => x.Created, model.Created);
			patch.Replace(x => x.DeployedBy, model.DeployedBy);
			patch.Replace(x => x.DeployedToMachineIds, model.DeployedToMachineIds);
			patch.Replace(x => x.EnvironmentId, model.EnvironmentId);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProjectGroupId, model.ProjectGroupId);
			patch.Replace(x => x.ProjectId, model.ProjectId);
			patch.Replace(x => x.ReleaseId, model.ReleaseId);
			patch.Replace(x => x.TaskId, model.TaskId);
			patch.Replace(x => x.TenantId, model.TenantId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>69edf4e350742bdff5f190ff2f5056c0</Hash>
</Codenesium>*/