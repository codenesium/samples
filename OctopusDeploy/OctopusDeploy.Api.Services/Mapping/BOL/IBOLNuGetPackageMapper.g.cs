using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public partial interface IBOLNuGetPackageMapper
	{
		BONuGetPackage MapModelToBO(
			string id,
			ApiNuGetPackageRequestModel model);

		ApiNuGetPackageResponseModel MapBOToModel(
			BONuGetPackage boNuGetPackage);

		List<ApiNuGetPackageResponseModel> MapBOToModel(
			List<BONuGetPackage> items);
	}
}

/*<Codenesium>
    <Hash>fabdfcbdb2087a88bab46978931ee3bf</Hash>
</Codenesium>*/