using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiVehicleServerModelMapper
	{
		public virtual ApiVehicleServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVehicleServerRequestModel request)
		{
			var response = new ApiVehicleServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVehicleServerRequestModel MapServerResponseToRequest(
			ApiVehicleServerResponseModel response)
		{
			var request = new ApiVehicleServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiVehicleClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleServerResponseModel response)
		{
			var request = new ApiVehicleClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiVehicleServerRequestModel> CreatePatch(ApiVehicleServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVehicleServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>80acc945e259634aa4e161627e4ff6ef</Hash>
</Codenesium>*/