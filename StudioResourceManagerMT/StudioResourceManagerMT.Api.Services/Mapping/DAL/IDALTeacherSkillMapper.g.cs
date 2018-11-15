using Microsoft.EntityFrameworkCore;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>888cddf2a71f7370ada3fcabdcbd1d66</Hash>
</Codenesium>*/