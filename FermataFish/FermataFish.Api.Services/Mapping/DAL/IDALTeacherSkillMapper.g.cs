using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IDALTeacherSkillMapper
	{
		TeacherSkill MapBOToEF(
			BOTeacherSkill bo);

		BOTeacherSkill MapEFToBO(
			TeacherSkill efTeacherSkill);

		List<BOTeacherSkill> MapEFToBO(
			List<TeacherSkill> records);
	}
}

/*<Codenesium>
    <Hash>f3a045552b4652c983fe52e5cb76815c</Hash>
</Codenesium>*/