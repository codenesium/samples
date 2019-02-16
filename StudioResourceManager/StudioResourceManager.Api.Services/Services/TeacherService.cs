using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>68f8bb8f1d2065b72c3c41367222bb27</Hash>
</Codenesium>*/