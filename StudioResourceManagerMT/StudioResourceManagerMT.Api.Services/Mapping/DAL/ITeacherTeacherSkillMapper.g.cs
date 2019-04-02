using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IDALTeacherTeacherSkillMapper
	{
		TeacherTeacherSkill MapModelToEntity(
			int id,
			ApiTeacherTeacherSkillServerRequestModel model);

		ApiTeacherTeacherSkillServerResponseModel MapEntityToModel(
			TeacherTeacherSkill item);

		List<ApiTeacherTeacherSkillServerResponseModel> MapEntityToModel(
			List<TeacherTeacherSkill> items);
	}
}

/*<Codenesium>
    <Hash>ccff28510f21462c3caec6068d580d51</Hash>
</Codenesium>*/