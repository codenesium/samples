using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;

namespace FileServiceNS.Api.Web
{
        [Route("api/buckets")]
        [ApiVersion("1.0")]
        public class BucketController: AbstractBucketController
        {
                public BucketController(
                        ApiSettings settings,
                        ILogger<BucketController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IBucketService bucketService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               bucketService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f81e1938c96b4af6eb09eae487ad2de7</Hash>
</Codenesium>*/