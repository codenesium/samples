using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public partial interface IBOLTeacherXTeacherSkillMapper
	{
		BOTeacherXTeacherSkill MapModelToBO(
			int id,
			ApiTeacherXTeacherSkillRequestModel model);

		ApiTeacherXTeacherSkillResponseModel MapBOToModel(
			BOTeacherXTeacherSkill boTeacherXTeacherSkill);

		List<ApiTeacherXTeacherSkillResponseModel> MapBOToModel(
			List<BOTeacherXTeacherSkill> items);
	}
}

/*<Codenesium>
    <Hash>127e43914f6ad557a42a893de5544e3f</Hash>
</Codenesium>*/