using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiVehicleCapabilitiesModelMapper : IApiVehicleCapabilitiesModelMapper
	{
		public virtual ApiVehicleCapabilitiesClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehicleCapabilitiesClientRequestModel request)
		{
			var response = new ApiVehicleCapabilitiesClientResponseModel();
			response.SetProperties(id,
			                       request.VehicleCapabilityId,
			                       request.VehicleId);
			return response;
		}

		public virtual ApiVehicleCapabilitiesClientRequestModel MapClientResponseToRequest(
			ApiVehicleCapabilitiesClientResponseModel response)
		{
			var request = new ApiVehicleCapabilitiesClientRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId,
				response.VehicleId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>4651c2d31bce89cbf10296176e537460</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/