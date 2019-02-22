using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiVehicleCapabilityModelMapper
	{
		public virtual ApiVehicleCapabilityClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVehicleCapabilityClientRequestModel request)
		{
			var response = new ApiVehicleCapabilityClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVehicleCapabilityClientRequestModel MapClientResponseToRequest(
			ApiVehicleCapabilityClientResponseModel response)
		{
			var request = new ApiVehicleCapabilityClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>8d046f07083ee0e343fc1e7865cafbc8</Hash>
</Codenesium>*/