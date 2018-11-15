using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.Client
{
	public partial interface IApiChainStatusModelMapper
	{
		ApiChainStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiChainStatusClientRequestModel request);

		ApiChainStatusClientRequestModel MapClientResponseToRequest(
			ApiChainStatusClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>17232bfe586e61f2e67a5f2306234418</Hash>
</Codenesium>*/