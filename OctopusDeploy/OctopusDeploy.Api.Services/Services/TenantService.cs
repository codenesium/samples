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
        public class TenantService: AbstractTenantService, ITenantService
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
                               daltenantMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>bc406d060a09c5a701d59be113bbad56</Hash>
</Codenesium>*/