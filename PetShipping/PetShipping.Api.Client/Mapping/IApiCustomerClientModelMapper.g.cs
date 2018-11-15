using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
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
    <Hash>d6d3f97fd61f39b166ad60340a6ff028</Hash>
</Codenesium>*/