using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiVehicleOfficerServerModelMapper : IApiVehicleOfficerServerModelMapper
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
    <Hash>dd30965d12e5b997dfce0134458c371d</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/