using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiVehicleCapabilityModelMapper
	{
		ApiVehicleCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehicleCapabilityClientRequestModel request);

		ApiVehicleCapabilityClientRequestModel MapClientResponseToRequest(
			ApiVehicleCapabilityClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>c5d597134abaf2b402730d1c6e918389</Hash>
</Codenesium>*/