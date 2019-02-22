using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiVehicleRefCapabilityServerModelMapper
	{
		public virtual ApiVehicleRefCapabilityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVehicleRefCapabilityServerRequestModel request)
		{
			var response = new ApiVehicleRefCapabilityServerResponseModel();
			response.SetProperties(id,
			                       request.VehicleCapabilityId,
			                       request.VehicleId);
			return response;
		}

		public virtual ApiVehicleRefCapabilityServerRequestModel MapServerResponseToRequest(
			ApiVehicleRefCapabilityServerResponseModel response)
		{
			var request = new ApiVehicleRefCapabilityServerRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId,
				response.VehicleId);
			return request;
		}

		public virtual ApiVehicleRefCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleRefCapabilityServerResponseModel response)
		{
			var request = new ApiVehicleRefCapabilityClientRequestModel();
			request.SetProperties(
				response.VehicleCapabilityId,
				response.VehicleId);
			return request;
		}

		public JsonPatchDocument<ApiVehicleRefCapabilityServerRequestModel> CreatePatch(ApiVehicleRefCapabilityServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVehicleRefCapabilityServerRequestModel>();
			patch.Replace(x => x.VehicleCapabilityId, model.VehicleCapabilityId);
			patch.Replace(x => x.VehicleId, model.VehicleId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>9c7b936099eb0fb2b4835f48010873a2</Hash>
</Codenesium>*/