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
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/