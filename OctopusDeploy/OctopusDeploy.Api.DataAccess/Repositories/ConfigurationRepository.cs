using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>0d2f92e7b8b8f5206438963b15191404</Hash>
</Codenesium>*/