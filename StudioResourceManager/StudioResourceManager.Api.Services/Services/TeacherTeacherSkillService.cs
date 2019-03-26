using MediatR;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>344cf73bf8c002c5defd39b123d2cf0d</Hash>
</Codenesium>*/