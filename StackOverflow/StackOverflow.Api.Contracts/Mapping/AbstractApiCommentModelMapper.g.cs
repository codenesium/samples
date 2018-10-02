using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public abstract class AbstractApiCommentModelMapper
	{
		public virtual ApiCommentResponseModel MapRequestToResponse(
			int id,
			ApiCommentRequestModel request)
		{
			var response = new ApiCommentResponseModel();
			response.SetProperties(id,
			                       request.CreationDate,
			                       request.PostId,
			                       request.Score,
			                       request.Text,
			                       request.UserId);
			return response;
		}

		public virtual ApiCommentRequestModel MapResponseToRequest(
			ApiCommentResponseModel response)
		{
			var request = new ApiCommentRequestModel();
			request.SetProperties(
				response.CreationDate,
				response.PostId,
				response.Score,
				response.Text,
				response.UserId);
			return request;
		}

		public JsonPatchDocument<ApiCommentRequestModel> CreatePatch(ApiCommentRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiCommentRequestModel>();
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
    <Hash>969098b5b77ec427805281a06cf3888b</Hash>
</Codenesium>*/