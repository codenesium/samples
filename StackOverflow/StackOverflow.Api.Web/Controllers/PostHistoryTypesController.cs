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
        [Route("api/postHistoryTypes")]
        [ApiController]
        [ApiVersion("1.0")]
        public class PostHistoryTypesController : AbstractPostHistoryTypesController
        {
                public PostHistoryTypesController(
                        ApiSettings settings,
                        ILogger<PostHistoryTypesController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPostHistoryTypesService postHistoryTypesService,
                        IApiPostHistoryTypesModelMapper postHistoryTypesModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               postHistoryTypesService,
                               postHistoryTypesModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d95ae098f4f844beb0e99c92f93b3d2f</Hash>
</Codenesium>*/