using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiVehicleRefCapabilityModelMapper
	{
		public virtual ApiVehicleRefCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehicleRefCapabilityClientRequestModel request)
		{
			var response = new ApiVehicleRefCapabilityClientResponseModel();
			response.SetProperties(id,
			                       request.VehicleCapabilityId,
			                       request.VehicleId);
			return response;
		}

		public virtual ApiVehicleRefCapabilityClientRequestModel MapClientResponseToRequest(
			ApiVehicleRefCapabilityClientResponseModel response)
		{
			var request = new ApiVehicleRefCapabilityClientRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId,
				response.VehicleId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>2c20eb5a8223b02d0392e24f68c1e556</Hash>
</Codenesium>*/