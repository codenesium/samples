using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLTeacherTeacherSkillMapper
	{
		BOTeacherTeacherSkill MapModelToBO(
			int teacherId,
			ApiTeacherTeacherSkillRequestModel model);

		ApiTeacherTeacherSkillResponseModel MapBOToModel(
			BOTeacherTeacherSkill boTeacherTeacherSkill);

		List<ApiTeacherTeacherSkillResponseModel> MapBOToModel(
			List<BOTeacherTeacherSkill> items);
	}
}

/*<Codenesium>
    <Hash>717604580b9e7ef97f7a9337ddaff70a</Hash>
</Codenesium>*/