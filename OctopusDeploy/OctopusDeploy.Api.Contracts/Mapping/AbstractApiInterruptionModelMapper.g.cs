using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiInterruptionModelMapper
	{
		public virtual ApiInterruptionResponseModel MapRequestToResponse(
			string id,
			ApiInterruptionRequestModel request)
		{
			var response = new ApiInterruptionResponseModel();
			response.SetProperties(id,
			                       request.Created,
			                       request.EnvironmentId,
			                       request.JSON,
			                       request.ProjectId,
			                       request.RelatedDocumentIds,
			                       request.ResponsibleTeamIds,
			                       request.Status,
			                       request.TaskId,
			                       request.TenantId,
			                       request.Title);
			return response;
		}

		public virtual ApiInterruptionRequestModel MapResponseToRequest(
			ApiInterruptionResponseModel response)
		{
			var request = new ApiInterruptionRequestModel();
			request.SetProperties(
				response.Created,
				response.EnvironmentId,
				response.JSON,
				response.ProjectId,
				response.RelatedDocumentIds,
				response.ResponsibleTeamIds,
				response.Status,
				response.TaskId,
				response.TenantId,
				response.Title);
			return request;
		}

		public JsonPatchDocument<ApiInterruptionRequestModel> CreatePatch(ApiInterruptionRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiInterruptionRequestModel>();
			patch.Replace(x => x.Created, model.Created);
			patch.Replace(x => x.EnvironmentId, model.EnvironmentId);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.ProjectId, model.ProjectId);
			patch.Replace(x => x.RelatedDocumentIds, model.RelatedDocumentIds);
			patch.Replace(x => x.ResponsibleTeamIds, model.ResponsibleTeamIds);
			patch.Replace(x => x.Status, model.Status);
			patch.Replace(x => x.TaskId, model.TaskId);
			patch.Replace(x => x.TenantId, model.TenantId);
			patch.Replace(x => x.Title, model.Title);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>542df43cae3e7f74b02f32d270bd914b</Hash>
</Codenesium>*/