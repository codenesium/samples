using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiProjectTriggerModelMapper
	{
		public virtual ApiProjectTriggerResponseModel MapRequestToResponse(
			string id,
			ApiProjectTriggerRequestModel request)
		{
			var response = new ApiProjectTriggerResponseModel();
			response.SetProperties(id,
			                       request.IsDisabled,
			                       request.JSON,
			                       request.Name,
			                       request.ProjectId,
			                       request.TriggerType);
			return response;
		}

		public virtual ApiProjectTriggerRequestModel MapResponseToRequest(
			ApiProjectTriggerResponseModel response)
		{
			var request = new ApiProjectTriggerRequestModel();
			request.SetProperties(
				response.IsDisabled,
				response.JSON,
				response.Name,
				response.ProjectId,
				response.TriggerType);
			return request;
		}

		public JsonPatchDocument<ApiProjectTriggerRequestModel> CreatePatch(ApiProjectTriggerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProjectTriggerRequestModel>();
			patch.Replace(x => x.IsDisabled, model.IsDisabled);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProjectId, model.ProjectId);
			patch.Replace(x => x.TriggerType, model.TriggerType);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>0625803d2bd2a7a27d551b0b78fd1e2d</Hash>
</Codenesium>*/