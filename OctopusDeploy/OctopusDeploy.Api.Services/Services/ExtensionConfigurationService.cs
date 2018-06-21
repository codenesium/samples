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
        public class ExtensionConfigurationService : AbstractExtensionConfigurationService, IExtensionConfigurationService
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
    <Hash>89c59dc39ef4e31ddc64295f2b64ff03</Hash>
</Codenesium>*/