using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
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
    <Hash>fc9d0d54a911851c08096e7a72f7df65</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/