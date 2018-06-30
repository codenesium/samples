using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ConfigurationRepository : AbstractConfigurationRepository, IConfigurationRepository
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
    <Hash>1acefd0b87006e61663312fdb87fde33</Hash>
</Codenesium>*/