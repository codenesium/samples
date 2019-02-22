using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public abstract class AbstractApiVehicleCapabilityServerModelMapper
	{
		public virtual ApiVehicleCapabilityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVehicleCapabilityServerRequestModel request)
		{
			var response = new ApiVehicleCapabilityServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVehicleCapabilityServerRequestModel MapServerResponseToRequest(
			ApiVehicleCapabilityServerResponseModel response)
		{
			var request = new ApiVehicleCapabilityServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiVehicleCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiVehicleCapabilityServerResponseModel response)
		{
			var request = new ApiVehicleCapabilityClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiVehicleCapabilityServerRequestModel> CreatePatch(ApiVehicleCapabilityServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVehicleCapabilityServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>5ce77aa3de888d3bfd3807c1e599065a</Hash>
</Codenesium>*/