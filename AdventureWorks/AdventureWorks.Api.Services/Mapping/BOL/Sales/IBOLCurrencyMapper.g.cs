using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>63ebf186a297045f926c46605f497dd2</Hash>
</Codenesium>*/