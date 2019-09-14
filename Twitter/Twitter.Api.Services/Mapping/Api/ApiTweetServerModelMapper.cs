using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public class ApiTweetServerModelMapper : IApiTweetServerModelMapper
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
    <Hash>a6a26d45d18d24fef2d29c6ce2d04e89</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/