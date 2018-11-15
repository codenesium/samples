using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiRetweetServerModelMapper
	{
		public virtual ApiRetweetServerResponseModel MapServerRequestToResponse(
			int id,
			ApiRetweetServerRequestModel request)
		{
			var response = new ApiRetweetServerResponseModel();
			response.SetProperties(id,
			                       request.Date,
			                       request.RetwitterUserId,
			                       request.Time,
			                       request.TweetTweetId);
			return response;
		}

		public virtual ApiRetweetServerRequestModel MapServerResponseToRequest(
			ApiRetweetServerResponseModel response)
		{
			var request = new ApiRetweetServerRequestModel();
			request.SetProperties(
				response.Date,
				response.RetwitterUserId,
				response.Time,
				response.TweetTweetId);
			return request;
		}

		public virtual ApiRetweetClientRequestModel MapServerResponseToClientRequest(
			ApiRetweetServerResponseModel response)
		{
			var request = new ApiRetweetClientRequestModel();
			request.SetProperties(
				response.Date,
				response.RetwitterUserId,
				response.Time,
				response.TweetTweetId);
			return request;
		}

		public JsonPatchDocument<ApiRetweetServerRequestModel> CreatePatch(ApiRetweetServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiRetweetServerRequestModel>();
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.RetwitterUserId, model.RetwitterUserId);
			patch.Replace(x => x.Time, model.Time);
			patch.Replace(x => x.TweetTweetId, model.TweetTweetId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>f128c955d119a158448dc185fd1f4a7e</Hash>
</Codenesium>*/