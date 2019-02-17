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
			IDALTeacherSkillMapper dalTeacherSkillMapper)
			: base(logger,
			       mediator,
			       teacherSkillRepository,
			       teacherSkillModelValidator,
			       dalTeacherSkillMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>5b2e44b9dfa788317c37c45ccfe47db8</Hash>
</Codenesium>*/