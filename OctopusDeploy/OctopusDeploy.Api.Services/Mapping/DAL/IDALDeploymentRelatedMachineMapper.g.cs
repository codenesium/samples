using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>f052a6765d284c66fc7185105344f020</Hash>
</Codenesium>*/