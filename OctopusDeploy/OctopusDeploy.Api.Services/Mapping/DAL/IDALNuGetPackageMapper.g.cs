using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IDALNuGetPackageMapper
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
    <Hash>47cc82b2dc2da768764f1fe0b379c8c2</Hash>
</Codenesium>*/