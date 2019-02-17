using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class TeacherService : AbstractTeacherService, ITeacherService
	{
		public TeacherService(
			ILogger<ITeacherRepository> logger,
			IMediator mediator,
			ITeacherRepository teacherRepository,
			IApiTeacherServerRequestModelValidator teacherModelValidator,
			IDALTeacherMapper dalTeacherMapper)
			: base(logger,
			       mediator,
			       teacherRepository,
			       teacherModelValidator,
			       dalTeacherMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f73c896cf9f57eaadf3223d5a6a10ada</Hash>
</Codenesium>*/