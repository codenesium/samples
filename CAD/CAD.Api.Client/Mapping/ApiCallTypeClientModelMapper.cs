using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CADNS.Api.Client
{
	public class ApiCallTypeModelMapper : IApiCallTypeModelMapper
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
    <Hash>884a98ec94c66fa47f6e6662ae922f5b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/