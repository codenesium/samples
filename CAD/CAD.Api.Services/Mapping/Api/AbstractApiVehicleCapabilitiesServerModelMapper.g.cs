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
			int id,
			ApiVehicleCapabilitiesServerRequestModel request)
		{
			var response = new ApiVehicleCapabilitiesServerResponseModel();
			response.SetProperties(id,
			                       request.VehicleCapabilityId,
			                       request.VehicleId);
			return response;
		}

		public virtual ApiVehicleCapabilitiesServerRequestModel MapServerResponseToRequest(
			ApiVehicleCapabilitiesServerResponseModel response)
		{
			var request = new ApiVehicleCapabilitiesServerRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId,
				response.VehicleId);
			return request;
		}

		public virtual ApiVehicleCapabilitiesClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleCapabilitiesServerResponseModel response)
		{
			var request = new ApiVehicleCapabilitiesClientRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId,
				response.VehicleId);
			return request;
		}

		public JsonPatchDocument<ApiVehicleCapabilitiesServerRequestModel> CreatePatch(ApiVehicleCapabilitiesServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVehicleCapabilitiesServerRequestModel>();
			patch.Replace(x => x.VehicleCapabilityId, model.VehicleCapabilityId);
			patch.Replace(x => x.VehicleId, model.VehicleId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>028e7ebd080baf2e824203f780c537e8</Hash>
</Codenesium>*/