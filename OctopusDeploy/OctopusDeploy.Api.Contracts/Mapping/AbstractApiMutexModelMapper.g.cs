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
    <Hash>88d15d2b6d6ae7859c36d4abdee8a879</Hash>
</Codenesium>*/