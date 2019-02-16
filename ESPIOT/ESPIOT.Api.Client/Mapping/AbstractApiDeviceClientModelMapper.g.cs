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
			                       request.DateOfLastPing,
			                       request.IsActive,
			                       request.Name,
			                       request.PublicId);
			return response;
		}

		public virtual ApiDeviceClientRequestModel MapClientResponseToRequest(
			ApiDeviceClientResponseModel response)
		{
			var request = new ApiDeviceClientRequestModel();
			request.SetProperties(
				response.DateOfLastPing,
				response.IsActive,
				response.Name,
				response.PublicId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>72b1d4659c5bf0e2eb1f078d38a5b1a7</Hash>
</Codenesium>*/