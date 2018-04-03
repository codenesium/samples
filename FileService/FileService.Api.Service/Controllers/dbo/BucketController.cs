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
			ApplicationContext context,
			IBucketRepository bucketRepository,
			IBucketModelValidator bucketModelValidator
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
    <Hash>9b0e265c891fb1d7033ce0be54b16bd9</Hash>
</Codenesium>*/