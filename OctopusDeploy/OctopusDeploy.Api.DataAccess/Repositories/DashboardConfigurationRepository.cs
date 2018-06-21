using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class DashboardConfigurationRepository : AbstractDashboardConfigurationRepository, IDashboardConfigurationRepository
        {
                public DashboardConfigurationRepository(
                        ILogger<DashboardConfigurationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a0e8e212e1a998a9229efc6deb744bba</Hash>
</Codenesium>*/