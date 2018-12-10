using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public abstract class AbstractApiChainModelMapper
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
    <Hash>c8d5f665db21f67321bbb419bb165db5</Hash>
</Codenesium>*/