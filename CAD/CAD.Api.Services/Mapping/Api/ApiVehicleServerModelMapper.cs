using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiVehicleServerModelMapper : IApiVehicleServerModelMapper
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
    <Hash>650ba579190af0521c9aa204ee4f9df1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/