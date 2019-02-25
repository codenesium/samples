using AdventureWorksNS.Api.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Client
{
	public partial interface IApiCurrencyRateModelMapper
	{
		ApiCurrencyRateClientResponseModel MapClientRequestToResponse(
			int currencyRateID,
			ApiCurrencyRateClientRequestModel request);

		ApiCurrencyRateClientRequestModel MapClientResponseToRequest(
			ApiCurrencyRateClientResponseModel response);
	}
}

/*<Codenesium>
    <Hash>236118af60d3d6d4b8636d0ff77b1ed9</Hash>
</Codenesium>*/