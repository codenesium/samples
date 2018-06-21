using Codenesium.DataConversionExtensions;
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
    <Hash>a48683a726e6c061abe603492cd9a478</Hash>
</Codenesium>*/