using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

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
    <Hash>c74c62afb42ff7ef59ace22dc253f7fb</Hash>
</Codenesium>*/