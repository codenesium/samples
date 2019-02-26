using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiVehicleCapabilitiesModelMapper
	{
		public virtual ApiVehicleCapabilitiesClientResponseModel MapClientRequestToResponse(
			int vehicleId,
			ApiVehicleCapabilitiesClientRequestModel request)
		{
			var response = new ApiVehicleCapabilitiesClientResponseModel();
			response.SetProperties(vehicleId,
			                       request.VehicleCapabilityId);
			return response;
		}

		public virtual ApiVehicleCapabilitiesClientRequestModel MapClientResponseToRequest(
			ApiVehicleCapabilitiesClientResponseModel response)
		{
			var request = new ApiVehicleCapabilitiesClientRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>651576b8734b71d4af4f0b4723fc015e</Hash>
</Codenesium>*/