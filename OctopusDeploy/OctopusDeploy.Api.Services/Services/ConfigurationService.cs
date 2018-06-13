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
        public class ConfigurationService: AbstractConfigurationService, IConfigurationService
        {
                public ConfigurationService(
                        ILogger<ConfigurationRepository> logger,
                        IConfigurationRepository configurationRepository,
                        IApiConfigurationRequestModelValidator configurationModelValidator,
                        IBOLConfigurationMapper bolconfigurationMapper,
                        IDALConfigurationMapper dalconfigurationMapper

                        )
                        : base(logger,
                               configurationRepository,
                               configurationModelValidator,
                               bolconfigurationMapper,
                               dalconfigurationMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>e85465a6e6d32ae9e482c5f05ff433de</Hash>
</Codenesium>*/