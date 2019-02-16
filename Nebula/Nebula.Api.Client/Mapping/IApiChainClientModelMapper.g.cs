using NebulaNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiChainModelMapper
	{
		ApiChainClientResponseModel MapClientRequestToResponse(
			int id,
			ApiChainClientRequestModel request);

		ApiChainClientRequestModel MapClientResponseToRequest(
			ApiChainClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>0afab84978af99a442131f69606f3cf5</Hash>
</Codenesium>*/