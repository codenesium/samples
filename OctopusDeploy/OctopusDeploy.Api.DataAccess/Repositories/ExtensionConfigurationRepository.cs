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
    <Hash>ae95cb47431b72630ce59085a0cc7850</Hash>
</Codenesium>*/