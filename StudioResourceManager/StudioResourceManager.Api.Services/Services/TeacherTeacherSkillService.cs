using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial class TeacherTeacherSkillService : AbstractTeacherTeacherSkillService, ITeacherTeacherSkillService
	{
		public TeacherTeacherSkillService(
			ILogger<ITeacherTeacherSkillRepository> logger,
			ITeacherTeacherSkillRepository teacherTeacherSkillRepository,
			IApiTeacherTeacherSkillRequestModelValidator teacherTeacherSkillModelValidator,
			IBOLTeacherTeacherSkillMapper bolteacherTeacherSkillMapper,
			IDALTeacherTeacherSkillMapper dalteacherTeacherSkillMapper)
			: base(logger,
			       teacherTeacherSkillRepository,
			       teacherTeacherSkillModelValidator,
			       bolteacherTeacherSkillMapper,
			       dalteacherTeacherSkillMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c23f7333b61ac27f33d8403861a2cab9</Hash>
</Codenesium>*/