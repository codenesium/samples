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
        public partial class TenantService : AbstractTenantService, ITenantService
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
    <Hash>7f6d9a04a82e7f2cf993350ff58cb33b</Hash>
</Codenesium>*/