using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service
{
	[Route("api/buckets")]
	public class BucketsController: AbstractBucketsController
	{
		public BucketsController(
			ILogger<BucketsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBucketRepository bucketRepository,
			IBucketModelValidator bucketModelValidator
			) : base(logger,
			         transactionCoordinator,
			         bucketRepository,
			         bucketModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2c9a00304f6cdae51cf41705e2e3f8aa</Hash>
</Codenesium>*/