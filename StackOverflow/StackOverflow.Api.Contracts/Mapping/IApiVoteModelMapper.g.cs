using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiVoteModelMapper
	{
		ApiVoteResponseModel MapRequestToResponse(
			int id,
			ApiVoteRequestModel request);

		ApiVoteRequestModel MapResponseToRequest(
			ApiVoteResponseModel response);

		JsonPatchDocument<ApiVoteRequestModel> CreatePatch(ApiVoteRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d0081796967ee5be610701efb66f8bb2</Hash>
</Codenesium>*/