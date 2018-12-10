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
    <Hash>edafd3fbb7432c18ccbeab8ee66e357c</Hash>
</Codenesium>*/