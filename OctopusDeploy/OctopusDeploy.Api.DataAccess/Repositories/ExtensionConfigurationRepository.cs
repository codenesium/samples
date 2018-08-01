using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial class ExtensionConfigurationRepository : AbstractExtensionConfigurationRepository, IExtensionConfigurationRepository
	{
		public ExtensionConfigurationRepository(
			ILogger<ExtensionConfigurationRepository> logger,
			ApplicationDbContext context)
			: base(logger, context)
		{
		}
	}
}

/*<Codenesium>
    <Hash>631a86e7be72f813b07f42a136165a1c</Hash>
</Codenesium>*/