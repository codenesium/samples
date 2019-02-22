using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiCallStatuServerModelMapper
	{
		public virtual ApiCallStatuServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCallStatuServerRequestModel request)
		{
			var response = new ApiCallStatuServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiCallStatuServerRequestModel MapServerResponseToRequest(
			ApiCallStatuServerResponseModel response)
		{
			var request = new ApiCallStatuServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiCallStatuClientRequestModel MapServerResponseToClientRequest(
			ApiCallStatuServerResponseModel response)
		{
			var request = new ApiCallStatuClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiCallStatuServerRequestModel> CreatePatch(ApiCallStatuServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCallStatuServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ec271afd3002e9a362f79fb22bdf44b8</Hash>
</Codenesium>*/