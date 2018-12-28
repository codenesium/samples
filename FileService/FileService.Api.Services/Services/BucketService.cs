using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FileServiceNS.Api.Services
{
	public partial class BucketService : AbstractBucketService, IBucketService
	{
		public BucketService(
			ILogger<IBucketRepository> logger,
			IMediator mediator,
			IBucketRepository bucketRepository,
			IApiBucketServerRequestModelValidator bucketModelValidator,
			IBOLBucketMapper bolBucketMapper,
			IDALBucketMapper dalBucketMapper,
			IBOLFileMapper bolFileMapper,
			IDALFileMapper dalFileMapper)
			: base(logger,
			       mediator,
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
    <Hash>9223e861ef45e6253e02ecc0e948ea9c</Hash>
</Codenesium>*/