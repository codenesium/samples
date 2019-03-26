using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiShipMethodModelMapper
	{
		ApiShipMethodClientResponseModel MapClientRequestToResponse(
			int shipMethodID,
			ApiShipMethodClientRequestModel request);

		ApiShipMethodClientRequestModel MapClientResponseToRequest(
			ApiShipMethodClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>797cbee59e109131dc0586f1bbb42e45</Hash>
</Codenesium>*/