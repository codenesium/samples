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
    <Hash>dbaeb1b7c8245e6c66098931de39e760</Hash>
</Codenesium>*/