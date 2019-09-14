using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiSaleTicketsModelMapper
	{
		ApiSaleTicketsClientResponseModel MapClientRequestToResponse(
			int id,
			ApiSaleTicketsClientRequestModel request);

		ApiSaleTicketsClientRequestModel MapClientResponseToRequest(
			ApiSaleTicketsClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>3f8d8274fae6e38e6cddc871751bc696</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/