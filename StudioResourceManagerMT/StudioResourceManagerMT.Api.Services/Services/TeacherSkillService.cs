using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class TeacherSkillService : AbstractTeacherSkillService, ITeacherSkillService
	{
		public TeacherSkillService(
			ILogger<ITeacherSkillRepository> logger,
			IMediator mediator,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillServerRequestModelValidator teacherSkillModelValidator,
			IDALTeacherSkillMapper dalTeacherSkillMapper,
			IDALRateMapper dalRateMapper)
			: base(logger,
			       mediator,
			       teacherSkillRepository,
			       teacherSkillModelValidator,
			       dalTeacherSkillMapper,
			       dalRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>af75d2e4cbd12d7caf643a3a0421af74</Hash>
</Codenesium>*/