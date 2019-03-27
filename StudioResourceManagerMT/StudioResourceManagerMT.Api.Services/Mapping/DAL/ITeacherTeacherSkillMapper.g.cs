using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALTeacherTeacherSkillMapper
	{
		TeacherTeacherSkill MapModelToEntity(
			int teacherId,
			ApiTeacherTeacherSkillServerRequestModel model);

		ApiTeacherTeacherSkillServerResponseModel MapEntityToModel(
			TeacherTeacherSkill item);

		List<ApiTeacherTeacherSkillServerResponseModel> MapEntityToModel(
			List<TeacherTeacherSkill> items);
	}
}

/*<Codenesium>
    <Hash>d19bdbb0679bc290e2fc7eb5c54188c3</Hash>
</Codenesium>*/