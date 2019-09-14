using ESPIOTNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public class ApiDeviceServerModelMapper : IApiDeviceServerModelMapper
	{
		public virtual ApiDeviceServerResponseModel MapServerRequestToResponse(
			int id,
			ApiDeviceServerRequestModel request)
		{
			var response = new ApiDeviceServerResponseModel();
			response.SetProperties(id,
			                       request.DateOfLastPing,
			                       request.IsActive,
			                       request.Name,
			                       request.PublicId);
			return response;
		}

		public virtual ApiDeviceServerRequestModel MapServerResponseToRequest(
			ApiDeviceServerResponseModel response)
		{
			var request = new ApiDeviceServerRequestModel();
			request.SetProperties(
				response.DateOfLastPing,
				response.IsActive,
				response.Name,
				response.PublicId);
			return request;
		}

		public virtual ApiDeviceClientRequestModel MapServerResponseToClientRequest(
			ApiDeviceServerResponseModel response)
		{
			var request = new ApiDeviceClientRequestModel();
			request.SetProperties(
				response.DateOfLastPing,
				response.IsActive,
				response.Name,
				response.PublicId);
			return request;
		}

		public JsonPatchDocument<ApiDeviceServerRequestModel> CreatePatch(ApiDeviceServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDeviceServerRequestModel>();
			patch.Replace(x => x.DateOfLastPing, model.DateOfLastPing);
			patch.Replace(x => x.IsActive, model.IsActive);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.PublicId, model.PublicId);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>05390c1e2ab3d1673f770b1eaeeb7fea</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/