using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALCountryRegionMapper
	{
		CountryRegion MapBOToEF(
			BOCountryRegion bo);

		BOCountryRegion MapEFToBO(
			CountryRegion efCountryRegion);

		List<BOCountryRegion> MapEFToBO(
			List<CountryRegion> records);
	}
}

/*<Codenesium>
    <Hash>078b519f0300d96dda6213b251b7bc98</Hash>
</Codenesium>*/