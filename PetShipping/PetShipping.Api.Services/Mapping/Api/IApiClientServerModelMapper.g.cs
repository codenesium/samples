using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiClientServerModelMapper
	{
		ApiClientServerResponseModel MapServerRequestToResponse(
			int id,
			ApiClientServerRequestModel request);

		ApiClientServerRequestModel MapServerResponseToRequest(
			ApiClientServerResponseModel response);

		ApiClientClientRequestModel MapServerResponseToClientRequest(
			ApiClientServerResponseModel response);

		JsonPatchDocument<ApiClientServerRequestModel> CreatePatch(ApiClientServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f24a4e9b59992dd52fc35d35fc48d691</Hash>
</Codenesium>*/