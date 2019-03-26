using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiVehicleCapabilittyServerModelMapper
	{
		public virtual ApiVehicleCapabilittyServerResponseModel MapServerRequestToResponse(
			int vehicleId,
			ApiVehicleCapabilittyServerRequestModel request)
		{
			var response = new ApiVehicleCapabilittyServerResponseModel();
			response.SetProperties(vehicleId,
			                       request.VehicleCapabilityId);
			return response;
		}

		public virtual ApiVehicleCapabilittyServerRequestModel MapServerResponseToRequest(
			ApiVehicleCapabilittyServerResponseModel response)
		{
			var request = new ApiVehicleCapabilittyServerRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId);
			return request;
		}

		public virtual ApiVehicleCapabilittyClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleCapabilittyServerResponseModel response)
		{
			var request = new ApiVehicleCapabilittyClientRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId);
			return request;
		}

		public JsonPatchDocument<ApiVehicleCapabilittyServerRequestModel> CreatePatch(ApiVehicleCapabilittyServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVehicleCapabilittyServerRequestModel>();
			patch.Replace(x => x.VehicleCapabilityId, model.VehicleCapabilityId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>4e5b220d9e7ab7a7253dbe8915831511</Hash>
</Codenesium>*/