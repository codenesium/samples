using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiVotesModelMapper
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
    <Hash>da789bf336a6855c90acadb3570af497</Hash>
</Codenesium>*/