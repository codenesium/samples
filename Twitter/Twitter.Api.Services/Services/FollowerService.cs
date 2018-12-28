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
			IBOLFollowerMapper bolFollowerMapper,
			IDALFollowerMapper dalFollowerMapper)
			: base(logger,
			       mediator,
			       followerRepository,
			       followerModelValidator,
			       bolFollowerMapper,
			       dalFollowerMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>4ede1dbce00b82334ce78a80887b1ee5</Hash>
</Codenesium>*/