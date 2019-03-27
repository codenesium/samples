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
			IDALStudentMapper dalStudentMapper,
			IDALEventStudentMapper dalEventStudentMapper)
			: base(logger,
			       mediator,
			       studentRepository,
			       studentModelValidator,
			       dalStudentMapper,
			       dalEventStudentMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>bf0c1af726dab128916724845ab19f88</Hash>
</Codenesium>*/