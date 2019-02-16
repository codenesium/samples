using NebulaNS.Api.Contracts;
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
    <Hash>bde9002802be08db9367c6041d0300f4</Hash>
</Codenesium>*/