using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class DashboardConfigurationRepository : AbstractDashboardConfigurationRepository, IDashboardConfigurationRepository
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
    <Hash>6cdb79e7e3a81fe10fbef197604c3ed4</Hash>
</Codenesium>*/