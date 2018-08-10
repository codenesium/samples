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
    <Hash>0f2f7a3bac020b79328ac0de98b1fc52</Hash>
</Codenesium>*/