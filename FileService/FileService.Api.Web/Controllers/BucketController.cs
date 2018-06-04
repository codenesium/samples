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
			ServiceSettings settings,
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
    <Hash>449ee182d868940358181f1da9d62c73</Hash>
</Codenesium>*/