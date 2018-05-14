using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public class BOBucket: AbstractBOBucket, IBOBucket
	{
		public BOBucket(
			ILogger<BucketRepository> logger,
			IBucketRepository bucketRepository,
			IApiBucketModelValidator bucketModelValidator)
			: base(logger, bucketRepository, bucketModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>a9cec370d4fcb05103c930d84fcebda7</Hash>
</Codenesium>*/