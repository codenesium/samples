using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

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
    <Hash>19957fb2da66f4e6affa989ae8eb55e7</Hash>
</Codenesium>*/