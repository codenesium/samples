using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public class ApiVoteTypeServerModelMapper : IApiVoteTypeServerModelMapper
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
    <Hash>ad72cc1502fd68ba1b92d3d2ba3e6e4f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/