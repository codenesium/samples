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
                        IVotesService votesService,
                        IApiVotesModelMapper votesModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               votesService,
                               votesModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>5cc793535642be09ee1449a08a46d24e</Hash>
</Codenesium>*/