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
    <Hash>3d9ef63b9f88803d7370240ffea34193</Hash>
</Codenesium>*/