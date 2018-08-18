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
    <Hash>5a156825c559000128c3b00dca1a9de6</Hash>
</Codenesium>*/