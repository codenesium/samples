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
    <Hash>52c80de80dc7684f2ba003f21dddfea8</Hash>
</Codenesium>*/