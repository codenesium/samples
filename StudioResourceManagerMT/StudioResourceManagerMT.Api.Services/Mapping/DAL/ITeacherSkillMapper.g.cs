using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
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
    <Hash>1f82d57d68fcd3ef1974ea134c25ca28</Hash>
</Codenesium>*/