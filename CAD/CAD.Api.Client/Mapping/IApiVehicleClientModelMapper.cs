using CADNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public partial interface IApiVehicleModelMapper
	{
		ApiVehicleClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehicleClientRequestModel request);

		ApiVehicleClientRequestModel MapClientResponseToRequest(
			ApiVehicleClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>e5216379b4303f6933ebfe1a06aac8dc</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/