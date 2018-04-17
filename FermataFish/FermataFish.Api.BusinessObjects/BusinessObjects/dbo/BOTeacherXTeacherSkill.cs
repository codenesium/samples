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
			ITeacherXTeacherSkillModelValidator teacherXTeacherSkillModelValidator)
			: base(logger, teacherXTeacherSkillRepository, teacherXTeacherSkillModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>77e43432f93a43e9a37e1b2e1ddb272a</Hash>
</Codenesium>*/