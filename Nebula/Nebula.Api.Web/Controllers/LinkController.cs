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
        [Route("api/links")]
        [ApiVersion("1.0")]
        public class LinkController : AbstractLinkController
        {
                public LinkController(
                        ApiSettings settings,
                        ILogger<LinkController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILinkService linkService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               linkService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>47b59bff319ce0ac6f42fc16a07ad47f</Hash>
</Codenesium>*/