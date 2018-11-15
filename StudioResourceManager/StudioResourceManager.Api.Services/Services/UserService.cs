using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class UserService : AbstractUserService, IUserService
	{
		public UserService(
			ILogger<IUserRepository> logger,
			IUserRepository userRepository,
			IApiUserServerRequestModelValidator userModelValidator,
			IBOLUserMapper bolUserMapper,
			IDALUserMapper dalUserMapper,
			IBOLAdminMapper bolAdminMapper,
			IDALAdminMapper dalAdminMapper,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper,
			IBOLTeacherMapper bolTeacherMapper,
			IDALTeacherMapper dalTeacherMapper)
			: base(logger,
			       userRepository,
			       userModelValidator,
			       bolUserMapper,
			       dalUserMapper,
			       bolAdminMapper,
			       dalAdminMapper,
			       bolStudentMapper,
			       dalStudentMapper,
			       bolTeacherMapper,
			       dalTeacherMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>d800a80e749c734b60788c73a64fd7f3</Hash>
</Codenesium>*/