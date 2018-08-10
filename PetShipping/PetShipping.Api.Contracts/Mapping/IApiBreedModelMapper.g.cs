using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
{
	public partial interface IApiBreedModelMapper
	{
		ApiBreedResponseModel MapRequestToResponse(
			int id,
			ApiBreedRequestModel request);

		ApiBreedRequestModel MapResponseToRequest(
			ApiBreedResponseModel response);

		JsonPatchDocument<ApiBreedRequestModel> CreatePatch(ApiBreedRequestModel model);
	}
}

/*<Codenesium>
    <Hash>e689b5cd214e8443a0f6f6bb3178bb89</Hash>
</Codenesium>*/