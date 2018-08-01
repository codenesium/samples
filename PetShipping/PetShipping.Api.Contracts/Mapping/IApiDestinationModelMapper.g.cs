using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public interface IApiDestinationModelMapper
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
    <Hash>5a9f3c5ef91e4229df8f61e88bfc342f</Hash>
</Codenesium>*/