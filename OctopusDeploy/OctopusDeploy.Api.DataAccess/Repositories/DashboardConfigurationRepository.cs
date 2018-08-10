using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>cc3ffd90d859ca52d6ec3f1930ebb8d0</Hash>
</Codenesium>*/