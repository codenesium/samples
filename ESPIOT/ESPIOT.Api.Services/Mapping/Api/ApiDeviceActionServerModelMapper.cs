using ESPIOTNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public class ApiDeviceActionServerModelMapper : IApiDeviceActionServerModelMapper
	{
		public virtual ApiDeviceActionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiDeviceActionServerRequestModel request)
		{
			var response = new ApiDeviceActionServerResponseModel();
			response.SetProperties(id,
			                       request.Action,
			                       request.DeviceId,
			                       request.Name);
			return response;
		}

		public virtual ApiDeviceActionServerRequestModel MapServerResponseToRequest(
			ApiDeviceActionServerResponseModel response)
		{
			var request = new ApiDeviceActionServerRequestModel();
			request.SetProperties(
				response.Action,
				response.DeviceId,
				response.Name);
			return request;
		}

		public virtual ApiDeviceActionClientRequestModel MapServerResponseToClientRequest(
			ApiDeviceActionServerResponseModel response)
		{
			var request = new ApiDeviceActionClientRequestModel();
			request.SetProperties(
				response.Action,
				response.DeviceId,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiDeviceActionServerRequestModel> CreatePatch(ApiDeviceActionServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDeviceActionServerRequestModel>();
			patch.Replace(x => x.Action, model.Action);
			patch.Replace(x => x.DeviceId, model.DeviceId);
			patch.Replace(x => x.Name, model.Name);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>1d6fd7bd4b9621e7628b3c2b7c8beec7</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/