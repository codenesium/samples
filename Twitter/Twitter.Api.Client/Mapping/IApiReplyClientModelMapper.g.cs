using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Client
{
	public partial interface IApiReplyModelMapper
	{
		ApiReplyClientResponseModel MapClientRequestToResponse(
			int replyId,
			ApiReplyClientRequestModel request);

		ApiReplyClientRequestModel MapClientResponseToRequest(
			ApiReplyClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>50d79b5be9c9f1ca585bde35764b390d</Hash>
</Codenesium>*/