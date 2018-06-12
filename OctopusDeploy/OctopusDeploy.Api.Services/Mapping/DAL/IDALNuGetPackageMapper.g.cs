using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>81d97cc732720ccc257f5e2c5d21f916</Hash>
</Codenesium>*/