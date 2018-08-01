using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALCountryRegionMapper
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
    <Hash>ac36e3e9a822ee294776131daa9a1072</Hash>
</Codenesium>*/