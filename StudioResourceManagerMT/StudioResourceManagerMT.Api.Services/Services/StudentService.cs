using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class StudentService : AbstractStudentService, IStudentService
	{
		public StudentService(
			ILogger<IStudentRepository> logger,
			IMediator mediator,
			IStudentRepository studentRepository,
			IApiStudentServerRequestModelValidator studentModelValidator,
			IDALStudentMapper dalStudentMapper)
			: base(logger,
			       mediator,
			       studentRepository,
			       studentModelValidator,
			       dalStudentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>9cbea441f39e424b8a9edf773708889b</Hash>
</Codenesium>*/