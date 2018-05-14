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
			IApiTeacherXTeacherSkillModelValidator teacherXTeacherSkillModelValidator)
			: base(logger, teacherXTeacherSkillRepository, teacherXTeacherSkillModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>18576f01094a3792fc8fd3da353480b8</Hash>
</Codenesium>*/