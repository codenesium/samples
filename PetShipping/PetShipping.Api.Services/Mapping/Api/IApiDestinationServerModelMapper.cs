using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiDestinationServerModelMapper
	{
		ApiDestinationServerResponseModel MapServerRequestToResponse(
			int id,
			ApiDestinationServerRequestModel request);

		ApiDestinationServerRequestModel MapServerResponseToRequest(
			ApiDestinationServerResponseModel response);

		ApiDestinationClientRequestModel MapServerResponseToClientRequest(
			ApiDestinationServerResponseModel response);

		JsonPatchDocument<ApiDestinationServerRequestModel> CreatePatch(ApiDestinationServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>483d68a8efc693c782598401285f2f0a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/