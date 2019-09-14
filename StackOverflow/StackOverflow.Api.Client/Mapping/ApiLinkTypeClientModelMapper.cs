using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Client
{
	public class ApiLinkTypeModelMapper : IApiLinkTypeModelMapper
	{
		public virtual ApiLinkTypeClientResponseModel MapClientRequestToResponse(
			int id,
			ApiLinkTypeClientRequestModel request)
		{
			var response = new ApiLinkTypeClientResponseModel();
			response.SetProperties(id,
			                       request.RwType);
			return response;
		}

		public virtual ApiLinkTypeClientRequestModel MapClientResponseToRequest(
			ApiLinkTypeClientResponseModel response)
		{
			var request = new ApiLinkTypeClientRequestModel();
			request.SetProperties(
				response.RwType);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>740a2cfb1f02f10c1b9beb39b29c6f49</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/