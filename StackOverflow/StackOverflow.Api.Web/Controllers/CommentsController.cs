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
                        ICommentsService commentsService,
                        IApiCommentsModelMapper commentsModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               commentsService,
                               commentsModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a9e65ae76af58913456d2a61fb653000</Hash>
</Codenesium>*/