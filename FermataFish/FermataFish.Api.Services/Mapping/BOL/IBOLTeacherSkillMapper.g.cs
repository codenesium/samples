using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
	public interface IBOLTeacherSkillMapper
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
    <Hash>b4d7f673e902f119cbf32b4b8d121f31</Hash>
</Codenesium>*/