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
    <Hash>121caf4e8b5e94cc797cc68c47b89bfc</Hash>
</Codenesium>*/