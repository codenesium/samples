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
        [Route("api/tags")]
        [ApiVersion("1.0")]
        public class TagsController : AbstractTagsController
        {
                public TagsController(
                        ApiSettings settings,
                        ILogger<TagsController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITagsService tagsService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               tagsService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>679b255adc9e6446b97f5802f7089363</Hash>
</Codenesium>*/