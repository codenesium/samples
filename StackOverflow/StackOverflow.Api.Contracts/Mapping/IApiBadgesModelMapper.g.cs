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
    <Hash>eb727abb4008664e5c33e84cb79a8d01</Hash>
</Codenesium>*/