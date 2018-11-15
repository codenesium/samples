using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class FollowingService : AbstractFollowingService, IFollowingService
	{
		public FollowingService(
			ILogger<IFollowingRepository> logger,
			IFollowingRepository followingRepository,
			IApiFollowingServerRequestModelValidator followingModelValidator,
			IBOLFollowingMapper bolFollowingMapper,
			IDALFollowingMapper dalFollowingMapper)
			: base(logger,
			       followingRepository,
			       followingModelValidator,
			       bolFollowingMapper,
			       dalFollowingMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a5db5725b4e29e8eef19a35180a858d3</Hash>
</Codenesium>*/