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
	public class BucketController: AbstractBucketController
	{
		public BucketController(
			ILogger<BucketController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBucketRepository bucketRepository,
			IBucketModelValidator bucketModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       bucketRepository,
			       bucketModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>61b8de53319c2d9af58b85b0c8df24c1</Hash>
</Codenesium>*/