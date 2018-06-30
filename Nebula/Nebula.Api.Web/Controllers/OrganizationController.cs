using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NebulaNS.Api.Web
{
        [Route("api/organizations")]
        [ApiVersion("1.0")]
        public class OrganizationController : AbstractOrganizationController
        {
                public OrganizationController(
                        ApiSettings settings,
                        ILogger<OrganizationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IOrganizationService organizationService,
                        IApiOrganizationModelMapper organizationModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               organizationService,
                               organizationModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d0a5984b6b8100b04b79f87eda00e654</Hash>
</Codenesium>*/