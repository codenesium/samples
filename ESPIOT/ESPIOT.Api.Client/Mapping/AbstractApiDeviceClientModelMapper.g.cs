using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Client
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
    <Hash>fc49e254b75fd7e48a02376de1a6815a</Hash>
</Codenesium>*/