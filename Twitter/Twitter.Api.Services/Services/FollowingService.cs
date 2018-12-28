using MediatR;
using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class FollowingService : AbstractFollowingService, IFollowingService
	{
		public FollowingService(
			ILogger<IFollowingRepository> logger,
			IMediator mediator,
			IFollowingRepository followingRepository,
			IApiFollowingServerRequestModelValidator followingModelValidator,
			IBOLFollowingMapper bolFollowingMapper,
			IDALFollowingMapper dalFollowingMapper)
			: base(logger,
			       mediator,
			       followingRepository,
			       followingModelValidator,
			       bolFollowingMapper,
			       dalFollowingMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>feafd15772dc99f6ec87af869c83b165</Hash>
</Codenesium>*/