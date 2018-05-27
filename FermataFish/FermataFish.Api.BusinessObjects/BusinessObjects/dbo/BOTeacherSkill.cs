using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class BOTeacherSkill: AbstractBOTeacherSkill, IBOTeacherSkill
	{
		public BOTeacherSkill(
			ILogger<TeacherSkillRepository> logger,
			ITeacherSkillRepository teacherSkillRepository,
			IApiTeacherSkillRequestModelValidator teacherSkillModelValidator,
			IBOLTeacherSkillMapper teacherSkillMapper)
			: base(logger, teacherSkillRepository, teacherSkillModelValidator, teacherSkillMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>231a9cd6c5c23ad0fe7e0563623317b1</Hash>
</Codenesium>*/