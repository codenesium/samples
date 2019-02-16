using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;

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
    <Hash>c25848d7901d609a84fd4e9274c8f7be</Hash>
</Codenesium>*/