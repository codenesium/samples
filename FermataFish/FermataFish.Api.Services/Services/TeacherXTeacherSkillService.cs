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
	public class TeacherXTeacherSkillService: AbstractTeacherXTeacherSkillService, ITeacherXTeacherSkillService
	{
		public TeacherXTeacherSkillService(
			ILogger<TeacherXTeacherSkillRepository> logger,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator,
			IBOLTeacherXTeacherSkillMapper BOLteacherXTeacherSkillMapper,
			IDALTeacherXTeacherSkillMapper DALteacherXTeacherSkillMapper)
			: base(logger, teacherXTeacherSkillRepository,
			       teacherXTeacherSkillModelValidator,
			       BOLteacherXTeacherSkillMapper,
			       DALteacherXTeacherSkillMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>4a98209fddf242afb41372cfead47d68</Hash>
</Codenesium>*/