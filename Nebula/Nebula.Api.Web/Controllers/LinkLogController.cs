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
        [Route("api/linkLogs")]
        [ApiVersion("1.0")]
        public class LinkLogController : AbstractLinkLogController
        {
                public LinkLogController(
                        ApiSettings settings,
                        ILogger<LinkLogController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILinkLogService linkLogService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               linkLogService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f77bb8227d1670565c8c98f10862a301</Hash>
</Codenesium>*/