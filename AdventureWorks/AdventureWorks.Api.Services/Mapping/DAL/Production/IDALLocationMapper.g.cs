using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
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
    <Hash>550585e4c5cf2056080b2fad9bf75ab4</Hash>
</Codenesium>*/