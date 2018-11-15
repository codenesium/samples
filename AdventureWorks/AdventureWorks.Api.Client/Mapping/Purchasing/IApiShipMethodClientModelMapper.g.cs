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
    <Hash>c2b8e8283a5dbcf8e4a7374c479ec512</Hash>
</Codenesium>*/