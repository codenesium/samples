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
			ApiCurrencyRequestModel model);

		ApiCurrencyResponseModel MapBOToModel(
			BOCurrency boCurrency);

		List<ApiCurrencyResponseModel> MapBOToModel(
			List<BOCurrency> items);
	}
}

/*<Codenesium>
    <Hash>6657524d659e6988bf34a9b56d56bd87</Hash>
</Codenesium>*/