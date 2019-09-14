using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiBreedServerModelMapper
	{
		ApiBreedServerResponseModel MapServerRequestToResponse(
			int id,
			ApiBreedServerRequestModel request);

		ApiBreedServerRequestModel MapServerResponseToRequest(
			ApiBreedServerResponseModel response);

		ApiBreedClientRequestModel MapServerResponseToClientRequest(
			ApiBreedServerResponseModel response);

		JsonPatchDocument<ApiBreedServerRequestModel> CreatePatch(ApiBreedServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>3c62692f579eaeca93c3d892ecbb4456</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/