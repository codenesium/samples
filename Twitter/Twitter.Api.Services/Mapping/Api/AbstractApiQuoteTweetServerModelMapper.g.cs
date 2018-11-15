using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Client;

namespace TwitterNS.Api.Services
{
	public abstract class AbstractApiQuoteTweetServerModelMapper
	{
		public virtual ApiQuoteTweetServerResponseModel MapServerRequestToResponse(
			int quoteTweetId,
			ApiQuoteTweetServerRequestModel request)
		{
			var response = new ApiQuoteTweetServerResponseModel();
			response.SetProperties(quoteTweetId,
			                       request.Content,
			                       request.Date,
			                       request.RetweeterUserId,
			                       request.SourceTweetId,
			                       request.Time);
			return response;
		}

		public virtual ApiQuoteTweetServerRequestModel MapServerResponseToRequest(
			ApiQuoteTweetServerResponseModel response)
		{
			var request = new ApiQuoteTweetServerRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.RetweeterUserId,
				response.SourceTweetId,
				response.Time);
			return request;
		}

		public virtual ApiQuoteTweetClientRequestModel MapServerResponseToClientRequest(
			ApiQuoteTweetServerResponseModel response)
		{
			var request = new ApiQuoteTweetClientRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.RetweeterUserId,
				response.SourceTweetId,
				response.Time);
			return request;
		}

		public JsonPatchDocument<ApiQuoteTweetServerRequestModel> CreatePatch(ApiQuoteTweetServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiQuoteTweetServerRequestModel>();
			patch.Replace(x => x.Content, model.Content);
			patch.Replace(x => x.Date, model.Date);
			patch.Replace(x => x.RetweeterUserId, model.RetweeterUserId);
			patch.Replace(x => x.SourceTweetId, model.SourceTweetId);
			patch.Replace(x => x.Time, model.Time);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1f9c657ef6e1d5aa34a6a5bab17f0f4b</Hash>
</Codenesium>*/