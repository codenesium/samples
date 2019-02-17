using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiTransactionStatusModelMapper
	{
		ApiTransactionStatusClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTransactionStatusClientRequestModel request);

		ApiTransactionStatusClientRequestModel MapClientResponseToRequest(
			ApiTransactionStatusClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>6e7572ea0a78ea4864cc692f1fe6f60e</Hash>
</Codenesium>*/