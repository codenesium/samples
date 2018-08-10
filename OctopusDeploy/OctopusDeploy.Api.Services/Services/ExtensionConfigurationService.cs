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
	public partial class ExtensionConfigurationService : AbstractExtensionConfigurationService, IExtensionConfigurationService
	{
		public ExtensionConfigurationService(
			ILogger<IExtensionConfigurationRepository> logger,
			IExtensionConfigurationRepository extensionConfigurationRepository,
			IApiExtensionConfigurationRequestModelValidator extensionConfigurationModelValidator,
			IBOLExtensionConfigurationMapper bolextensionConfigurationMapper,
			IDALExtensionConfigurationMapper dalextensionConfigurationMapper
			)
			: base(logger,
			       extensionConfigurationRepository,
			       extensionConfigurationModelValidator,
			       bolextensionConfigurationMapper,
			       dalextensionConfigurationMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>25776bc6fbb4c040dae4d1b7c384a197</Hash>
</Codenesium>*/