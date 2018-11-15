using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiPersonServerModelMapper
	{
		public virtual ApiPersonServerResponseModel MapServerRequestToResponse(
			int personId,
			ApiPersonServerRequestModel request)
		{
			var response = new ApiPersonServerResponseModel();
			response.SetProperties(personId,
			                       request.PersonName);
			return response;
		}

		public virtual ApiPersonServerRequestModel MapServerResponseToRequest(
			ApiPersonServerResponseModel response)
		{
			var request = new ApiPersonServerRequestModel();
			request.SetProperties(
				response.PersonName);
			return request;
		}

		public virtual ApiPersonClientRequestModel MapServerResponseToClientRequest(
			ApiPersonServerResponseModel response)
		{
			var request = new ApiPersonClientRequestModel();
			request.SetProperties(
				response.PersonName);
			return request;
		}

		public JsonPatchDocument<ApiPersonServerRequestModel> CreatePatch(ApiPersonServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPersonServerRequestModel>();
			patch.Replace(x => x.PersonName, model.PersonName);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>de4dca9bb017bd8ef6c0fddd07a0c217</Hash>
</Codenesium>*/