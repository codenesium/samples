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
        [Route("api/tenantVariables")]
        [ApiVersion("1.0")]
        public class TenantVariableController : AbstractTenantVariableController
        {
                public TenantVariableController(
                        ApiSettings settings,
                        ILogger<TenantVariableController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITenantVariableService tenantVariableService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               tenantVariableService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>fcef3becb054f9c22970ebb591cf01fd</Hash>
</Codenesium>*/