using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiActionTemplateVersionModelMapper
	{
		public virtual ApiActionTemplateVersionResponseModel MapRequestToResponse(
			string id,
			ApiActionTemplateVersionRequestModel request)
		{
			var response = new ApiActionTemplateVersionResponseModel();
			response.SetProperties(id,
			                       request.ActionType,
			                       request.JSON,
			                       request.LatestActionTemplateId,
			                       request.Name,
			                       request.Version);
			return response;
		}

		public virtual ApiActionTemplateVersionRequestModel MapResponseToRequest(
			ApiActionTemplateVersionResponseModel response)
		{
			var request = new ApiActionTemplateVersionRequestModel();
			request.SetProperties(
				response.ActionType,
				response.JSON,
				response.LatestActionTemplateId,
				response.Name,
				response.Version);
			return request;
		}

		public JsonPatchDocument<ApiActionTemplateVersionRequestModel> CreatePatch(ApiActionTemplateVersionRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiActionTemplateVersionRequestModel>();
			patch.Replace(x => x.ActionType, model.ActionType);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.LatestActionTemplateId, model.LatestActionTemplateId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.Version, model.Version);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>40d036ba42e51355ee517e3e84d36072</Hash>
</Codenesium>*/