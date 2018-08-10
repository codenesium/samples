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
    <Hash>a211d315e1473816d12c4807b7be9a42</Hash>
</Codenesium>*/