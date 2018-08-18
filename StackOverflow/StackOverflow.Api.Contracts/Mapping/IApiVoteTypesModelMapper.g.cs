using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiVoteTypesModelMapper
	{
		ApiVoteTypesResponseModel MapRequestToResponse(
			int id,
			ApiVoteTypesRequestModel request);

		ApiVoteTypesRequestModel MapResponseToRequest(
			ApiVoteTypesResponseModel response);

		JsonPatchDocument<ApiVoteTypesRequestModel> CreatePatch(ApiVoteTypesRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5d496c51af20d9a8b692e539e7c0b383</Hash>
</Codenesium>*/