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
			IDALUserMapper dalUserMapper,
			IDALAdminMapper dalAdminMapper,
			IDALStudentMapper dalStudentMapper,
			IDALTeacherMapper dalTeacherMapper)
			: base(logger,
			       mediator,
			       userRepository,
			       userModelValidator,
			       dalUserMapper,
			       dalAdminMapper,
			       dalStudentMapper,
			       dalTeacherMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>40f1495cdff31cfa96f6b13182155645</Hash>
</Codenesium>*/