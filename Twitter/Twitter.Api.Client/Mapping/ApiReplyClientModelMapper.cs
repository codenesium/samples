using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public class ApiReplyModelMapper : IApiReplyModelMapper
	{
		public virtual ApiReplyClientResponseModel MapClientRequestToResponse(
			int replyId,
			ApiReplyClientRequestModel request)
		{
			var response = new ApiReplyClientResponseModel();
			response.SetProperties(replyId,
			                       request.Content,
			                       request.Date,
			                       request.ReplierUserId,
			                       request.Time);
			return response;
		}

		public virtual ApiReplyClientRequestModel MapClientResponseToRequest(
			ApiReplyClientResponseModel response)
		{
			var request = new ApiReplyClientRequestModel();
			request.SetProperties(
				response.Content,
				response.Date,
				response.ReplierUserId,
				response.Time);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>f487533d4533be0d930fab524b29665f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/