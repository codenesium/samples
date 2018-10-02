using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public abstract class AbstractApiDirectTweetModelMapper
	{
		public virtual ApiDirectTweetResponseModel MapRequestToResponse(
			int tweetId,
			ApiDirectTweetRequestModel request)
		{
			var response = new ApiDirectTweetResponseModel();
			response.SetProperties(tweetId,
			                       request.Content,
			                       request.Date,
			                       request.TaggedUserId,
			                       request.Time);
			return response;
		}

		public virtual ApiDirectTweetRequestModel MapResponseToRequest(
			ApiDirectTweetResponseModel response)
		{
			var request = new ApiDirectTweetRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.TaggedUserId,
				response.Time);
			return request;
		}

		public JsonPatchDocument<ApiDirectTweetRequestModel> CreatePatch(ApiDirectTweetRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDirectTweetRequestModel>();
			patch.Replace(x => x.Content, model.Content);
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.TaggedUserId, model.TaggedUserId);
			patch.Replace(x => x.Time, model.Time);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>a9946544188512326176ffc15c975d88</Hash>
</Codenesium>*/