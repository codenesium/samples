using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Services
{
	public interface IDALAWBuildVersionMapper
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
    <Hash>645dae64baf1d70952269eea4edf8f3b</Hash>
</Codenesium>*/