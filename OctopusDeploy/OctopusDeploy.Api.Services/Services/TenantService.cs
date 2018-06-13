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
                        ILogger<TenantRepository> logger,
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
    <Hash>580d21bccd73d924c98f96c357292722</Hash>
</Codenesium>*/