using Microsoft.Extensions.Logging;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;

namespace StackOverflowNS.Api.Services
{
	public partial class UserService : AbstractUserService, IUserService
	{
		public UserService(
			ILogger<IUserRepository> logger,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
			IBOLUserMapper bolUserMapper,
			IDALUserMapper dalUserMapper)
			: base(logger,
			       userRepository,
			       userModelValidator,
			       bolUserMapper,
			       dalUserMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>41dba3e3754bd2610bcc57e709155cfc</Hash>
</Codenesium>*/