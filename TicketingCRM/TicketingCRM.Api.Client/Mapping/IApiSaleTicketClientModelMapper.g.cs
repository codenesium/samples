using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiSaleTicketModelMapper
	{
		ApiSaleTicketClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSaleTicketClientRequestModel request);

		ApiSaleTicketClientRequestModel MapClientResponseToRequest(
			ApiSaleTicketClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>a50dbe5e1208f7bdb4ca266a2a562dd5</Hash>
</Codenesium>*/