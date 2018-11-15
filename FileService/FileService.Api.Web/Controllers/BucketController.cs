using Codenesium.Foundation.CommonMVC;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Web
{
	[Route("api/buckets")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class BucketController : AbstractBucketController
	{
		public BucketController(
			ApiSettings settings,
			ILogger<BucketController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBucketService bucketService,
			IApiBucketServerModelMapper bucketModelMapper
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
    <Hash>7304ae1458fe4da67e9a6cafe1979ca6</Hash>
</Codenesium>*/