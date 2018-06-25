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
    <Hash>b309a50ce7a93468e34504670b6e8f5e</Hash>
</Codenesium>*/