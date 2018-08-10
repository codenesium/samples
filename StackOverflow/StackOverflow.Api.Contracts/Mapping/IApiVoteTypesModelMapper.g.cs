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
    <Hash>767f495c52f2830050fcea6a5f36ade2</Hash>
</Codenesium>*/