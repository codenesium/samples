using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>78d2749e512e51c51b96fb1bc0b87244</Hash>
</Codenesium>*/