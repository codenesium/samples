using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiTweetServerModelMapper
	{
		public virtual ApiTweetServerResponseModel MapServerRequestToResponse(
			int tweetId,
			ApiTweetServerRequestModel request)
		{
			var response = new ApiTweetServerResponseModel();
			response.SetProperties(tweetId,
			                       request.Content,
			                       request.Date,
			                       request.LocationId,
			                       request.Time,
			                       request.UserUserId);
			return response;
		}

		public virtual ApiTweetServerRequestModel MapServerResponseToRequest(
			ApiTweetServerResponseModel response)
		{
			var request = new ApiTweetServerRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.LocationId,
				response.Time,
				response.UserUserId);
			return request;
		}

		public virtual ApiTweetClientRequestModel MapServerResponseToClientRequest(
			ApiTweetServerResponseModel response)
		{
			var request = new ApiTweetClientRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.LocationId,
				response.Time,
				response.UserUserId);
			return request;
		}

		public JsonPatchDocument<ApiTweetServerRequestModel> CreatePatch(ApiTweetServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTweetServerRequestModel>();
			patch.Replace(x => x.Content, model.Content);
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.LocationId, model.LocationId);
			patch.Replace(x => x.Time, model.Time);
			patch.Replace(x => x.UserUserId, model.UserUserId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>ecec7450f67c1e91738d43a1cc614496</Hash>
</Codenesium>*/