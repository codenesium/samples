using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>c358bfaa584790a748513817e8e4a9e7</Hash>
</Codenesium>*/