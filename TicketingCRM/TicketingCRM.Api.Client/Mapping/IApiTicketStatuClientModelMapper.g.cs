using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiTicketStatuModelMapper
	{
		ApiTicketStatuClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTicketStatuClientRequestModel request);

		ApiTicketStatuClientRequestModel MapClientResponseToRequest(
			ApiTicketStatuClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>40b5878c183beddb34bd101f55f8816b</Hash>
</Codenesium>*/