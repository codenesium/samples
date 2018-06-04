using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
    <Hash>9be520a9ae576191024f84345dd4928c</Hash>
</Codenesium>*/