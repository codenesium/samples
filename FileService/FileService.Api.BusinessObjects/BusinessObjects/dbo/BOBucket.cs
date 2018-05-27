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
			IApiBucketRequestModelValidator bucketModelValidator,
			IBOLBucketMapper bucketMapper)
			: base(logger, bucketRepository, bucketModelValidator, bucketMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>c63a6ac63a846a4980bc8a9299665315</Hash>
</Codenesium>*/