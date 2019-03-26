using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiVehicleCapabilittyModelMapper
	{
		public virtual ApiVehicleCapabilittyClientResponseModel MapClientRequestToResponse(
			int vehicleId,
			ApiVehicleCapabilittyClientRequestModel request)
		{
			var response = new ApiVehicleCapabilittyClientResponseModel();
			response.SetProperties(vehicleId,
			                       request.VehicleCapabilityId);
			return response;
		}

		public virtual ApiVehicleCapabilittyClientRequestModel MapClientResponseToRequest(
			ApiVehicleCapabilittyClientResponseModel response)
		{
			var request = new ApiVehicleCapabilittyClientRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>2a15e3525951ff936d3ba08a43cc894a</Hash>
</Codenesium>*/