using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;

namespace TicketingCRMNS.Api.Client
{
	public partial interface IApiCustomerModelMapper
	{
		ApiCustomerClientResponseModel MapClientRequestToResponse(
			int id,
			ApiCustomerClientRequestModel request);

		ApiCustomerClientRequestModel MapClientResponseToRequest(
			ApiCustomerClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>2cfa12ec8d3c89a3e1072488784892ff</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/