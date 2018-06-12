using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALDeploymentMapper
        {
                Deployment MapBOToEF(
                        BODeployment bo);

                BODeployment MapEFToBO(
                        Deployment efDeployment);

                List<BODeployment> MapEFToBO(
                        List<Deployment> records);
        }
}

/*<Codenesium>
    <Hash>e72e3d8542aaa517cd345b327c07ff5f</Hash>
</Codenesium>*/