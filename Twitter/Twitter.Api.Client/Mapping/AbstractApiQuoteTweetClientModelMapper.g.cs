using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public abstract class AbstractApiQuoteTweetModelMapper
	{
		public virtual ApiQuoteTweetClientResponseModel MapClientRequestToResponse(
			int quoteTweetId,
			ApiQuoteTweetClientRequestModel request)
		{
			var response = new ApiQuoteTweetClientResponseModel();
			response.SetProperties(quoteTweetId,
			                       request.Content,
			                       request.Date,
			                       request.RetweeterUserId,
			                       request.SourceTweetId,
			                       request.Time);
			return response;
		}

		public virtual ApiQuoteTweetClientRequestModel MapClientResponseToRequest(
			ApiQuoteTweetClientResponseModel response)
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
	}
}

/*<Codenesium>
    <Hash>08a9c50af2e6c296a7fa1d262785318a</Hash>
</Codenesium>*/