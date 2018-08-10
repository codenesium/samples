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
    <Hash>3b535b7dad857543e5300ea8b965c0c5</Hash>
</Codenesium>*/