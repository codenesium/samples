using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IBOLTeacherSkillMapper
	{
		BOTeacherSkill MapModelToBO(
			int id,
			ApiTeacherSkillServerRequestModel model);

		ApiTeacherSkillServerResponseModel MapBOToModel(
			BOTeacherSkill boTeacherSkill);

		List<ApiTeacherSkillServerResponseModel> MapBOToModel(
			List<BOTeacherSkill> items);
	}
}

/*<Codenesium>
    <Hash>816495a773244977836c107b9ad32140</Hash>
</Codenesium>*/