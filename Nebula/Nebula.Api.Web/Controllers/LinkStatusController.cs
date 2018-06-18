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
        [Route("api/linkStatus")]
        [ApiVersion("1.0")]
        public class LinkStatusController: AbstractLinkStatusController
        {
                public LinkStatusController(
                        ApiSettings settings,
                        ILogger<LinkStatusController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILinkStatusService linkStatusService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               linkStatusService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>951fb45c1b3a6190f58b3c34bf35133a</Hash>
</Codenesium>*/