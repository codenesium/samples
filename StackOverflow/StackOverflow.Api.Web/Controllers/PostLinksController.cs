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
        [Route("api/postLinks")]
        [ApiVersion("1.0")]
        public class PostLinksController : AbstractPostLinksController
        {
                public PostLinksController(
                        ApiSettings settings,
                        ILogger<PostLinksController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPostLinksService postLinksService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               postLinksService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>62a56f3626e139891390c8dd9ff0fd02</Hash>
</Codenesium>*/