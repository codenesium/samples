using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public abstract class AbstractApiTweetModelMapper
	{
		public virtual ApiTweetResponseModel MapRequestToResponse(
			int tweetId,
			ApiTweetRequestModel request)
		{
			var response = new ApiTweetResponseModel();
			response.SetProperties(tweetId,
			                       request.Content,
			                       request.Date,
			                       request.LocationId,
			                       request.Time,
			                       request.UserUserId);
			return response;
		}

		public virtual ApiTweetRequestModel MapResponseToRequest(
			ApiTweetResponseModel response)
		{
			var request = new ApiTweetRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.LocationId,
				response.Time,
				response.UserUserId);
			return request;
		}

		public JsonPatchDocument<ApiTweetRequestModel> CreatePatch(ApiTweetRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiTweetRequestModel>();
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
    <Hash>b26864ad510bcf155a1b426bd0342e20</Hash>
</Codenesium>*/