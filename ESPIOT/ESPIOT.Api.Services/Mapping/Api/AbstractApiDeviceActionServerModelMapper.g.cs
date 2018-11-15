using ESPIOTNS.Api.Client;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services
{
	public abstract class AbstractApiDeviceActionServerModelMapper
	{
		public virtual ApiDeviceActionServerResponseModel MapServerRequestToResponse(
			int id,
			ApiDeviceActionServerRequestModel request)
		{
			var response = new ApiDeviceActionServerResponseModel();
			response.SetProperties(id,
			                       request.@Value,
			                       request.DeviceId,
			                       request.Name);
			return response;
		}

		public virtual ApiDeviceActionServerRequestModel MapServerResponseToRequest(
			ApiDeviceActionServerResponseModel response)
		{
			var request = new ApiDeviceActionServerRequestModel();
			request.SetProperties(
				response.@Value,
				response.DeviceId,
				response.Name);
			return request;
		}

		public virtual ApiDeviceActionClientRequestModel MapServerResponseToClientRequest(
			ApiDeviceActionServerResponseModel response)
		{
			var request = new ApiDeviceActionClientRequestModel();
			request.SetProperties(
				response.@Value,
				response.DeviceId,
				response.Name);
			return request;
		}

		public JsonPatchDocument<ApiDeviceActionServerRequestModel> CreatePatch(ApiDeviceActionServerRequestModel model)
		{
			var patch = new JsonPatchDocument<ApiDeviceActionServerRequestModel>();
			patch.Replace(x => x.DeviceId, model.DeviceId);
			patch.Replace(x => x.Name, model.Name);
			patch.Replace(x => x.@Value, model.@Value);
			return patch;
		}
	}
}

/*<Codenesium>
    <Hash>fc6fd95c1c2b8d998f165b7db40701ad</Hash>
</Codenesium>*/