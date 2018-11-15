using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiVenueModelMapper
	{
		ApiVenueClientResponseModel MapClientRequestToResponse(
			int id,
			ApiVenueClientRequestModel request);

		ApiVenueClientRequestModel MapClientResponseToRequest(
			ApiVenueClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>5e311d578b0daf51f985f4013059ff6e</Hash>
</Codenesium>*/