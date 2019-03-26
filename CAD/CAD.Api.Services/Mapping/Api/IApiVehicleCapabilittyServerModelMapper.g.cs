using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleCapabilittyServerModelMapper
	{
		ApiVehicleCapabilittyServerResponseModel MapServerRequestToResponse(
			int vehicleId,
			ApiVehicleCapabilittyServerRequestModel request);

		ApiVehicleCapabilittyServerRequestModel MapServerResponseToRequest(
			ApiVehicleCapabilittyServerResponseModel response);

		ApiVehicleCapabilittyClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleCapabilittyServerResponseModel response);

		JsonPatchDocument<ApiVehicleCapabilittyServerRequestModel> CreatePatch(ApiVehicleCapabilittyServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>89f923911e7cca9b4bc4a8379dc87b48</Hash>
</Codenesium>*/