using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiChainStatusModelMapper
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
    <Hash>8170ef9f032c2bbf5db212fc588772ed</Hash>
</Codenesium>*/