using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiVehicleCapabilitiesModelMapper
	{
		ApiVehicleCapabilitiesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehicleCapabilitiesClientRequestModel request);

		ApiVehicleCapabilitiesClientRequestModel MapClientResponseToRequest(
			ApiVehicleCapabilitiesClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>07a1ebb5b823354841e0c3af443488a5</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/