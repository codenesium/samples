using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IDALTeacherXTeacherSkillMapper
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
    <Hash>ddc5f18b322ecb70dceb51ef75ae99d9</Hash>
</Codenesium>*/