using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiSalesTaxRateModelMapper
	{
		ApiSalesTaxRateClientResponseModel MapClientRequestToResponse(
			int salesTaxRateID,
			ApiSalesTaxRateClientRequestModel request);

		ApiSalesTaxRateClientRequestModel MapClientResponseToRequest(
			ApiSalesTaxRateClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>4f5e432622231825d27fa7c133e0f7a0</Hash>
</Codenesium>*/