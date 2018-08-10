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
	public partial class ConfigurationRepository : AbstractConfigurationRepository, IConfigurationRepository
	{
		public ConfigurationRepository(
			ILogger<ConfigurationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bebee9319dcee543d4193984dbc2d5c6</Hash>
</Codenesium>*/