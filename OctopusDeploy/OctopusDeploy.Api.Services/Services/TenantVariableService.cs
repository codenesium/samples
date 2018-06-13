using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class TenantVariableService: AbstractTenantVariableService, ITenantVariableService
        {
                public TenantVariableService(
                        ILogger<TenantVariableRepository> logger,
                        ITenantVariableRepository tenantVariableRepository,
                        IApiTenantVariableRequestModelValidator tenantVariableModelValidator,
                        IBOLTenantVariableMapper boltenantVariableMapper,
                        IDALTenantVariableMapper daltenantVariableMapper

                        )
                        : base(logger,
                               tenantVariableRepository,
                               tenantVariableModelValidator,
                               boltenantVariableMapper,
                               daltenantVariableMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>35fffd5af7c2b4edf15466094495693b</Hash>
</Codenesium>*/