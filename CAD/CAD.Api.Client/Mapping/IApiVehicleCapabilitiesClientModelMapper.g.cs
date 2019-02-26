using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiVehicleCapabilitiesModelMapper
	{
		ApiVehicleCapabilitiesClientResponseModel MapClientRequestToResponse(
			int vehicleId,
			ApiVehicleCapabilitiesClientRequestModel request);

		ApiVehicleCapabilitiesClientRequestModel MapClientResponseToRequest(
			ApiVehicleCapabilitiesClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>df2cc06e0f0e15999544d6ac7951939d</Hash>
</Codenesium>*/