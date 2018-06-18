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
    <Hash>6e40b806ceef1f725d0c438c63e3accd</Hash>
</Codenesium>*/