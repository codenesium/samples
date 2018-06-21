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
        public class TenantService : AbstractTenantService, ITenantService
        {
                public TenantService(
                        ILogger<ITenantRepository> logger,
                        ITenantRepository tenantRepository,
                        IApiTenantRequestModelValidator tenantModelValidator,
                        IBOLTenantMapper boltenantMapper,
                        IDALTenantMapper daltenantMapper
                        )
                        : base(logger,
                               tenantRepository,
                               tenantModelValidator,
                               boltenantMapper,
                               daltenantMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>099d419a71dce33c80b2a7173381334a</Hash>
</Codenesium>*/