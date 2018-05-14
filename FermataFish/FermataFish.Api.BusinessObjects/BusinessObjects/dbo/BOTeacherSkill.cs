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
			IApiTeacherSkillModelValidator teacherSkillModelValidator)
			: base(logger, teacherSkillRepository, teacherSkillModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>cb34215fecef5b0086283b4380473ecb</Hash>
</Codenesium>*/