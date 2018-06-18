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
                               dalconfigurationMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>285c11f59483ae77d72481d0909acdd5</Hash>
</Codenesium>*/