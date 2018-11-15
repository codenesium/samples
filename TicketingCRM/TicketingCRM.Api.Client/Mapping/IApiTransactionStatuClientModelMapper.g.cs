using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiTransactionStatuModelMapper
	{
		ApiTransactionStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTransactionStatuClientRequestModel request);

		ApiTransactionStatuClientRequestModel MapClientResponseToRequest(
			ApiTransactionStatuClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>7d10a4385355e22835a8b784cbc62216</Hash>
</Codenesium>*/