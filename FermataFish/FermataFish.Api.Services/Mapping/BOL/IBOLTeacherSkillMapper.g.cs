using System;
using System.Collections.Generic;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
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
			List<BOTeacherSkill> bos);
	}
}

/*<Codenesium>
    <Hash>58b46a20d3ccf0526d62949b72615f80</Hash>
</Codenesium>*/