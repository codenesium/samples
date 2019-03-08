using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTPostgresNS.Api.Client
{
	public abstract class AbstractApiDeviceModelMapper
	{
		public virtual ApiDeviceClientResponseModel MapClientRequestToResponse(
			int id,
			ApiDeviceClientRequestModel request)
		{
			var response = new ApiDeviceClientResponseModel();
			response.SetProperties(id,
			                       request.Name,
			                       request.PublicId);
			return response;
		}

		public virtual ApiDeviceClientRequestModel MapClientResponseToRequest(
			ApiDeviceClientResponseModel response)
		{
			var request = new ApiDeviceClientRequestModel();
			request.SetProperties(
				response.Name,
				response.PublicId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>c5322f95436490775e8b6cc4a4b46642</Hash>
</Codenesium>*/