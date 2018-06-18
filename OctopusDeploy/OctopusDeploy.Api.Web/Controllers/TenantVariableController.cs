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
        [Route("api/tenantVariables")]
        [ApiVersion("1.0")]
        public class TenantVariableController: AbstractTenantVariableController
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
    <Hash>b261e8afedc14fa4e6b3ab95fec1e1a3</Hash>
</Codenesium>*/