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
    <Hash>958963cf6b5a691113aafdff04242e7b</Hash>
</Codenesium>*/