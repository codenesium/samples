using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLCurrencyRateMapper
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
    <Hash>303b533aaef12f1ed1d71fd508ab9a92</Hash>
</Codenesium>*/