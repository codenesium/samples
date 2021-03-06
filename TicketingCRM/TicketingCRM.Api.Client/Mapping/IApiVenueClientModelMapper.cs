using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

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
    <Hash>3f347822a6ef8379b846a1deb43ac776</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/