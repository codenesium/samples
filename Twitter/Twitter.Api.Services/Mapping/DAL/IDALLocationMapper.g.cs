using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
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
    <Hash>154995b9c93e6951ae2450a5c282e807</Hash>
</Codenesium>*/