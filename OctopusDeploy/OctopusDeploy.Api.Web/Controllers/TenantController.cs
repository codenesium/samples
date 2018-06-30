using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/tenants")]
        [ApiVersion("1.0")]
        public class TenantController : AbstractTenantController
        {
                public TenantController(
                        ApiSettings settings,
                        ILogger<TenantController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITenantService tenantService,
                        IApiTenantModelMapper tenantModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               tenantService,
                               tenantModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f7b152a4b0053242ae09b016929747bd</Hash>
</Codenesium>*/