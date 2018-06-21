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
        [Route("api/postTypes")]
        [ApiVersion("1.0")]
        public class PostTypesController : AbstractPostTypesController
        {
                public PostTypesController(
                        ApiSettings settings,
                        ILogger<PostTypesController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPostTypesService postTypesService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               postTypesService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ce50216d486095c8d6cf3ab78c311f66</Hash>
</Codenesium>*/