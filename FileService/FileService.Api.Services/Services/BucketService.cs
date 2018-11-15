using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace FileServiceNS.Api.Services
{
	public partial class BucketService : AbstractBucketService, IBucketService
	{
		public BucketService(
			ILogger<IBucketRepository> logger,
			IBucketRepository bucketRepository,
			IApiBucketServerRequestModelValidator bucketModelValidator,
			IBOLBucketMapper bolBucketMapper,
			IDALBucketMapper dalBucketMapper,
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper)
			: base(logger,
			       bucketRepository,
			       bucketModelValidator,
			       bolBucketMapper,
			       dalBucketMapper,
			       bolFileMapper,
			       dalFileMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7003f8f0d576c58042e66fe2f19c2573</Hash>
</Codenesium>*/