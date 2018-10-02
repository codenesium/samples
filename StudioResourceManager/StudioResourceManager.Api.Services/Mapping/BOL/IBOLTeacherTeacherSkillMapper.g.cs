using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface IBOLTeacherTeacherSkillMapper
	{
		BOTeacherTeacherSkill MapModelToBO(
			int id,
			ApiTeacherTeacherSkillRequestModel model);

		ApiTeacherTeacherSkillResponseModel MapBOToModel(
			BOTeacherTeacherSkill boTeacherTeacherSkill);

		List<ApiTeacherTeacherSkillResponseModel> MapBOToModel(
			List<BOTeacherTeacherSkill> items);
	}
}

/*<Codenesium>
    <Hash>5208d03f42e6db628dda18bf477143a7</Hash>
</Codenesium>*/