using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class ExtensionConfigurationRepository : AbstractExtensionConfigurationRepository, IExtensionConfigurationRepository
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
    <Hash>c995f5c623d5ee13508c39fa8e092eda</Hash>
</Codenesium>*/