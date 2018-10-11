using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterNS.Api.Contracts
{
	public partial interface IApiFollowerModelMapper
	{
		ApiFollowerResponseModel MapRequestToResponse(
			int id,
			ApiFollowerRequestModel request);

		ApiFollowerRequestModel MapResponseToRequest(
			ApiFollowerResponseModel response);

		JsonPatchDocument<ApiFollowerRequestModel> CreatePatch(ApiFollowerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d0637515fb48b64f0bde45450970f666</Hash>
</Codenesium>*/