using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCurrencyRateMapper
	{
		CurrencyRate MapModelToEntity(
			int currencyRateID,
			ApiCurrencyRateServerRequestModel model);

		ApiCurrencyRateServerResponseModel MapEntityToModel(
			CurrencyRate item);

		List<ApiCurrencyRateServerResponseModel> MapEntityToModel(
			List<CurrencyRate> items);
	}
}

/*<Codenesium>
    <Hash>3fa81436b50cfbaba5c1cd3c02a35a35</Hash>
</Codenesium>*/