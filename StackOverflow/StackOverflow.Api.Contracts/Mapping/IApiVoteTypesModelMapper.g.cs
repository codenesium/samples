using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiVoteTypesModelMapper
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
    <Hash>7c6c1c67e4b705c527c19866c7198a92</Hash>
</Codenesium>*/