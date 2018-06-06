using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
namespace FermataFishNS.Api.Services
{
	public interface IBOLTeacherXTeacherSkillMapper
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
    <Hash>34e4d77b5f4471c0056a8893bf573f56</Hash>
</Codenesium>*/