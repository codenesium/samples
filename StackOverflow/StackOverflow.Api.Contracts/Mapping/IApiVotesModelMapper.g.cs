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
    <Hash>91322c82debccce17c5b5bc81b6b9d09</Hash>
</Codenesium>*/