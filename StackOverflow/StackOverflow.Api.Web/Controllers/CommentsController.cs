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
        [Route("api/comments")]
        [ApiVersion("1.0")]
        public class CommentsController : AbstractCommentsController
        {
                public CommentsController(
                        ApiSettings settings,
                        ILogger<CommentsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICommentsService commentsService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               commentsService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>713acc1a7169b8f0d95992d6e00d47b4</Hash>
</Codenesium>*/