using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public class ApiQuoteTweetModelMapper : IApiQuoteTweetModelMapper
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
    <Hash>3bd51fba137ebb00810ff28eb85b8a4c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/