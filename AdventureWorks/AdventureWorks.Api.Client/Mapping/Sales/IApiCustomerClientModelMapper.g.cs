using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiCustomerModelMapper
	{
		ApiCustomerClientResponseModel MapClientRequestToResponse(
			int customerID,
			ApiCustomerClientRequestModel request);

		ApiCustomerClientRequestModel MapClientResponseToRequest(
			ApiCustomerClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>b51702d4f21d33f6f5d05cbd89ab8869</Hash>
</Codenesium>*/