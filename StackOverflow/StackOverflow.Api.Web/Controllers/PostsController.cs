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
        [Route("api/posts")]
        [ApiController]
        [ApiVersion("1.0")]
        public class PostsController : AbstractPostsController
        {
                public PostsController(
                        ApiSettings settings,
                        ILogger<PostsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPostsService postsService,
                        IApiPostsModelMapper postsModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               postsService,
                               postsModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b7648ceb25836723ba8e78a3e411c28c</Hash>
</Codenesium>*/