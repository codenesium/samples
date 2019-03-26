using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiVoteTypeServerModelMapper
	{
		public virtual ApiVoteTypeServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVoteTypeServerRequestModel request)
		{
			var response = new ApiVoteTypeServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVoteTypeServerRequestModel MapServerResponseToRequest(
			ApiVoteTypeServerResponseModel response)
		{
			var request = new ApiVoteTypeServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiVoteTypeClientRequestModel MapServerResponseToClientRequest(
			ApiVoteTypeServerResponseModel response)
		{
			var request = new ApiVoteTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiVoteTypeServerRequestModel> CreatePatch(ApiVoteTypeServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVoteTypeServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>eb64b8c5abaca7300ac339f680f826fd</Hash>
</Codenesium>*/