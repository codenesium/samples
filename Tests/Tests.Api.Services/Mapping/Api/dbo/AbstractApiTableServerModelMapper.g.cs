using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestsNS.Api.Client;

namespace TestsNS.Api.Services
{
	public abstract class AbstractApiTableServerModelMapper
	{
		public virtual ApiTableServerResponseModel MapServerRequestToResponse(
			int id,
			ApiTableServerRequestModel request)
		{
			var response = new ApiTableServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiTableServerRequestModel MapServerResponseToRequest(
			ApiTableServerResponseModel response)
		{
			var request = new ApiTableServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiTableClientRequestModel MapServerResponseToClientRequest(
			ApiTableServerResponseModel response)
		{
			var request = new ApiTableClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiTableServerRequestModel> CreatePatch(ApiTableServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTableServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>efb4797523e72e9102d40c26e894c248</Hash>
</Codenesium>*/