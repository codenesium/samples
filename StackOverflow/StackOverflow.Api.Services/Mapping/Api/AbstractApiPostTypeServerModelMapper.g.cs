using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiPostTypeServerModelMapper
	{
		public virtual ApiPostTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPostTypeServerRequestModel request)
		{
			var response = new ApiPostTypeServerResponseModel();
			response.SetProperties(id,
			                       request.Type);
			return response;
		}

		public virtual ApiPostTypeServerRequestModel MapServerResponseToRequest(
			ApiPostTypeServerResponseModel response)
		{
			var request = new ApiPostTypeServerRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}

		public virtual ApiPostTypeClientRequestModel MapServerResponseToClientRequest(
			ApiPostTypeServerResponseModel response)
		{
			var request = new ApiPostTypeClientRequestModel();
			request.SetProperties(
				response.Type);
			return request;
		}

		public JsonPatchDocument<ApiPostTypeServerRequestModel> CreatePatch(ApiPostTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiPostTypeServerRequestModel>();
			patch.Replace(x => x.Type, model.Type);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>88b9396148a3b86de9b3136269a9b22b</Hash>
</Codenesium>*/