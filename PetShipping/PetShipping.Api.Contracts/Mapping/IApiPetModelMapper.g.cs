using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Contracts
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
    <Hash>ca29c5fe8e43a7c6a1c125cc52a7fdc8</Hash>
</Codenesium>*/