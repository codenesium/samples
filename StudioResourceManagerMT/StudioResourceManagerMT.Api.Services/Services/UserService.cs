using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class UserService : AbstractUserService, IUserService
	{
		public UserService(
			ILogger<IUserRepository> logger,
			IMediator mediator,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
			IDALUserMapper dalUserMapper)
			: base(logger,
			       mediator,
			       userRepository,
			       userModelValidator,
			       dalUserMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>6a72b9d769d11d13be06fca5310eb28c</Hash>
</Codenesium>*/