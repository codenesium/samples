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
    <Hash>ca2c0e1b5df4d6a42bfcd516efd05867</Hash>
</Codenesium>*/