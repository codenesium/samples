using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>1e3be71399a3f19d1712d85d5bdd525d</Hash>
</Codenesium>*/