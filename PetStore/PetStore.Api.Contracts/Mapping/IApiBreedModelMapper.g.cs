using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
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
    <Hash>ee8a582366441ea2263b2dbf45c75380</Hash>
</Codenesium>*/