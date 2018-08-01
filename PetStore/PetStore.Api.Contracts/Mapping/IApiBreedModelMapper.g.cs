using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public interface IApiBreedModelMapper
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
    <Hash>1df16d5c39fc4610fa97f77d73fa770d</Hash>
</Codenesium>*/