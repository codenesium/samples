using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Service
{
	[Route("api/buckets")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(BucketFilter))]
	public class BucketController: AbstractBucketController
	{
		public BucketController(
			ILogger<BucketController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBucketRepository bucketRepository
			)
			: base(logger,
			       transactionCoordinator,
			       bucketRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0b12001caf89461e6b8a5978ec5f9954</Hash>
</Codenesium>*/