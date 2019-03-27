using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiVehicleOfficerServerModelMapper
	{
		public virtual ApiVehicleOfficerServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVehicleOfficerServerRequestModel request)
		{
			var response = new ApiVehicleOfficerServerResponseModel();
			response.SetProperties(id,
			                       request.OfficerId,
			                       request.VehicleId);
			return response;
		}

		public virtual ApiVehicleOfficerServerRequestModel MapServerResponseToRequest(
			ApiVehicleOfficerServerResponseModel response)
		{
			var request = new ApiVehicleOfficerServerRequestModel();
			request.SetProperties(
				response.OfficerId,
				response.VehicleId);
			return request;
		}

		public virtual ApiVehicleOfficerClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleOfficerServerResponseModel response)
		{
			var request = new ApiVehicleOfficerClientRequestModel();
			request.SetProperties(
				response.OfficerId,
				response.VehicleId);
			return request;
		}

		public JsonPatchDocument<ApiVehicleOfficerServerRequestModel> CreatePatch(ApiVehicleOfficerServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVehicleOfficerServerRequestModel>();
			patch.Replace(x => x.OfficerId, model.OfficerId);
			patch.Replace(x => x.VehicleId, model.VehicleId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7f455ae109161bb400b4ae2de113d561</Hash>
</Codenesium>*/