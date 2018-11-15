using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiEventModelMapper
	{
		ApiEventClientResponseModel MapClientRequestToResponse(
			int id,
			ApiEventClientRequestModel request);

		ApiEventClientRequestModel MapClientResponseToRequest(
			ApiEventClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a9e790e7a168a8f1e249d0cdbe923d61</Hash>
</Codenesium>*/