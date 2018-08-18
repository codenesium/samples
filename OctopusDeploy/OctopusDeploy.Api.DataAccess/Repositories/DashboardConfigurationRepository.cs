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
    <Hash>42b42ff06f0b2038936536c3f680eb13</Hash>
</Codenesium>*/