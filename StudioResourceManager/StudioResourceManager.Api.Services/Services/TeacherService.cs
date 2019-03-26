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
    <Hash>606f3ab837cbc9b2c09edc1a11079bf1</Hash>
</Codenesium>*/