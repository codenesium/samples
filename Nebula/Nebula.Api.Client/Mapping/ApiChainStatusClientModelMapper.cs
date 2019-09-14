using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public class ApiChainStatusModelMapper : IApiChainStatusModelMapper
	{
		public virtual ApiChainStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiChainStatusClientRequestModel request)
		{
			var response = new ApiChainStatusClientResponseModel();
			response.SetProperties(id,
			                       request.Name);
			return response;
		}

		public virtual ApiChainStatusClientRequestModel MapClientResponseToRequest(
			ApiChainStatusClientResponseModel response)
		{
			var request = new ApiChainStatusClientRequestModel();
			request.SetProperties(
				response.Name);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>cd17b67b270954936c9f0cf2377ad990</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/