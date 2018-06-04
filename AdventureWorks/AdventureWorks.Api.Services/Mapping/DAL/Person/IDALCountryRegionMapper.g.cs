using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>b58282efdc0b144419789cf0487ef6de</Hash>
</Codenesium>*/