using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class TeacherSkillService : AbstractTeacherSkillService, ITeacherSkillService
	{
		public TeacherSkillService(
			ILogger<ITeacherSkillRepository> logger,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillServerRequestModelValidator teacherSkillModelValidator,
			IBOLTeacherSkillMapper bolTeacherSkillMapper,
			IDALTeacherSkillMapper dalTeacherSkillMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper)
			: base(logger,
			       teacherSkillRepository,
			       teacherSkillModelValidator,
			       bolTeacherSkillMapper,
			       dalTeacherSkillMapper,
			       bolRateMapper,
			       dalRateMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f6be0e7683854e19c6ea41a695493d51</Hash>
</Codenesium>*/