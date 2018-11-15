using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiTransactionModelMapper
	{
		ApiTransactionClientResponseModel MapClientRequestToResponse(
			int id,
			ApiTransactionClientRequestModel request);

		ApiTransactionClientRequestModel MapClientResponseToRequest(
			ApiTransactionClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>49c4cd91d5e6427e60650323762fb2a7</Hash>
</Codenesium>*/