using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALTeacherTeacherSkillMapper
	{
		TeacherTeacherSkill MapBOToEF(
			BOTeacherTeacherSkill bo);

		BOTeacherTeacherSkill MapEFToBO(
			TeacherTeacherSkill efTeacherTeacherSkill);

		List<BOTeacherTeacherSkill> MapEFToBO(
			List<TeacherTeacherSkill> records);
	}
}

/*<Codenesium>
    <Hash>65abca3c2e87b1e18158402405c46802</Hash>
</Codenesium>*/