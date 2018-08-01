using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>531b62a91696858a8ebacbc33d6fa6f4</Hash>
</Codenesium>*/