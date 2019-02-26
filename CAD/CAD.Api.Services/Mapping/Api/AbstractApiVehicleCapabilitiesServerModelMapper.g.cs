using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiVehicleCapabilitiesServerModelMapper
	{
		public virtual ApiVehicleCapabilitiesServerResponseModel MapServerRequestToResponse(
			int vehicleId,
			ApiVehicleCapabilitiesServerRequestModel request)
		{
			var response = new ApiVehicleCapabilitiesServerResponseModel();
			response.SetProperties(vehicleId,
			                       request.VehicleCapabilityId);
			return response;
		}

		public virtual ApiVehicleCapabilitiesServerRequestModel MapServerResponseToRequest(
			ApiVehicleCapabilitiesServerResponseModel response)
		{
			var request = new ApiVehicleCapabilitiesServerRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId);
			return request;
		}

		public virtual ApiVehicleCapabilitiesClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleCapabilitiesServerResponseModel response)
		{
			var request = new ApiVehicleCapabilitiesClientRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId);
			return request;
		}

		public JsonPatchDocument<ApiVehicleCapabilitiesServerRequestModel> CreatePatch(ApiVehicleCapabilitiesServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVehicleCapabilitiesServerRequestModel>();
			patch.Replace(x => x.VehicleCapabilityId, model.VehicleCapabilityId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>d00002d501adfeb9ba8cafdd79429cc8</Hash>
</Codenesium>*/