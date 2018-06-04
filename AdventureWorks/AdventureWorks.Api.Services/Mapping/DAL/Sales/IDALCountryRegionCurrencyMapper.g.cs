using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALCountryRegionCurrencyMapper
	{
		CountryRegionCurrency MapBOToEF(
			BOCountryRegionCurrency bo);

		BOCountryRegionCurrency MapEFToBO(
			CountryRegionCurrency efCountryRegionCurrency);

		List<BOCountryRegionCurrency> MapEFToBO(
			List<CountryRegionCurrency> records);
	}
}

/*<Codenesium>
    <Hash>27d3fbab3fe9d4d57a15506127e496a1</Hash>
</Codenesium>*/