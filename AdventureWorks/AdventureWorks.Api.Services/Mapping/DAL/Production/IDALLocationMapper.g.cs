using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public interface IDALLocationMapper
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
    <Hash>c8d7b1048f52e21d81514d2632e60b31</Hash>
</Codenesium>*/