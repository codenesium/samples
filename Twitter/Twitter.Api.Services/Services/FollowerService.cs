using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class FollowerService : AbstractFollowerService, IFollowerService
	{
		public FollowerService(
			ILogger<IFollowerRepository> logger,
			IFollowerRepository followerRepository,
			IApiFollowerServerRequestModelValidator followerModelValidator,
			IBOLFollowerMapper bolFollowerMapper,
			IDALFollowerMapper dalFollowerMapper)
			: base(logger,
			       followerRepository,
			       followerModelValidator,
			       bolFollowerMapper,
			       dalFollowerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>00a4f4501d32bf587abf09ae685cab51</Hash>
</Codenesium>*/