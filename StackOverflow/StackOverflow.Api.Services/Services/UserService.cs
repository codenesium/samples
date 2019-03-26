using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class UserService : AbstractUserService, IUserService
	{
		public UserService(
			ILogger<IUserRepository> logger,
			IMediator mediator,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
			IDALUserMapper dalUserMapper,
			IDALBadgeMapper dalBadgeMapper,
			IDALCommentMapper dalCommentMapper,
			IDALPostMapper dalPostMapper,
			IDALVoteMapper dalVoteMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base(logger,
			       mediator,
			       userRepository,
			       userModelValidator,
			       dalUserMapper,
			       dalBadgeMapper,
			       dalCommentMapper,
			       dalPostMapper,
			       dalVoteMapper,
			       dalPostHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7f48bb8647c5616bc590513719fffe28</Hash>
</Codenesium>*/