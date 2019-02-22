using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public abstract class AbstractApiCallTypeModelMapper
	{
		public virtual ApiCallTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCallTypeClientRequestModel request)
		{
			var response = new ApiCallTypeClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiCallTypeClientRequestModel MapClientResponseToRequest(
			ApiCallTypeClientResponseModel response)
		{
			var request = new ApiCallTypeClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ffbee73a666a8b6fb44e7ef157e8d657</Hash>
</Codenesium>*/