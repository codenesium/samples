using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IBOLCountryRegionCurrencyMapper
	{
		BOCountryRegionCurrency MapModelToBO(
			string countryRegionCode,
			ApiCountryRegionCurrencyRequestModel model);

		ApiCountryRegionCurrencyResponseModel MapBOToModel(
			BOCountryRegionCurrency boCountryRegionCurrency);

		List<ApiCountryRegionCurrencyResponseModel> MapBOToModel(
			List<BOCountryRegionCurrency> items);
	}
}

/*<Codenesium>
    <Hash>eab5ef403ab6585f77ec98a7f1270246</Hash>
</Codenesium>*/