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
			IDALBucketMapper dalBucketMapper,
			IDALFileMapper dalFileMapper)
			: base(logger,
			       mediator,
			       bucketRepository,
			       bucketModelValidator,
			       dalBucketMapper,
			       dalFileMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>e2f820804228dc230510a02f5bcefed6</Hash>
</Codenesium>*/