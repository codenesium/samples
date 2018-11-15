using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Client
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
    <Hash>95b7a6bc18a9ee9475c7a781431f9ff1</Hash>
</Codenesium>*/