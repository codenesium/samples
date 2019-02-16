using MediatR;
using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class FollowerService : AbstractFollowerService, IFollowerService
	{
		public FollowerService(
			ILogger<IFollowerRepository> logger,
			IMediator mediator,
			IFollowerRepository followerRepository,
			IApiFollowerServerRequestModelValidator followerModelValidator,
			IDALFollowerMapper dalFollowerMapper)
			: base(logger,
			       mediator,
			       followerRepository,
			       followerModelValidator,
			       dalFollowerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>54562edb0c0ed9f98e4140771a844044</Hash>
</Codenesium>*/