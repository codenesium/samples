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
    <Hash>ae0a800e7e9648003672a6393b477cf2</Hash>
</Codenesium>*/