using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public partial interface IApiSpeciesServerModelMapper
	{
		ApiSpeciesServerResponseModel MapServerRequestToResponse(
			int id,
			ApiSpeciesServerRequestModel request);

		ApiSpeciesServerRequestModel MapServerResponseToRequest(
			ApiSpeciesServerResponseModel response);

		ApiSpeciesClientRequestModel MapServerResponseToClientRequest(
			ApiSpeciesServerResponseModel response);

		JsonPatchDocument<ApiSpeciesServerRequestModel> CreatePatch(ApiSpeciesServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>1b614426b3318b473a08134c5fb0506d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/