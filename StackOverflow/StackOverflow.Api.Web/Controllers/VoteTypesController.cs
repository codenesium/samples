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
        [Route("api/voteTypes")]
        [ApiVersion("1.0")]
        public class VoteTypesController : AbstractVoteTypesController
        {
                public VoteTypesController(
                        ApiSettings settings,
                        ILogger<VoteTypesController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IVoteTypesService voteTypesService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               voteTypesService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>21f3c2e08f571024d8338e0fb05457cf</Hash>
</Codenesium>*/