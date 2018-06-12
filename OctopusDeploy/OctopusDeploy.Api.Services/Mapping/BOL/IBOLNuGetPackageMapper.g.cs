using System;
using System.Collections.Generic;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>df5deb70689302b806cdafdd8a60e723</Hash>
</Codenesium>*/