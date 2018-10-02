using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public abstract class AbstractApiLikeModelMapper
	{
		public virtual ApiLikeResponseModel MapRequestToResponse(
			int likeId,
			ApiLikeRequestModel request)
		{
			var response = new ApiLikeResponseModel();
			response.SetProperties(likeId,
			                       request.LikerUserId,
			                       request.TweetId);
			return response;
		}

		public virtual ApiLikeRequestModel MapResponseToRequest(
			ApiLikeResponseModel response)
		{
			var request = new ApiLikeRequestModel();
			request.SetProperties(
				response.LikerUserId,
				response.TweetId);
			return request;
		}

		public JsonPatchDocument<ApiLikeRequestModel> CreatePatch(ApiLikeRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiLikeRequestModel>();
			patch.Replace(x => x.LikerUserId, model.LikerUserId);
			patch.Replace(x => x.TweetId, model.TweetId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7b1bc087b7ff9a4ce3dfb5c45d15bd24</Hash>
</Codenesium>*/