using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ExtensionConfigurationService: AbstractExtensionConfigurationService, IExtensionConfigurationService
        {
                public ExtensionConfigurationService(
                        ILogger<ExtensionConfigurationRepository> logger,
                        IExtensionConfigurationRepository extensionConfigurationRepository,
                        IApiExtensionConfigurationRequestModelValidator extensionConfigurationModelValidator,
                        IBOLExtensionConfigurationMapper bolextensionConfigurationMapper,
                        IDALExtensionConfigurationMapper dalextensionConfigurationMapper

                        )
                        : base(logger,
                               extensionConfigurationRepository,
                               extensionConfigurationModelValidator,
                               bolextensionConfigurationMapper,
                               dalextensionConfigurationMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>23f231823065ce97cd6f75ab5e13e689</Hash>
</Codenesium>*/