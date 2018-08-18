using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
	public partial class ConfigurationService : AbstractConfigurationService, IConfigurationService
	{
		public ConfigurationService(
			ILogger<IConfigurationRepository> logger,
			IConfigurationRepository configurationRepository,
			IApiConfigurationRequestModelValidator configurationModelValidator,
			IBOLConfigurationMapper bolconfigurationMapper,
			IDALConfigurationMapper dalconfigurationMapper
			)
			: base(logger,
			       configurationRepository,
			       configurationModelValidator,
			       bolconfigurationMapper,
			       dalconfigurationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>95e1be5f997f047bb657df0894e7c3f0</Hash>
</Codenesium>*/