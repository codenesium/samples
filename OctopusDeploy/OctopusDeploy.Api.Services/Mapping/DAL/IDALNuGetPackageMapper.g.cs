using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IDALNuGetPackageMapper
	{
		NuGetPackage MapBOToEF(
			BONuGetPackage bo);

		BONuGetPackage MapEFToBO(
			NuGetPackage efNuGetPackage);

		List<BONuGetPackage> MapEFToBO(
			List<NuGetPackage> records);
	}
}

/*<Codenesium>
    <Hash>d934d8e2e408428acc7c70c0fc4d1eb3</Hash>
</Codenesium>*/