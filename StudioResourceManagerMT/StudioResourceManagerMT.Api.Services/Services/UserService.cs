using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>80fc2fc3422d998c8797c725f1dc8cc3</Hash>
</Codenesium>*/