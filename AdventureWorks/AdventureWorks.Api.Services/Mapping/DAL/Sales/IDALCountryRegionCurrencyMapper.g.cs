using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCountryRegionCurrencyMapper
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
    <Hash>95b3a5f292361fc3f1d790abc73c624e</Hash>
</Codenesium>*/