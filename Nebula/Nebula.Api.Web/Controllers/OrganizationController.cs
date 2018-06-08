using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;

namespace NebulaNS.Api.Web
{
        [Route("api/organizations")]
        [ApiVersion("1.0")]
        public class OrganizationController: AbstractOrganizationController
        {
                public OrganizationController(
                        ServiceSettings settings,
                        ILogger<OrganizationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IOrganizationService organizationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               organizationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ed4af7ebf01229d5ab5a2a65363fa665</Hash>
</Codenesium>*/