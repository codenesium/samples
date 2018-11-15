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
    <Hash>1e8765d0d6271589d34c27016736386b</Hash>
</Codenesium>*/