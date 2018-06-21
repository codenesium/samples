using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>1ae5ef2d15aa63fc307118fea9331227</Hash>
</Codenesium>*/