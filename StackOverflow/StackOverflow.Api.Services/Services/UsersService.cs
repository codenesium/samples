using MediatR;
using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class UsersService : AbstractUsersService, IUsersService
	{
		public UsersService(
			ILogger<IUsersRepository> logger,
			IMediator mediator,
			IUsersRepository usersRepository,
			IApiUsersServerRequestModelValidator usersModelValidator,
			IDALUsersMapper dalUsersMapper,
			IDALBadgesMapper dalBadgesMapper,
			IDALCommentsMapper dalCommentsMapper,
			IDALPostsMapper dalPostsMapper,
			IDALVotesMapper dalVotesMapper,
			IDALPostHistoryMapper dalPostHistoryMapper)
			: base(logger,
			       mediator,
			       usersRepository,
			       usersModelValidator,
			       dalUsersMapper,
			       dalBadgesMapper,
			       dalCommentsMapper,
			       dalPostsMapper,
			       dalVotesMapper,
			       dalPostHistoryMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>83c5b89ebf18c86ec8bf1eb5a489f90f</Hash>
</Codenesium>*/