using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCurrencyRateMapper
	{
		CurrencyRate MapModelToBO(
			int currencyRateID,
			ApiCurrencyRateServerRequestModel model);

		ApiCurrencyRateServerResponseModel MapBOToModel(
			CurrencyRate item);

		List<ApiCurrencyRateServerResponseModel> MapBOToModel(
			List<CurrencyRate> items);
	}
}

/*<Codenesium>
    <Hash>2f4ec4d55454959d161cc86b13817a11</Hash>
</Codenesium>*/