using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Client
{
	public class ApiDeviceModelMapper : IApiDeviceModelMapper
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
    <Hash>11032039b621533d82ed23e1850e457c</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/