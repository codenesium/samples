using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IDALTeacherSkillMapper
	{
		TeacherSkill MapModelToEntity(
			int id,
			ApiTeacherSkillServerRequestModel model);

		ApiTeacherSkillServerResponseModel MapEntityToModel(
			TeacherSkill item);

		List<ApiTeacherSkillServerResponseModel> MapEntityToModel(
			List<TeacherSkill> items);
	}
}

/*<Codenesium>
    <Hash>b76d77a07c07162169422f9a2a7f1efa</Hash>
</Codenesium>*/