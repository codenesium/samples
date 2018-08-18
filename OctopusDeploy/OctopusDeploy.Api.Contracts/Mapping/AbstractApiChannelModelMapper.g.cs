using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiChannelModelMapper
	{
		public virtual ApiChannelResponseModel MapRequestToResponse(
			string id,
			ApiChannelRequestModel request)
		{
			var response = new ApiChannelResponseModel();
			response.SetProperties(id,
			                       request.DataVersion,
			                       request.JSON,
			                       request.LifecycleId,
			                       request.Name,
			                       request.ProjectId,
			                       request.TenantTags);
			return response;
		}

		public virtual ApiChannelRequestModel MapResponseToRequest(
			ApiChannelResponseModel response)
		{
			var request = new ApiChannelRequestModel();
			request.SetProperties(
				response.DataVersion,
				response.JSON,
				response.LifecycleId,
				response.Name,
				response.ProjectId,
				response.TenantTags);
			return request;
		}

		public JsonPatchDocument<ApiChannelRequestModel> CreatePatch(ApiChannelRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiChannelRequestModel>();
			patch.Replace(x => x.DataVersion, model.DataVersion);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.LifecycleId, model.LifecycleId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.ProjectId, model.ProjectId);
			patch.Replace(x => x.TenantTags, model.TenantTags);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7e53e7d926a8bb16b2d41ed4aa442c92</Hash>
</Codenesium>*/