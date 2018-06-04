using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
	public class BucketService: AbstractBucketService, IBucketService
	{
		public BucketService(
			ILogger<BucketRepository> logger,
			IBucketRepository bucketRepository,
			IApiBucketRequestModelValidator bucketModelValidator,
			IBOLBucketMapper BOLbucketMapper,
			IDALBucketMapper DALbucketMapper)
			: base(logger, bucketRepository,
			       bucketModelValidator,
			       BOLbucketMapper,
			       DALbucketMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>86683633a27b0ae7333acf9fcad1fa97</Hash>
</Codenesium>*/