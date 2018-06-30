using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class TenantVariableRepository : AbstractTenantVariableRepository, ITenantVariableRepository
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
    <Hash>b8e62604ebdfc8209531f91b9f53b9b2</Hash>
</Codenesium>*/