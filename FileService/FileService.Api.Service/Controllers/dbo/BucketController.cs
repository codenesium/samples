using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.BusinessObjects;

namespace FileServiceNS.Api.Service
{
	[Route("api/buckets")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class BucketController: AbstractBucketController
	{
		public BucketController(
			ILogger<BucketController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOBucket bucketManager
			)
			: base(logger,
			       transactionCoordinator,
			       bucketManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>84ff1f70ef6371f4c5c316d573d238d0</Hash>
</Codenesium>*/