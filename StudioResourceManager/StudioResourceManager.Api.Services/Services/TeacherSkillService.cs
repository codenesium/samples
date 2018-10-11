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
	public partial class TeacherSkillService : AbstractTeacherSkillService, ITeacherSkillService
	{
		public TeacherSkillService(
			ILogger<ITeacherSkillRepository> logger,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillRequestModelValidator teacherSkillModelValidator,
			IBOLTeacherSkillMapper bolteacherSkillMapper,
			IDALTeacherSkillMapper dalteacherSkillMapper,
			IBOLRateMapper bolRateMapper,
			IDALRateMapper dalRateMapper,
			IBOLTeacherTeacherSkillMapper bolTeacherTeacherSkillMapper,
			IDALTeacherTeacherSkillMapper dalTeacherTeacherSkillMapper)
			: base(logger,
			       teacherSkillRepository,
			       teacherSkillModelValidator,
			       bolteacherSkillMapper,
			       dalteacherSkillMapper,
			       bolRateMapper,
			       dalRateMapper,
			       bolTeacherTeacherSkillMapper,
			       dalTeacherTeacherSkillMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>52ffe59ac8d0adcd373c9ac5a66e1c54</Hash>
</Codenesium>*/