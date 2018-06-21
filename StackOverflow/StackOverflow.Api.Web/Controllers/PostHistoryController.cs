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
        [Route("api/postHistories")]
        [ApiVersion("1.0")]
        public class PostHistoryController : AbstractPostHistoryController
        {
                public PostHistoryController(
                        ApiSettings settings,
                        ILogger<PostHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPostHistoryService postHistoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               postHistoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>e9d1d2ebd47474f41acb8db9580fa5bb</Hash>
</Codenesium>*/