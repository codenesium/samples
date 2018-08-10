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
    <Hash>a89bff6caeae159c76f7f3489fda31db</Hash>
</Codenesium>*/