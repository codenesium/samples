using Microsoft.AspNetCore.JsonPatch;
using StackOverflowNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
{
	public abstract class AbstractApiCommentServerModelMapper
	{
		public virtual ApiCommentServerResponseModel MapServerRequestToResponse(
			int id,
			ApiCommentServerRequestModel request)
		{
			var response = new ApiCommentServerResponseModel();
			response.SetProperties(id,
			                       request.CreationDate,
			                       request.PostId,
			                       request.Score,
			                       request.Text,
			                       request.UserId);
			return response;
		}

		public virtual ApiCommentServerRequestModel MapServerResponseToRequest(
			ApiCommentServerResponseModel response)
		{
			var request = new ApiCommentServerRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.PostId,
				response.Score,
				response.Text,
				response.UserId);
			return request;
		}

		public virtual ApiCommentClientRequestModel MapServerResponseToClientRequest(
			ApiCommentServerResponseModel response)
		{
			var request = new ApiCommentClientRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.PostId,
				response.Score,
				response.Text,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiCommentServerRequestModel> CreatePatch(ApiCommentServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCommentServerRequestModel>();
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
    <Hash>c39ed64509af16965c184de413160480</Hash>
</Codenesium>*/