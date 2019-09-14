using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleServerModelMapper
	{
		ApiVehicleServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVehicleServerRequestModel request);

		ApiVehicleServerRequestModel MapServerResponseToRequest(
			ApiVehicleServerResponseModel response);

		ApiVehicleClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleServerResponseModel response);

		JsonPatchDocument<ApiVehicleServerRequestModel> CreatePatch(ApiVehicleServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>0cb25bf9d7614b3a8bbd4a9e9f14777c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/