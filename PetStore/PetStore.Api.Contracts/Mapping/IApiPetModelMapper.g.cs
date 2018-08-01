using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Contracts
{
	public interface IApiPetModelMapper
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
    <Hash>ab2ecbf983e91d8a073af10ac358c08c</Hash>
</Codenesium>*/