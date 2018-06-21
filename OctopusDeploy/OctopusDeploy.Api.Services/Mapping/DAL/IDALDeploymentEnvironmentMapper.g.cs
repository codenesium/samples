using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALDeploymentEnvironmentMapper
        {
                DeploymentEnvironment MapBOToEF(
                        BODeploymentEnvironment bo);

                BODeploymentEnvironment MapEFToBO(
                        DeploymentEnvironment efDeploymentEnvironment);

                List<BODeploymentEnvironment> MapEFToBO(
                        List<DeploymentEnvironment> records);
        }
}

/*<Codenesium>
    <Hash>6ef2748c684ae21d59d94f73ea3d2a28</Hash>
</Codenesium>*/