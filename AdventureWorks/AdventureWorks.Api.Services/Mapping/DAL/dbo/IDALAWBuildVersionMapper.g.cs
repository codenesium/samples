using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>a4af9c27dc6c0f38c878c12cf6431b71</Hash>
</Codenesium>*/