using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public abstract class AbstractApiReplyModelMapper
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
    <Hash>1f94913a5ddc6448c78a7d468f1a1cca</Hash>
</Codenesium>*/