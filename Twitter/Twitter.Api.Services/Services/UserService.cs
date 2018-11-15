using Microsoft.Extensions.Logging;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;

namespace TwitterNS.Api.Services
{
	public partial class UserService : AbstractUserService, IUserService
	{
		public UserService(
			ILogger<IUserRepository> logger,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
			IBOLUserMapper bolUserMapper,
			IDALUserMapper dalUserMapper,
			IBOLDirectTweetMapper bolDirectTweetMapper,
			IDALDirectTweetMapper dalDirectTweetMapper,
			IBOLFollowerMapper bolFollowerMapper,
			IDALFollowerMapper dalFollowerMapper,
			IBOLMessageMapper bolMessageMapper,
			IDALMessageMapper dalMessageMapper,
			IBOLMessengerMapper bolMessengerMapper,
			IDALMessengerMapper dalMessengerMapper,
			IBOLQuoteTweetMapper bolQuoteTweetMapper,
			IDALQuoteTweetMapper dalQuoteTweetMapper,
			IBOLReplyMapper bolReplyMapper,
			IDALReplyMapper dalReplyMapper,
			IBOLRetweetMapper bolRetweetMapper,
			IDALRetweetMapper dalRetweetMapper,
			IBOLTweetMapper bolTweetMapper,
			IDALTweetMapper dalTweetMapper)
			: base(logger,
			       userRepository,
			       userModelValidator,
			       bolUserMapper,
			       dalUserMapper,
			       bolDirectTweetMapper,
			       dalDirectTweetMapper,
			       bolFollowerMapper,
			       dalFollowerMapper,
			       bolMessageMapper,
			       dalMessageMapper,
			       bolMessengerMapper,
			       dalMessengerMapper,
			       bolQuoteTweetMapper,
			       dalQuoteTweetMapper,
			       bolReplyMapper,
			       dalReplyMapper,
			       bolRetweetMapper,
			       dalRetweetMapper,
			       bolTweetMapper,
			       dalTweetMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d8ac8dcefb6e556ac283aec28437bc94</Hash>
</Codenesium>*/