using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>54ac368afd1908b939ae98b7c1c2af22</Hash>
</Codenesium>*/