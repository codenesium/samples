using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class TeacherSkillService: AbstractTeacherSkillService, ITeacherSkillService
	{
		public TeacherSkillService(
			ILogger<TeacherSkillRepository> logger,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillRequestModelValidator teacherSkillModelValidator,
			IBOLTeacherSkillMapper BOLteacherSkillMapper,
			IDALTeacherSkillMapper DALteacherSkillMapper)
			: base(logger, teacherSkillRepository,
			       teacherSkillModelValidator,
			       BOLteacherSkillMapper,
			       DALteacherSkillMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>937465f772605974592ed4b28cdd83b9</Hash>
</Codenesium>*/