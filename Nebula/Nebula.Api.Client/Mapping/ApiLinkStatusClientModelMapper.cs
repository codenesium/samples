using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public class ApiLinkStatusModelMapper : IApiLinkStatusModelMapper
	{
		public virtual ApiLinkStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkStatusClientRequestModel request)
		{
			var response = new ApiLinkStatusClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiLinkStatusClientRequestModel MapClientResponseToRequest(
			ApiLinkStatusClientResponseModel response)
		{
			var request = new ApiLinkStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>f8d074a932f788dfd101b129c5e7d292</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/