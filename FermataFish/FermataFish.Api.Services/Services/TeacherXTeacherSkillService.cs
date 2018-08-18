using Codenesium.DataConversionExtensions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial class TeacherXTeacherSkillService : AbstractTeacherXTeacherSkillService, ITeacherXTeacherSkillService
	{
		public TeacherXTeacherSkillService(
			ILogger<ITeacherXTeacherSkillRepository> logger,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator,
			IBOLTeacherXTeacherSkillMapper bolteacherXTeacherSkillMapper,
			IDALTeacherXTeacherSkillMapper dalteacherXTeacherSkillMapper
			)
			: base(logger,
			       teacherXTeacherSkillRepository,
			       teacherXTeacherSkillModelValidator,
			       bolteacherXTeacherSkillMapper,
			       dalteacherXTeacherSkillMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>25e9789c0914fcf15d6826133bf2e244</Hash>
</Codenesium>*/