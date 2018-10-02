using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALVStateProvinceCountryRegionMapper
	{
		VStateProvinceCountryRegion MapBOToEF(
			BOVStateProvinceCountryRegion bo);

		BOVStateProvinceCountryRegion MapEFToBO(
			VStateProvinceCountryRegion efVStateProvinceCountryRegion);

		List<BOVStateProvinceCountryRegion> MapEFToBO(
			List<VStateProvinceCountryRegion> records);
	}
}

/*<Codenesium>
    <Hash>561aa96e17958d8526801730fd8e69a1</Hash>
</Codenesium>*/