using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>71c91b2ae9b7de7a7524835852467c40</Hash>
</Codenesium>*/