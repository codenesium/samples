using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiVehicleCapabilitiesModelMapper
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
    <Hash>8cbb80dd5f549d12aa64b535b445f36b</Hash>
</Codenesium>*/