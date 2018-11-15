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
    <Hash>3beb74050c137476ca1537ccb3309609</Hash>
</Codenesium>*/