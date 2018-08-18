using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
	public partial interface IDALAWBuildVersionMapper
	{
		AWBuildVersion MapBOToEF(
			BOAWBuildVersion bo);

		BOAWBuildVersion MapEFToBO(
			AWBuildVersion efAWBuildVersion);

		List<BOAWBuildVersion> MapEFToBO(
			List<AWBuildVersion> records);
	}
}

/*<Codenesium>
    <Hash>b29d9c662639eb7dea7de194d6067e0c</Hash>
</Codenesium>*/