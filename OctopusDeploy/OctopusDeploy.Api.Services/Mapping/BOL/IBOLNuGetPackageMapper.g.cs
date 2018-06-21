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
    <Hash>b412b2706993c24be49be8917e54ee5c</Hash>
</Codenesium>*/