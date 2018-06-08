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
        [Route("api/chainStatus")]
        [ApiVersion("1.0")]
        public class ChainStatusController: AbstractChainStatusController
        {
                public ChainStatusController(
                        ServiceSettings settings,
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
    <Hash>f4903ba4fad95722aaab75c2346274fa</Hash>
</Codenesium>*/