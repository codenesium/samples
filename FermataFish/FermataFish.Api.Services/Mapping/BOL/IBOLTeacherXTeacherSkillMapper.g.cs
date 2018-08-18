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
    <Hash>9e9ba1b6c4fd1d48f5bae77bf7480a4d</Hash>
</Codenesium>*/