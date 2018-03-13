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
	public class BucketsController: BucketsControllerAbstract
	{
		public BucketsController(
			ILogger<BucketsController> logger,
			ApplicationContext context,
			BucketRepository bucketRepository,
			BucketModelValidator bucketModelValidator
			) : base(logger,
			         context,
			         bucketRepository,
			         bucketModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>9f76fd9d9caf0c260d1588f8a6644c45</Hash>
</Codenesium>*/