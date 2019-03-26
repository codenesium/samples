using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiVehicleCapabilittyModelMapper
	{
		ApiVehicleCapabilittyClientResponseModel MapClientRequestToResponse(
			int vehicleId,
			ApiVehicleCapabilittyClientRequestModel request);

		ApiVehicleCapabilittyClientRequestModel MapClientResponseToRequest(
			ApiVehicleCapabilittyClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>d4ffbaa2362c2a68f6640c5e624cebfe</Hash>
</Codenesium>*/