using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiApiKeyModelMapper
	{
		public virtual ApiApiKeyResponseModel MapRequestToResponse(
			string id,
			ApiApiKeyRequestModel request)
		{
			var response = new ApiApiKeyResponseModel();
			response.SetProperties(id,
			                       request.ApiKeyHashed,
			                       request.Created,
			                       request.JSON,
			                       request.UserId);
			return response;
		}

		public virtual ApiApiKeyRequestModel MapResponseToRequest(
			ApiApiKeyResponseModel response)
		{
			var request = new ApiApiKeyRequestModel();
			request.SetProperties(
				response.ApiKeyHashed,
				response.Created,
				response.JSON,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiApiKeyRequestModel> CreatePatch(ApiApiKeyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiApiKeyRequestModel>();
			patch.Replace(x => x.ApiKeyHashed, model.ApiKeyHashed);
			patch.Replace(x => x.Created, model.Created);
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.UserId, model.UserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>0e5e0e43b78acecf50c83e6ef77b259c</Hash>
</Codenesium>*/