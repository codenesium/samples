using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiCommentsServerModelMapper
	{
		public virtual ApiCommentsServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCommentsServerRequestModel request)
		{
			var response = new ApiCommentsServerResponseModel();
			response.SetProperties(id,
			                       request.CreationDate,
			                       request.PostId,
			                       request.Score,
			                       request.Text,
			                       request.UserId);
			return response;
		}

		public virtual ApiCommentsServerRequestModel MapServerResponseToRequest(
			ApiCommentsServerResponseModel response)
		{
			var request = new ApiCommentsServerRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.PostId,
				response.Score,
				response.Text,
				response.UserId);
			return request;
		}

		public virtual ApiCommentsClientRequestModel MapServerResponseToClientRequest(
			ApiCommentsServerResponseModel response)
		{
			var request = new ApiCommentsClientRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.PostId,
				response.Score,
				response.Text,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiCommentsServerRequestModel> CreatePatch(ApiCommentsServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCommentsServerRequestModel>();
			patch.Replace(x => x.CreationDate, model.CreationDate);
			patch.Replace(x => x.PostId, model.PostId);
			patch.Replace(x => x.Score, model.Score);
			patch.Replace(x => x.Text, model.Text);
			patch.Replace(x => x.UserId, model.UserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>03505797af708dd8df8c2d8c5cf1053a</Hash>
</Codenesium>*/