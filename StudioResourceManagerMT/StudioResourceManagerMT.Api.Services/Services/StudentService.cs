using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class StudentService : AbstractStudentService, IStudentService
	{
		public StudentService(
			ILogger<IStudentRepository> logger,
			IStudentRepository studentRepository,
			IApiStudentServerRequestModelValidator studentModelValidator,
			IBOLStudentMapper bolStudentMapper,
			IDALStudentMapper dalStudentMapper)
			: base(logger,
			       studentRepository,
			       studentModelValidator,
			       bolStudentMapper,
			       dalStudentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>42b200e607479061cbe3d58b76c5a498</Hash>
</Codenesium>*/