using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StackOverflowNS.Api.Web
{
        [Route("api/votes")]
        [ApiVersion("1.0")]
        public class VotesController : AbstractVotesController
        {
                public VotesController(
                        ApiSettings settings,
                        ILogger<VotesController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IVotesService votesService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               votesService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>904d9fbe44072b1551fcd243ea36e5a4</Hash>
</Codenesium>*/