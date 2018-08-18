using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiServerTaskModelMapper
	{
		public virtual ApiServerTaskResponseModel MapRequestToResponse(
			string id,
			ApiServerTaskRequestModel request)
		{
			var response = new ApiServerTaskResponseModel();
			response.SetProperties(id,
			                       request.CompletedTime,
			                       request.ConcurrencyTag,
			                       request.Description,
			                       request.DurationSeconds,
			                       request.EnvironmentId,
			                       request.ErrorMessage,
			                       request.HasPendingInterruptions,
			                       request.HasWarningsOrErrors,
			                       request.JSON,
			                       request.Name,
			                       request.ProjectId,
			                       request.QueueTime,
			                       request.ServerNodeId,
			                       request.StartTime,
			                       request.State,
			                       request.TenantId);
			return response;
		}

		public virtual ApiServerTaskRequestModel MapResponseToRequest(
			ApiServerTaskResponseModel response)
		{
			var request = new ApiServerTaskRequestModel();
			request.SetProperties(
				response.CompletedTime,
				response.ConcurrencyTag,
				response.Description,
				response.DurationSeconds,
				response.EnvironmentId,
				response.ErrorMessage,
				response.HasPendingInterruptions,
				response.HasWarningsOrErrors,
				response.JSON,
				response.Name,
				response.ProjectId,
				response.QueueTime,
				response.ServerNodeId,
				response.StartTime,
				response.State,
				response.TenantId);
			return request;
		}

		public JsonPatchDocument<ApiServerTaskRequestModel> CreatePatch(ApiServerTaskRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiServerTaskRequestModel>();
			patch.Replace(x => x.CompletedTime, model.CompletedTime);
			patch.Replace(x => x.ConcurrencyTag, model.ConcurrencyTag);
			patch.Replace(x => x.Description, model.Description);
			patch.Replace(x => x.DurationSeconds, model.DurationSeconds);
			patch.Replace(x => x.EnvironmentId, model.EnvironmentId);
			patch.Replace(x => x.ErrorMessage, model.ErrorMessage);
			patch.Replace(x => x.HasPendingInterruptions, model.HasPendingInterruptions);
			patch.Replace(x => x.HasWarningsOrErrors, model.HasWarningsOrErrors);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProjectId, model.ProjectId);
			patch.Replace(x => x.QueueTime, model.QueueTime);
			patch.Replace(x => x.ServerNodeId, model.ServerNodeId);
			patch.Replace(x => x.StartTime, model.StartTime);
			patch.Replace(x => x.State, model.State);
			patch.Replace(x => x.TenantId, model.TenantId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>29def47cac91e7d38169a22efc05e6d6</Hash>
</Codenesium>*/