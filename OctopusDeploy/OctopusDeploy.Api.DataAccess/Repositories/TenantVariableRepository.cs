using Codenesium.DataConversionExtensions;
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
    <Hash>adce70031e3be7fa2c9ba4acae789ae9</Hash>
</Codenesium>*/