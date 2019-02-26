using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleCapabilitiesServerModelMapper
	{
		ApiVehicleCapabilitiesServerResponseModel MapServerRequestToResponse(
			int vehicleId,
			ApiVehicleCapabilitiesServerRequestModel request);

		ApiVehicleCapabilitiesServerRequestModel MapServerResponseToRequest(
			ApiVehicleCapabilitiesServerResponseModel response);

		ApiVehicleCapabilitiesClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleCapabilitiesServerResponseModel response);

		JsonPatchDocument<ApiVehicleCapabilitiesServerRequestModel> CreatePatch(ApiVehicleCapabilitiesServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>9cfbff8fd3683e796d24b14fbfda1f94</Hash>
</Codenesium>*/