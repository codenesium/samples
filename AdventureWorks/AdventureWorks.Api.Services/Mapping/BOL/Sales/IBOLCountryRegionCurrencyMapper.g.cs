using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IBOLCountryRegionCurrencyMapper
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
    <Hash>8c511afcf722517466c3487e2ce2da5b</Hash>
</Codenesium>*/