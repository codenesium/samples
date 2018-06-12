using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class TenantRepository: AbstractTenantRepository, ITenantRepository
        {
                public TenantRepository(
                        ILogger<TenantRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ae435c70879ab559eeaf4c418677a8b5</Hash>
</Codenesium>*/