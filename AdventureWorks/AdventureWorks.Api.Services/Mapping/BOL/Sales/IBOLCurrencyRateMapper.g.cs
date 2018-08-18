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
    <Hash>ad56023d687719ad3c18703d64874f2e</Hash>
</Codenesium>*/