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
			List<BOCurrency> bos);
	}
}

/*<Codenesium>
    <Hash>e8d5b216a6cb397a2e948d9348f36cf5</Hash>
</Codenesium>*/