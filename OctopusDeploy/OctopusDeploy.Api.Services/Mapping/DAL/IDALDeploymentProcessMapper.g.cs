using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALDeploymentProcessMapper
        {
                DeploymentProcess MapBOToEF(
                        BODeploymentProcess bo);

                BODeploymentProcess MapEFToBO(
                        DeploymentProcess efDeploymentProcess);

                List<BODeploymentProcess> MapEFToBO(
                        List<DeploymentProcess> records);
        }
}

/*<Codenesium>
    <Hash>9f08cdd0edc01fe5921dda1c92f58b6c</Hash>
</Codenesium>*/