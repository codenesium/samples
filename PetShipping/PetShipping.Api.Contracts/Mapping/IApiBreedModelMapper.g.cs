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
    <Hash>18a0ae6569a3106686257ee59fc81f78</Hash>
</Codenesium>*/