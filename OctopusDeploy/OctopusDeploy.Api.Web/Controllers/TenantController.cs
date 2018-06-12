using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/tenants")]
        [ApiVersion("1.0")]
        public class TenantController: AbstractTenantController
        {
                public TenantController(
                        ServiceSettings settings,
                        ILogger<TenantController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITenantService tenantService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               tenantService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>19e06c0b689584195b57f6cbf373c5b8</Hash>
</Codenesium>*/