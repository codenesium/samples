using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public abstract class AbstractApiQuoteTweetModelMapper
	{
		public virtual ApiQuoteTweetResponseModel MapRequestToResponse(
			int quoteTweetId,
			ApiQuoteTweetRequestModel request)
		{
			var response = new ApiQuoteTweetResponseModel();
			response.SetProperties(quoteTweetId,
			                       request.Content,
			                       request.Date,
			                       request.RetweeterUserId,
			                       request.SourceTweetId,
			                       request.Time);
			return response;
		}

		public virtual ApiQuoteTweetRequestModel MapResponseToRequest(
			ApiQuoteTweetResponseModel response)
		{
			var request = new ApiQuoteTweetRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.RetweeterUserId,
				response.SourceTweetId,
				response.Time);
			return request;
		}

		public JsonPatchDocument<ApiQuoteTweetRequestModel> CreatePatch(ApiQuoteTweetRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiQuoteTweetRequestModel>();
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
    <Hash>5637e9de7bc6b25858ccf2df0421c3f1</Hash>
</Codenesium>*/