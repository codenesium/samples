using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLTeacherSkillMapper
	{
		BOTeacherSkill MapModelToBO(
			int id,
			ApiTeacherSkillRequestModel model);

		ApiTeacherSkillResponseModel MapBOToModel(
			BOTeacherSkill boTeacherSkill);

		List<ApiTeacherSkillResponseModel> MapBOToModel(
			List<BOTeacherSkill> items);
	}
}

/*<Codenesium>
    <Hash>5da5979c2c73058975d6af92358d4f26</Hash>
</Codenesium>*/