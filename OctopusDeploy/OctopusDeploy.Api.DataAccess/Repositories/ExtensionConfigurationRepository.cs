using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ExtensionConfigurationRepository: AbstractExtensionConfigurationRepository, IExtensionConfigurationRepository
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
    <Hash>b6e32b225fa5f269cedf74d0b0255b06</Hash>
</Codenesium>*/