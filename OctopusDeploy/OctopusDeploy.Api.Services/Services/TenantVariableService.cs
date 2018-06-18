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
                               daltenantVariableMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>805a402a305d028dfdb02f7fedaf4655</Hash>
</Codenesium>*/