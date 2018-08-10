using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALTeacherXTeacherSkillMapper
	{
		TeacherXTeacherSkill MapBOToEF(
			BOTeacherXTeacherSkill bo);

		BOTeacherXTeacherSkill MapEFToBO(
			TeacherXTeacherSkill efTeacherXTeacherSkill);

		List<BOTeacherXTeacherSkill> MapEFToBO(
			List<TeacherXTeacherSkill> records);
	}
}

/*<Codenesium>
    <Hash>d1ce57f0e8f98f4cd4824fc36a7be5da</Hash>
</Codenesium>*/