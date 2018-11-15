using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Client
{
	public abstract class AbstractApiDeviceActionModelMapper
	{
		public virtual ApiDeviceActionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiDeviceActionClientRequestModel request)
		{
			var response = new ApiDeviceActionClientResponseModel();
			response.SetProperties(id,
			                       request.@Value,
			                       request.DeviceId,
			                       request.Name);
			return response;
		}

		public virtual ApiDeviceActionClientRequestModel MapClientResponseToRequest(
			ApiDeviceActionClientResponseModel response)
		{
			var request = new ApiDeviceActionClientRequestModel();
			request.SetProperties(
				response.@Value,
				response.DeviceId,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>fd307ebfc8297728936c79d1b0f54c4f</Hash>
</Codenesium>*/