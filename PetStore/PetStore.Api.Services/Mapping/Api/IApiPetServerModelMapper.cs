using Microsoft.AspNetCore.JsonPatch;
using PetStoreNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
    <Hash>9455f4c2623f76e0745698ece82c703a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/