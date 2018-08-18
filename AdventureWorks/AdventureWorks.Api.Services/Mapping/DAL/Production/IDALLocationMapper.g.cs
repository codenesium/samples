using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALLocationMapper
	{
		Location MapBOToEF(
			BOLocation bo);

		BOLocation MapEFToBO(
			Location efLocation);

		List<BOLocation> MapEFToBO(
			List<Location> records);
	}
}

/*<Codenesium>
    <Hash>934282898012a2dd2d66bfb36782bfe7</Hash>
</Codenesium>*/