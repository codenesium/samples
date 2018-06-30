using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public interface IDALDashboardConfigurationMapper
        {
                DashboardConfiguration MapBOToEF(
                        BODashboardConfiguration bo);

                BODashboardConfiguration MapEFToBO(
                        DashboardConfiguration efDashboardConfiguration);

                List<BODashboardConfiguration> MapEFToBO(
                        List<DashboardConfiguration> records);
        }
}

/*<Codenesium>
    <Hash>1367026139db839d796ef18ac061af79</Hash>
</Codenesium>*/