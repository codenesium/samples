using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public class ApiChainModelMapper : IApiChainModelMapper
	{
		public virtual ApiChainClientResponseModel MapClientRequestToResponse(
			int id,
			ApiChainClientRequestModel request)
		{
			var response = new ApiChainClientResponseModel();
			response.SetProperties(id,
			                       request.ChainStatusId,
			                       request.ExternalId,
			                       request.Name,
			                       request.TeamId);
			return response;
		}

		public virtual ApiChainClientRequestModel MapClientResponseToRequest(
			ApiChainClientResponseModel response)
		{
			var request = new ApiChainClientRequestModel();
			request.SetProperties(
				response.ChainStatusId,
				response.ExternalId,
				response.Name,
				response.TeamId);
			return request;
		}
	}
}

/*<Codenesium>
    <Hash>ae4cfd4e4cb85b430c1d44e38ea82490</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/