using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    <Hash>c105bf4e7b94cf7fbe242934c6bead71</Hash>
</Codenesium>*/