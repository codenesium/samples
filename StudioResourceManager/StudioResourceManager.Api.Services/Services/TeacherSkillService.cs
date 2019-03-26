using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class TeacherSkillService : AbstractTeacherSkillService, ITeacherSkillService
	{
		public TeacherSkillService(
			ILogger<ITeacherSkillRepository> logger,
			IMediator mediator,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillServerRequestModelValidator teacherSkillModelValidator,
			IDALTeacherSkillMapper dalTeacherSkillMapper,
			IDALRateMapper dalRateMapper,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper)
			: base(logger,
			       mediator,
			       teacherSkillRepository,
			       teacherSkillModelValidator,
			       dalTeacherSkillMapper,
			       dalRateMapper,
			       dalTeacherTeacherSkillMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>660d98725e28363193b7def81bfeeecc</Hash>
</Codenesium>*/