using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiPetServerModelMapper
	{
		ApiPetServerResponseModel MapServerRequestToResponse(
			int id,
			ApiPetServerRequestModel request);

		ApiPetServerRequestModel MapServerResponseToRequest(
			ApiPetServerResponseModel response);

		ApiPetClientRequestModel MapServerResponseToClientRequest(
			ApiPetServerResponseModel response);

		JsonPatchDocument<ApiPetServerRequestModel> CreatePatch(ApiPetServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1bac6f26546ccb85dfdaf067e14d4f2f</Hash>
</Codenesium>*/