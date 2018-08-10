using Codenesium.DataConversionExtensions;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.Services
{
	public partial class BucketService : AbstractBucketService, IBucketService
	{
		public BucketService(
			ILogger<IBucketRepository> logger,
			IBucketRepository bucketRepository,
			IApiBucketRequestModelValidator bucketModelValidator,
			IBOLBucketMapper bolbucketMapper,
			IDALBucketMapper dalbucketMapper,
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper
			)
			: base(logger,
			       bucketRepository,
			       bucketModelValidator,
			       bolbucketMapper,
			       dalbucketMapper,
			       bolFileMapper,
			       dalFileMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>76985c32828765aa1fd188d1c14e6b5f</Hash>
</Codenesium>*/