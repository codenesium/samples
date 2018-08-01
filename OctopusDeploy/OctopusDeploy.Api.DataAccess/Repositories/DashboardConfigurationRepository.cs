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
    <Hash>eaacb18c5a428663d893f3b7d1adfc6b</Hash>
</Codenesium>*/