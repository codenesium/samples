using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Client
{
	public class ApiDeviceActionModelMapper : IApiDeviceActionModelMapper
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
    <Hash>af4f554e1f183d1c77b5f88248cd7a3a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/