using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLCurrencyRateMapper
	{
		BOCurrencyRate MapModelToBO(
			int currencyRateID,
			ApiCurrencyRateRequestModel model);

		ApiCurrencyRateResponseModel MapBOToModel(
			BOCurrencyRate boCurrencyRate);

		List<ApiCurrencyRateResponseModel> MapBOToModel(
			List<BOCurrencyRate> items);
	}
}

/*<Codenesium>
    <Hash>36c403d27dc7bc0177b0e669c4ada29f</Hash>
</Codenesium>*/