using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiDestinationModelMapper
	{
		ApiDestinationResponseModel MapRequestToResponse(
			int id,
			ApiDestinationRequestModel request);

		ApiDestinationRequestModel MapResponseToRequest(
			ApiDestinationResponseModel response);

		JsonPatchDocument<ApiDestinationRequestModel> CreatePatch(ApiDestinationRequestModel model);
	}
}

/*<Codenesium>
    <Hash>5d8e2327dace3da42c1cd29591cbb136</Hash>
</Codenesium>*/