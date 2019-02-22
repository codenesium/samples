using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleCapabilityServerModelMapper
	{
		ApiVehicleCapabilityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVehicleCapabilityServerRequestModel request);

		ApiVehicleCapabilityServerRequestModel MapServerResponseToRequest(
			ApiVehicleCapabilityServerResponseModel response);

		ApiVehicleCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleCapabilityServerResponseModel response);

		JsonPatchDocument<ApiVehicleCapabilityServerRequestModel> CreatePatch(ApiVehicleCapabilityServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>7beb54d7d07fc3b0297667f42b5fffe2</Hash>
</Codenesium>*/