using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ExtensionConfigurationRepository : AbstractExtensionConfigurationRepository, IExtensionConfigurationRepository
        {
                public ExtensionConfigurationRepository(
                        ILogger<ExtensionConfigurationRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4e3b806eb1a37de414e88294a8564125</Hash>
</Codenesium>*/