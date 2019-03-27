using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial class TeacherTeacherSkillService : AbstractTeacherTeacherSkillService, ITeacherTeacherSkillService
	{
		public TeacherTeacherSkillService(
			ILogger<ITeacherTeacherSkillRepository> logger,
			IMediator mediator,
			ITeacherTeacherSkillRepository teacherTeacherSkillRepository,
			IApiTeacherTeacherSkillServerRequestModelValidator teacherTeacherSkillModelValidator,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper)
			: base(logger,
			       mediator,
			       teacherTeacherSkillRepository,
			       teacherTeacherSkillModelValidator,
			       dalTeacherTeacherSkillMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f28ec91b1bb5bdb09d8c4b7ffea1e6e8</Hash>
</Codenesium>*/