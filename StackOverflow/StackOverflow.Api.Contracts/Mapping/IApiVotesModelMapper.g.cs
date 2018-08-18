using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiVotesModelMapper
	{
		ApiVotesResponseModel MapRequestToResponse(
			int id,
			ApiVotesRequestModel request);

		ApiVotesRequestModel MapResponseToRequest(
			ApiVotesResponseModel response);

		JsonPatchDocument<ApiVotesRequestModel> CreatePatch(ApiVotesRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d78f14e64aa368cea529498958fd3421</Hash>
</Codenesium>*/