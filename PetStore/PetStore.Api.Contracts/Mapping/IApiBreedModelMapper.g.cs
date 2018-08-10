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
    <Hash>54805bbdd6ea521423fc604770b4c95a</Hash>
</Codenesium>*/