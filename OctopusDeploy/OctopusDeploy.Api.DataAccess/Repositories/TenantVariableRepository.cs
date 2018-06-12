using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class TenantVariableRepository: AbstractTenantVariableRepository, ITenantVariableRepository
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
    <Hash>13715ff75e0daa8e1d27a0802b5ac654</Hash>
</Codenesium>*/