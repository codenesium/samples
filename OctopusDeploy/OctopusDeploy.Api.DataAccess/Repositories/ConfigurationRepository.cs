using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ConfigurationRepository : AbstractConfigurationRepository, IConfigurationRepository
        {
                public ConfigurationRepository(
                        ILogger<ConfigurationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>be2dd2f0acc83fb42d34c7d6b8207aab</Hash>
</Codenesium>*/