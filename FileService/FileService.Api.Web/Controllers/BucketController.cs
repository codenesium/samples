using Codenesium.Foundation.CommonMVC;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FileServiceNS.Api.Web
{
	[Route("api/buckets")]
	[ApiController]
	[ApiVersion("1.0")]
	public class BucketController : AbstractBucketController
	{
		public BucketController(
			ApiSettings settings,
			ILogger<BucketController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBucketService bucketService,
			IApiBucketModelMapper bucketModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       bucketService,
			       bucketModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0dca8b3b91caf0664a7aa2c65bdb7f63</Hash>
</Codenesium>*/