using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
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
    <Hash>d01523511c2c443d03f3791a0b53505d</Hash>
</Codenesium>*/