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
			IBucketModelValidator bucketModelValidator)
			: base(logger, bucketRepository, bucketModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>f780c0076af844facab3370e7fbfee4b</Hash>
</Codenesium>*/