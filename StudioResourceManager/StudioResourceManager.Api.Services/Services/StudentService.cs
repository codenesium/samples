using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>5d2995c9e407d3539ecae4315f8285f6</Hash>
</Codenesium>*/