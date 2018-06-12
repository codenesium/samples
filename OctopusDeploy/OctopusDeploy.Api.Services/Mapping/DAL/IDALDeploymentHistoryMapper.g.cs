using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALDeploymentHistoryMapper
        {
                DeploymentHistory MapBOToEF(
                        BODeploymentHistory bo);

                BODeploymentHistory MapEFToBO(
                        DeploymentHistory efDeploymentHistory);

                List<BODeploymentHistory> MapEFToBO(
                        List<DeploymentHistory> records);
        }
}

/*<Codenesium>
    <Hash>437741c438ae584d96cb77ecd72db732</Hash>
</Codenesium>*/