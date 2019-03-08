using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiVoteTypesServerModelMapper
	{
		public virtual ApiVoteTypesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVoteTypesServerRequestModel request)
		{
			var response = new ApiVoteTypesServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVoteTypesServerRequestModel MapServerResponseToRequest(
			ApiVoteTypesServerResponseModel response)
		{
			var request = new ApiVoteTypesServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiVoteTypesClientRequestModel MapServerResponseToClientRequest(
			ApiVoteTypesServerResponseModel response)
		{
			var request = new ApiVoteTypesClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiVoteTypesServerRequestModel> CreatePatch(ApiVoteTypesServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVoteTypesServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>3e5cc819b1ccca278f4fd037b8ad5809</Hash>
</Codenesium>*/