using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class TenantRepository : AbstractTenantRepository, ITenantRepository
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
    <Hash>d18044191acea43e7a6552dc9f5e7d40</Hash>
</Codenesium>*/