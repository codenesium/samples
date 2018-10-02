using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Contracts
{
	public partial interface IApiBadgeModelMapper
	{
		ApiBadgeResponseModel MapRequestToResponse(
			int id,
			ApiBadgeRequestModel request);

		ApiBadgeRequestModel MapResponseToRequest(
			ApiBadgeResponseModel response);

		JsonPatchDocument<ApiBadgeRequestModel> CreatePatch(ApiBadgeRequestModel model);
	}
}

/*<Codenesium>
    <Hash>a9dc7576135fd314d2043a4ae3ed6be1</Hash>
</Codenesium>*/