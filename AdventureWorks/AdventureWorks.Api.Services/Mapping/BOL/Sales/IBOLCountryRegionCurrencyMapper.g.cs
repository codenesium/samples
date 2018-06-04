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
			List<BOCountryRegionCurrency> bos);
	}
}

/*<Codenesium>
    <Hash>ff349760428827c5875caae9086165e0</Hash>
</Codenesium>*/