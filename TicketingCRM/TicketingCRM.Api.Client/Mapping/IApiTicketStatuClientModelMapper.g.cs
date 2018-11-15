using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    <Hash>a4e177440d0d4def3b432aa884f9648a</Hash>
</Codenesium>*/