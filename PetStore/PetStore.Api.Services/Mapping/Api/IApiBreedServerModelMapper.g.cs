using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
    <Hash>54a7ddc405cde624a36763c17484d514</Hash>
</Codenesium>*/