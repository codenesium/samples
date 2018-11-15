using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiTicketModelMapper
	{
		ApiTicketClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTicketClientRequestModel request);

		ApiTicketClientRequestModel MapClientResponseToRequest(
			ApiTicketClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>7e92e5967ef82d07fa28801fb20bfd46</Hash>
</Codenesium>*/