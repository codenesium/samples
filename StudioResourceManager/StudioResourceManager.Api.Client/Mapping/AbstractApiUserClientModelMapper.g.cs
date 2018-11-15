using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Client
{
	public abstract class AbstractApiUserModelMapper
	{
		public virtual ApiUserClientResponseModel MapClientRequestToResponse(
			int id,
			ApiUserClientRequestModel request)
		{
			var response = new ApiUserClientResponseModel();
			response.SetProperties(id,
			                       request.Password,
			                       request.Username);
			return response;
		}

		public virtual ApiUserClientRequestModel MapClientResponseToRequest(
			ApiUserClientResponseModel response)
		{
			var request = new ApiUserClientRequestModel();
			request.SetProperties(
				response.Password,
				response.Username);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>a10f2fa71184084475ae6df07c90a98a</Hash>
</Codenesium>*/