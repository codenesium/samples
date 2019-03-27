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
			IDALEventTeacherMapper dalEventTeacherMapper,
			IDALRateMapper dalRateMapper,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper)
			: base(logger,
			       mediator,
			       teacherRepository,
			       teacherModelValidator,
			       dalTeacherMapper,
			       dalEventTeacherMapper,
			       dalRateMapper,
			       dalTeacherTeacherSkillMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a9c840838c4dd3b489f7e9cb9b9e71ac</Hash>
</Codenesium>*/