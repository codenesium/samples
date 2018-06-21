using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class TenantVariableService : AbstractTenantVariableService, ITenantVariableService
        {
                public TenantVariableService(
                        ILogger<ITenantVariableRepository> logger,
                        ITenantVariableRepository tenantVariableRepository,
                        IApiTenantVariableRequestModelValidator tenantVariableModelValidator,
                        IBOLTenantVariableMapper boltenantVariableMapper,
                        IDALTenantVariableMapper daltenantVariableMapper
                        )
                        : base(logger,
                               tenantVariableRepository,
                               tenantVariableModelValidator,
                               boltenantVariableMapper,
                               daltenantVariableMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5977f38e9de9d366f2bcea87a00685c6</Hash>
</Codenesium>*/