using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class TenantVariableRepository : AbstractTenantVariableRepository, ITenantVariableRepository
        {
                public TenantVariableRepository(
                        ILogger<TenantVariableRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5ff0e53b3d16fd26a3a01097ac0ada2f</Hash>
</Codenesium>*/