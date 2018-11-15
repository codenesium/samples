using Microsoft.AspNetCore.JsonPatch;
using PetShippingNS.Api.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public partial interface IApiAirlineServerModelMapper
	{
		ApiAirlineServerResponseModel MapServerRequestToResponse(
			int id,
			ApiAirlineServerRequestModel request);

		ApiAirlineServerRequestModel MapServerResponseToRequest(
			ApiAirlineServerResponseModel response);

		ApiAirlineClientRequestModel MapServerResponseToClientRequest(
			ApiAirlineServerResponseModel response);

		JsonPatchDocument<ApiAirlineServerRequestModel> CreatePatch(ApiAirlineServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>b99dd9db313238bc54d5e3d16e058e0b</Hash>
</Codenesium>*/