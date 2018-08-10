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
    <Hash>3ed7fb87de1281503018fcb3b9ebcccd</Hash>
</Codenesium>*/