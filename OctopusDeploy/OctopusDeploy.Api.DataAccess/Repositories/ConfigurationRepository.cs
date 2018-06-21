using Codenesium.DataConversionExtensions;
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
    <Hash>9045233b871d8c3be21e7f9f998e45e1</Hash>
</Codenesium>*/