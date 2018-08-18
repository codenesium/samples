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
    <Hash>6068c8ac177c2031e39ab4ccb3b4ea8e</Hash>
</Codenesium>*/