using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiBadgesModelMapper
	{
		ApiBadgesResponseModel MapRequestToResponse(
			int id,
			ApiBadgesRequestModel request);

		ApiBadgesRequestModel MapResponseToRequest(
			ApiBadgesResponseModel response);

		JsonPatchDocument<ApiBadgesRequestModel> CreatePatch(ApiBadgesRequestModel model);
	}
}

/*<Codenesium>
    <Hash>19353de0390bd8e7d946e9bb5614d402</Hash>
</Codenesium>*/