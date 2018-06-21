using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALDeploymentRelatedMachineMapper
        {
                DeploymentRelatedMachine MapBOToEF(
                        BODeploymentRelatedMachine bo);

                BODeploymentRelatedMachine MapEFToBO(
                        DeploymentRelatedMachine efDeploymentRelatedMachine);

                List<BODeploymentRelatedMachine> MapEFToBO(
                        List<DeploymentRelatedMachine> records);
        }
}

/*<Codenesium>
    <Hash>530eb00b2ce7aee460e23aac125e147b</Hash>
</Codenesium>*/