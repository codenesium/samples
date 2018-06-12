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
                        ServiceSettings settings,
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
    <Hash>da90e5751d0964aee914825652bc8ac2</Hash>
</Codenesium>*/