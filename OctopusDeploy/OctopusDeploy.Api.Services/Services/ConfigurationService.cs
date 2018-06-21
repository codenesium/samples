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
        public class ConfigurationService : AbstractConfigurationService, IConfigurationService
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
    <Hash>7f8ce0c5dc7f9239e47bb8fe06f05346</Hash>
</Codenesium>*/