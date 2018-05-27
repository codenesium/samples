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
	public class BOTeacherXTeacherSkill: AbstractBOTeacherXTeacherSkill, IBOTeacherXTeacherSkill
	{
		public BOTeacherXTeacherSkill(
			ILogger<TeacherXTeacherSkillRepository> logger,
			ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
			IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator,
			IBOLTeacherXTeacherSkillMapper teacherXTeacherSkillMapper)
			: base(logger, teacherXTeacherSkillRepository, teacherXTeacherSkillModelValidator, teacherXTeacherSkillMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>b68c0259debf5d2511d5d7d587bfd467</Hash>
</Codenesium>*/