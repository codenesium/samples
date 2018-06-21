using Codenesium.DataConversionExtensions;
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
    <Hash>43cc47ea094c991ee2baf6fd02a98460</Hash>
</Codenesium>*/