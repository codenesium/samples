using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public abstract class AbstractApiRetweetModelMapper
	{
		public virtual ApiRetweetResponseModel MapRequestToResponse(
			int id,
			ApiRetweetRequestModel request)
		{
			var response = new ApiRetweetResponseModel();
			response.SetProperties(id,
			                       request.Date,
			                       request.RetwitterUserId,
			                       request.Time,
			                       request.TweetTweetId);
			return response;
		}

		public virtual ApiRetweetRequestModel MapResponseToRequest(
			ApiRetweetResponseModel response)
		{
			var request = new ApiRetweetRequestModel();
			request.SetProperties(
				response.Date,
				response.RetwitterUserId,
				response.Time,
				response.TweetTweetId);
			return request;
		}

		public JsonPatchDocument<ApiRetweetRequestModel> CreatePatch(ApiRetweetRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiRetweetRequestModel>();
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.RetwitterUserId, model.RetwitterUserId);
			patch.Replace(x => x.Time, model.Time);
			patch.Replace(x => x.TweetTweetId, model.TweetTweetId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b5d37d47519139b8c887508c3233c46a</Hash>
</Codenesium>*/