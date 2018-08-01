using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Contracts
{
	public abstract class AbstractApiProxyModelMapper
	{
		public virtual ApiProxyResponseModel MapRequestToResponse(
			string id,
			ApiProxyRequestModel request)
		{
			var response = new ApiProxyResponseModel();
			response.SetProperties(id,
			                       request.JSON,
			                       request.Name);
			return response;
		}

		public virtual ApiProxyRequestModel MapResponseToRequest(
			ApiProxyResponseModel response)
		{
			var request = new ApiProxyRequestModel();
			request.SetProperties(
				response.JSON,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiProxyRequestModel> CreatePatch(ApiProxyRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiProxyRequestModel>();
			patch.Replace(x => x.JSON, model.JSON);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9b88b3f292f5c303d97c793d329d9070</Hash>
</Codenesium>*/