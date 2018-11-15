using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Client
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
    <Hash>68cde805e58e00a2fd7f0925732e1f39</Hash>
</Codenesium>*/