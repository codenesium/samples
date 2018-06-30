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
        public partial class TenantVariableService : AbstractTenantVariableService, ITenantVariableService
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
    <Hash>cd8ef6b9ef0ee311202d61e5cd894c21</Hash>
</Codenesium>*/