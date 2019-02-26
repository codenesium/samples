using MediatR;
using Microsoft.Extensions.Logging;
using SecureVideoCRMNS.Api.Contracts;
using SecureVideoCRMNS.Api.DataAccess;

namespace SecureVideoCRMNS.Api.Services
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
    <Hash>837acf3ab6d979a3d34e959811ab061f</Hash>
</Codenesium>*/