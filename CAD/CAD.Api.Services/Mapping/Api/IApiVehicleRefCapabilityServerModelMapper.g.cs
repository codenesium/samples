using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public partial interface IApiVehicleRefCapabilityServerModelMapper
	{
		ApiVehicleRefCapabilityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVehicleRefCapabilityServerRequestModel request);

		ApiVehicleRefCapabilityServerRequestModel MapServerResponseToRequest(
			ApiVehicleRefCapabilityServerResponseModel response);

		ApiVehicleRefCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleRefCapabilityServerResponseModel response);

		JsonPatchDocument<ApiVehicleRefCapabilityServerRequestModel> CreatePatch(ApiVehicleRefCapabilityServerRequestModel model);
	}
}

/*<Codenesium>
    <Hash>d1d54e16a7d40a7f4df0404cdd88c9bc</Hash>
</Codenesium>*/