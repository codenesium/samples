using MediatR;
using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class UserService : AbstractUserService, IUserService
	{
		public UserService(
			ILogger<IUserRepository> logger,
			IMediator mediator,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
			IDALUserMapper dalUserMapper,
			IDALDirectTweetMapper dalDirectTweetMapper,
			IDALFollowerMapper dalFollowerMapper,
			IDALMessageMapper dalMessageMapper,
			IDALMessengerMapper dalMessengerMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IDALReplyMapper dalReplyMapper,
			IDALRetweetMapper dalRetweetMapper,
			IDALTweetMapper dalTweetMapper)
			: base(logger,
			       mediator,
			       userRepository,
			       userModelValidator,
			       dalUserMapper,
			       dalDirectTweetMapper,
			       dalFollowerMapper,
			       dalMessageMapper,
			       dalMessengerMapper,
			       dalQuoteTweetMapper,
			       dalReplyMapper,
			       dalRetweetMapper,
			       dalTweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>3e33d426751d4be58c28e4214a9b4aa1</Hash>
</Codenesium>*/