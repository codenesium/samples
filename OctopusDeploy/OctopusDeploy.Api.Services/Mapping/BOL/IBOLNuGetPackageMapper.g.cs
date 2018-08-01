using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public interface IBOLNuGetPackageMapper
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
    <Hash>62fa574e0d1b2a1086f810b5df2afc44</Hash>
</Codenesium>*/