using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiMutexModelMapper
	{
		public virtual ApiMutexResponseModel MapRequestToResponse(
			string id,
			ApiMutexRequestModel request)
		{
			var response = new ApiMutexResponseModel();
			response.SetProperties(id,
			                       request.JSON);
			return response;
		}

		public virtual ApiMutexRequestModel MapResponseToRequest(
			ApiMutexResponseModel response)
		{
			var request = new ApiMutexRequestModel();
			request.SetProperties(
				response.JSON);
			return request;
		}

		public JsonPatchDocument<ApiMutexRequestModel> CreatePatch(ApiMutexRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiMutexRequestModel>();
			patch.Replace(x => x.JSON, model.JSON);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ccd6f4f7daae264d2a6b44f0a4466945</Hash>
</Codenesium>*/