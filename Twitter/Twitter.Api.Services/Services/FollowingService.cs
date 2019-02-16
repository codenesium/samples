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
			IDALFollowingMapper dalFollowingMapper)
			: base(logger,
			       mediator,
			       followingRepository,
			       followingModelValidator,
			       dalFollowingMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>10f705d7f3a8cb15349e9dac1e32e2ad</Hash>
</Codenesium>*/