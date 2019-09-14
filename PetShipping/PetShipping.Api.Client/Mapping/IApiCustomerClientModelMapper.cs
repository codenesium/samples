using PetShippingNS.Api.Contracts;
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
    <Hash>049ac1f2053f074ae82ba4718b27cb4a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/