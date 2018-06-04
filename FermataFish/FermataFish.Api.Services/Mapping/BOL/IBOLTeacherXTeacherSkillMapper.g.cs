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
			List<BOTeacherXTeacherSkill> bos);
	}
}

/*<Codenesium>
    <Hash>73ce2452f8298772391ead69edf6363f</Hash>
</Codenesium>*/