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
			IDALTeacherMapper dalTeacherMapper,
			IDALRateMapper dalRateMapper)
			: base(logger,
			       mediator,
			       teacherRepository,
			       teacherModelValidator,
			       dalTeacherMapper,
			       dalRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7a7163adb09ec9b67403597653a2e3e5</Hash>
</Codenesium>*/