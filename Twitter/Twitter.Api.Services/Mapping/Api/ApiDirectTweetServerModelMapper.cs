using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public class ApiDirectTweetServerModelMapper : IApiDirectTweetServerModelMapper
	{
		public virtual ApiDirectTweetServerResponseModel MapServerRequestToResponse(
			int tweetId,
			ApiDirectTweetServerRequestModel request)
		{
			var response = new ApiDirectTweetServerResponseModel();
			response.SetProperties(tweetId,
			                       request.Content,
			                       request.Date,
			                       request.TaggedUserId,
			                       request.Time);
			return response;
		}

		public virtual ApiDirectTweetServerRequestModel MapServerResponseToRequest(
			ApiDirectTweetServerResponseModel response)
		{
			var request = new ApiDirectTweetServerRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.TaggedUserId,
				response.Time);
			return request;
		}

		public virtual ApiDirectTweetClientRequestModel MapServerResponseToClientRequest(
			ApiDirectTweetServerResponseModel response)
		{
			var request = new ApiDirectTweetClientRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.TaggedUserId,
				response.Time);
			return request;
		}

		public JsonPatchDocument<ApiDirectTweetServerRequestModel> CreatePatch(ApiDirectTweetServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDirectTweetServerRequestModel>();
			patch.Replace(x => x.Content, model.Content);
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.TaggedUserId, model.TaggedUserId);
			patch.Replace(x => x.Time, model.Time);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>b2a9f3866711b7c06b3a092407cf8cad</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/