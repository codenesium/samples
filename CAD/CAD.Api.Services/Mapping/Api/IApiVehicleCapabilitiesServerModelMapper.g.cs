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
			int id,
			ApiVehicleCapabilitiesServerRequestModel request);

		ApiVehicleCapabilitiesServerRequestModel MapServerResponseToRequest(
			ApiVehicleCapabilitiesServerResponseModel response);

		ApiVehicleCapabilitiesClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleCapabilitiesServerResponseModel response);

		JsonPatchDocument<ApiVehicleCapabilitiesServerRequestModel> CreatePatch(ApiVehicleCapabilitiesServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>f94cc6c545b1e4720ae012af0d06babf</Hash>
</Codenesium>*/