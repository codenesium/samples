using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ConfigurationRepository: AbstractConfigurationRepository, IConfigurationRepository
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
    <Hash>db4b6e6460b9d43ffcb67e2d00425014</Hash>
</Codenesium>*/