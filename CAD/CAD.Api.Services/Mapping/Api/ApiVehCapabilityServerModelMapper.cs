using CADNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Services
{
	public class ApiVehCapabilityServerModelMapper : IApiVehCapabilityServerModelMapper
	{
		public virtual ApiVehCapabilityServerResponseModel MapServerRequestToResponse(
			int id,
			ApiVehCapabilityServerRequestModel request)
		{
			var response = new ApiVehCapabilityServerResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiVehCapabilityServerRequestModel MapServerResponseToRequest(
			ApiVehCapabilityServerResponseModel response)
		{
			var request = new ApiVehCapabilityServerRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public virtual ApiVehCapabilityClientRequestModel MapServerResponseToClientRequest(
			ApiVehCapabilityServerResponseModel response)
		{
			var request = new ApiVehCapabilityClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiVehCapabilityServerRequestModel> CreatePatch(ApiVehCapabilityServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiVehCapabilityServerRequestModel>();
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>7bff044af2847a8285db37dd8d29c3ec</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/