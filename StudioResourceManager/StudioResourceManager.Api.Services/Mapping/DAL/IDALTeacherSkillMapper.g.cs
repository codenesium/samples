using Microsoft.EntityFrameworkCore;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
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
    <Hash>081a49ac98295a5cb3a0f3271b530df9</Hash>
</Codenesium>*/