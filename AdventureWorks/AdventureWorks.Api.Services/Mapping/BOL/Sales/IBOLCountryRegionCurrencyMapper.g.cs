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
    <Hash>f57c7901138e31c0defbb2e4e474ca1a</Hash>
</Codenesium>*/