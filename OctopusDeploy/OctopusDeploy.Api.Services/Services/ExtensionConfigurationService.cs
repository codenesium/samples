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
    <Hash>de4ebc18801c2590c68b7e1394bdb7b0</Hash>
</Codenesium>*/