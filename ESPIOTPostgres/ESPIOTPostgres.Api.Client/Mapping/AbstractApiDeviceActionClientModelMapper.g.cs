using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Client
{
	public abstract class AbstractApiDeviceActionModelMapper
	{
		public virtual ApiDeviceActionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiDeviceActionClientRequestModel request)
		{
			var response = new ApiDeviceActionClientResponseModel();
			response.SetProperties(id,
			                       request.Action,
			                       request.DeviceId,
			                       request.Name);
			return response;
		}

		public virtual ApiDeviceActionClientRequestModel MapClientResponseToRequest(
			ApiDeviceActionClientResponseModel response)
		{
			var request = new ApiDeviceActionClientRequestModel();
			request.SetProperties(
				response.Action,
				response.DeviceId,
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>d00ed9e1de7910a232c2c783ca19d715</Hash>
</Codenesium>*/