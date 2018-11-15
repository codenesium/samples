using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiSaleModelMapper
	{
		ApiSaleClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSaleClientRequestModel request);

		ApiSaleClientRequestModel MapClientResponseToRequest(
			ApiSaleClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>dbf168f26610120f8e8f3cf093e957f2</Hash>
</Codenesium>*/