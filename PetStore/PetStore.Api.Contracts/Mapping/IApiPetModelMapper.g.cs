using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public partial interface IApiPetModelMapper
	{
		ApiPetResponseModel MapRequestToResponse(
			int id,
			ApiPetRequestModel request);

		ApiPetRequestModel MapResponseToRequest(
			ApiPetResponseModel response);

		JsonPatchDocument<ApiPetRequestModel> CreatePatch(ApiPetRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7567d026ec0cb16a62cc3e40c5de4c28</Hash>
</Codenesium>*/