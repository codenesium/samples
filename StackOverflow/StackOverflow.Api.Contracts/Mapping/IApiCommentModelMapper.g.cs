using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiCommentModelMapper
	{
		ApiCommentResponseModel MapRequestToResponse(
			int id,
			ApiCommentRequestModel request);

		ApiCommentRequestModel MapResponseToRequest(
			ApiCommentResponseModel response);

		JsonPatchDocument<ApiCommentRequestModel> CreatePatch(ApiCommentRequestModel model);
	}
}

/*<Codenesium>
    <Hash>156da4abb40c1c73dc80299cc86279af</Hash>
</Codenesium>*/