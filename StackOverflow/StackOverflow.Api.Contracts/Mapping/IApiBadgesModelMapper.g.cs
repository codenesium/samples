using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public interface IApiBadgesModelMapper
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
    <Hash>396a2a714e17a6dfb752d9e71f860995</Hash>
</Codenesium>*/