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
        public partial class ConfigurationService : AbstractConfigurationService, IConfigurationService
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
    <Hash>b5fd969c8665d70214365d2a35512ef1</Hash>
</Codenesium>*/