using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiReplyModelMapper
	{
		ApiReplyResponseModel MapRequestToResponse(
			int replyId,
			ApiReplyRequestModel request);

		ApiReplyRequestModel MapResponseToRequest(
			ApiReplyResponseModel response);

		JsonPatchDocument<ApiReplyRequestModel> CreatePatch(ApiReplyRequestModel model);
	}
}

/*<Codenesium>
    <Hash>8ab128e2af53cd1b82b120733c8bc2e8</Hash>
</Codenesium>*/