using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IDALTeacherSkillMapper
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
    <Hash>29bd0b86d73163b7cf7e2a443aaa9f6a</Hash>
</Codenesium>*/