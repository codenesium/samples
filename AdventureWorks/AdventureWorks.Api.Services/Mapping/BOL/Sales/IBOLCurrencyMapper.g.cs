using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IBOLCurrencyMapper
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
    <Hash>4f6a6f66f10acd6dda9ff32810205dbc</Hash>
</Codenesium>*/