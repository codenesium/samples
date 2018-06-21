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
        [Route("api/chainStatus")]
        [ApiVersion("1.0")]
        public class ChainStatusController : AbstractChainStatusController
        {
                public ChainStatusController(
                        ApiSettings settings,
                        ILogger<ChainStatusController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IChainStatusService chainStatusService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               chainStatusService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>cb1a8a1261ac26d8609d8d6886f6e295</Hash>
</Codenesium>*/