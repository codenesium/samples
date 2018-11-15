using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLCurrencyMapper
	{
		BOCurrency MapModelToBO(
			string currencyCode,
			ApiCurrencyServerRequestModel model);

		ApiCurrencyServerResponseModel MapBOToModel(
			BOCurrency boCurrency);

		List<ApiCurrencyServerResponseModel> MapBOToModel(
			List<BOCurrency> items);
	}
}

/*<Codenesium>
    <Hash>dad8f6bc99e7753d8fb46eb0825aba1b</Hash>
</Codenesium>*/