using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiLifecycleModelMapper
	{
		public virtual ApiLifecycleResponseModel MapRequestToResponse(
			string id,
			ApiLifecycleRequestModel request)
		{
			var response = new ApiLifecycleResponseModel();
			response.SetProperties(id,
			                       request.DataVersion,
			                       request.JSON,
			                       request.Name);
			return response;
		}

		public virtual ApiLifecycleRequestModel MapResponseToRequest(
			ApiLifecycleResponseModel response)
		{
			var request = new ApiLifecycleRequestModel();
			request.SetProperties(
				response.DataVersion,
				response.JSON,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiLifecycleRequestModel> CreatePatch(ApiLifecycleRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLifecycleRequestModel>();
			patch.Replace(x => x.DataVersion, model.DataVersion);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>de2d0c5dc41d5d1a0f69a2b5f4b866aa</Hash>
</Codenesium>*/