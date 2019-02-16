using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

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
    <Hash>ebfb94d486264ce4d676ffe102818d2e</Hash>
</Codenesium>*/